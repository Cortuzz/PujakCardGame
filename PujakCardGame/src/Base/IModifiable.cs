using System.Collections.Generic;

namespace PujakCardGame;

public interface IModifiable
{
    IEnumerable<IModifier> GetModifiers();

    void AddModifier(IModifier modifier);

    void RemoveModifier(IModifier modifier);
}


/*
 * Could be too cumbersome 
 * 
public interface IModifiable<TTarget> : IModifiable where TTarget : class, IModifiable
{
    new IEnumerable<Modifier<TTarget>> GetModifiers();

    void AddModifier(Modifier<TTarget> modifier);

    void RemoveModifier(Modifier<TTarget> modifier);
}
*/