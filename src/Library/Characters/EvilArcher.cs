namespace Ucu.Poo.RoleplayGame;

public class EvilArcher: Enemy
{
    public EvilArcher(string name, int vp) : base(name, vp)
    {
        this.health = 100;
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}