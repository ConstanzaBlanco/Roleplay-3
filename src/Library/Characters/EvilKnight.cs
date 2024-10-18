namespace Ucu.Poo.RoleplayGame;

public class EvilKnight: Enemy
{
    public EvilKnight(string name, int vp) : base(name, vp)
    {
        this.health = 90;
        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
}