#nullable enable
using System;

namespace PujakCardGame;

public interface IModifier
{
    public string Name { get; }

    public IModifiable? Target { get; set; }
}

public abstract class Modifier<TTarget> : IModifier where TTarget : class, IModifiable
{
    public abstract string Name { get; }
    protected IModifiable? _target = null;

    IModifiable? IModifier.Target
    {
        get => _target;
        set
        {
            if (value == _target) return;
            if (_target != null) _onTargetDetaching();
            _target = value;
            if (value != null) _onTargetAttached();
        }

    }

    public TTarget? Target
    {
        get => _target as TTarget;
        set =>  ((IModifier)this).Target = value;
    }

    /// <summary>
    /// That method calls when <see cref="Target"/> changed to not null value
    /// </summary>
    protected abstract void _onTargetAttached();

    /// <summary>
    /// That method calls when <see cref="Target"/> value is going to change
    /// </summary>
    protected abstract void _onTargetDetaching();
}