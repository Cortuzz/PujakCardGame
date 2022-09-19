using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace PujakCardGame
{
    /// <summary>
    /// Procecsses sequence of modifier's scemas using <see cref="System.Reflection"/>
    /// and provides creating new instances of modifiers via enumeration
    /// </summary>
    public class ModifiersCreator : IEnumerator<IModifier>
    {
#nullable enable
        private record ProcessedModiferScema(ConstructorInfo Constructor, object[]? Parameters);
#nullable disable

        private readonly ProcessedModiferScema[] _processedScemas;
        private int _currantIndex = -1;

        public IModifier Current { get; private set; } = null;

        object IEnumerator.Current => Current;

        /// <param name="namespaces"> An environment where to find modifier's classes </param>
        public ModifiersCreator(ModifierScema[] modifierScemas, string[] namespaces)
        {
            _processedScemas = new ProcessedModiferScema[modifierScemas.Length];
            for (int i = 0; i < modifierScemas.Length; ++i)
            {
                var scema = modifierScemas[i];
                foreach (var ns in namespaces)
                {
                    var modifierType = Type.GetType($"{ns}.{scema.Name}", false);
                    if (modifierType == null || modifierType.IsAbstract
                        || modifierType.GetInterfaces().FirstOrDefault(_i => _i == typeof(IModifier), null) == null)
                        continue;

                    Type[] types = new Type[scema.Args?.Length ?? 0];
                    for (int j = 0; j < types.Length; ++j)
                        types[j] = scema.Args![j].GetType();

                    _processedScemas[i] = new ProcessedModiferScema(modifierType.GetConstructor(types), 
                        scema.Args.Cast<object>().ToArray());
                }

                Debug.Assert(_processedScemas[i].Constructor != null, "Modifier scema is invalid");
            }
        }

        public bool MoveNext()
        {
            if (++_currantIndex >= _processedScemas.Length) return false;
            var scema = _processedScemas[_currantIndex];
            Current = (IModifier)scema.Constructor.Invoke(scema.Parameters);
            return true;
        }

        public void Reset() => _currantIndex = -1;

        public void Dispose() => Current = null;
    }
}
