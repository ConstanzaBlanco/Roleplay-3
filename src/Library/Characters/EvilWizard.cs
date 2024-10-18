namespace Ucu.Poo.RoleplayGame;

public class EvilWizard:Enemy,IMagicCharacter
{
    private List<IMagicalItem> magicalIItems = new List<IMagicalItem>();

    public EvilWizard(string name, int vp) : base(name, vp){}
    
    public void AddItem(IMagicalItem item)
    {
        this.magicalIItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalIItems.Remove(item);
    }
    
}