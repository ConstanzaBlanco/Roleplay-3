using System.Diagnostics;

namespace Ucu.Poo.RoleplayGame;

public class GoodDwarf :Hero
{
    public GoodDwarf(string name) : base(name)
    {
        this.health = 120;
        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }
}