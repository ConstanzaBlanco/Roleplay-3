using System.Diagnostics;

namespace Ucu.Poo.RoleplayGame;

public class GoodKnight :Hero
{
    public GoodKnight(string name) : base(name)
    {
        this.health = 90;
        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
}