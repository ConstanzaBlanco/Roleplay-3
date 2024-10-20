namespace Ucu.Poo.RoleplayGame;

public abstract class Character
{
    protected int health;
    protected int Vp;

    protected List<IItem> items = new List<IItem>();

    public Character(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
    public int AttackValue
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
            return value;
        }
    }
    public int GetVp()
    {
        return Vp;
    }
    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
            Console.WriteLine($"{Name} ha recibido {power-DefenseValue} de daño, quedandose a {Health} de vida");
        }
        else
        {
            Console.WriteLine($"{Name} no ha recibido daño, su defensa es mayor");
        }
    }

    public bool IsAlive()
    {
        if (Health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }
}
