namespace Ucu.Poo.RoleplayGame;

public class GoodArcher: Hero
{
    public GoodArcher(string name) : base(name)
    {
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
        this.health = 100;
    }
}