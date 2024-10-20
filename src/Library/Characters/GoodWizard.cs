namespace Ucu.Poo.RoleplayGame;

public class GoodWizard:Character,IMagicCharacter
{
    private List<IMagicalItem> magicalIItems = new List<IMagicalItem>();
    
    public void AddItem(IMagicalItem item)
    {
        this.magicalIItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalIItems.Remove(item);
    }

    public GoodWizard(string name) : base(name)
    {
        this.AddItem(new Staff());
    }
}