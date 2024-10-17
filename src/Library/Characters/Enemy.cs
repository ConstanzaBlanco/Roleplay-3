namespace Ucu.Poo.RoleplayGame;

public abstract class Enemy:Character
{
    public Enemy(string name, int vp)
        :base(name)
    { 
        Vp = vp;
    }

    public void ModifyVp()
    {
        if (this.IsAlive)
        {
            this.Vp = 0;
            
        }
    }
}