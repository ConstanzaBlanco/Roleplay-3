namespace Ucu.Poo.RoleplayGame;

public abstract class Enemy:Hero
{
    public Enemy(string name, int vp)
        :base(name)
    {
        this.Vp = vp;
    }

    public void ModifyVp()
    {
        if (this.IsAlive)
        {
            this.Vp = 0;
            
        }
    }
}