namespace Ucu.Poo.RoleplayGame;

public class EvilWizard:Enemy,IMagicCharacter
{
    private List<IMagicalItem> magicalIItems = new List<IMagicalItem>();

    public EvilWizard(string name, int vp) : base(name, vp)
    {
        this.AddItem(new Staff());
    }
    
    public void AddItem(IMagicalItem item)
    {
        this.magicalIItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalIItems.Remove(item);
    }
    
    public override int AttackValue
    {
        get
        {
            int value = 0;
            
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            
            foreach (IMagicalItem item in this.magicalIItems)
            {
                if (item is IMagicalAttackItem)
                {
                    value += (item as IMagicalAttackItem).AttackValue;
                }
            }

            return value;
        }
    }
    
}