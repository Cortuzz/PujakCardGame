using System.Collections.Generic;

namespace PujakCardGame;

public interface IModifiable
{
    public ICollection<Modifier> Modifiers { get; }
}