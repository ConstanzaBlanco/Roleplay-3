namespace Ucu.Poo.RoleplayGame;

public class EvilDwarf: Enemy
{
    public EvilDwarf(string name, int vp) : base(name, vp)
    {
        this.health = 120;
        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }
}
