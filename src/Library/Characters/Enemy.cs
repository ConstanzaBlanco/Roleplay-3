namespace Ucu.Poo.RoleplayGame;

public abstract class Enemy:Character
{
    public Enemy(string name, int vp)
        :base(name)
    { 
        this.Vp = vp;
    }
    
    
}