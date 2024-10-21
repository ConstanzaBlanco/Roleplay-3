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
    public GoodWizard(string name) : base(name)
    {
        this.AddItem(new Staff());
    }
}
 