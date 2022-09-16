using System.Collections.Generic;

namespace PujakCardGame;

public interface IModifiable
{
    IEnumerable<IModifier> GetModifiers();

    void AddModifier(IModifier modifier);

    void RemoveModifier(IModifier modifier);
}
