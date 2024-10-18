namespace Ucu.Poo.RoleplayGame;

public abstract class Enemy:Character
{
    public Enemy(string name, int vp)
        :base(name)
    { 
        this.Vp = vp;
    }

    public void ModifyVp()
    {
        if (IsAlive())
        {
            this.Vp = 0;
            
        }
    }
}