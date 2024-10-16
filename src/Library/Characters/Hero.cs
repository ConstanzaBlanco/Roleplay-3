namespace Ucu.Poo.RoleplayGame;

public abstract class Hero
{
  public int Health { get; private set; }
  public int DefenseValue { get; private set; }
  public int AttackValue { get;}
  public List<IItem> Items { get; private set; }
  public string Name { get; private set; }
  public int Vp { get;set; }
  
  public bool IsAlive { get; private set; }
  public Hero(string name) //Se agrega virtual?
  {
    this.Name = name;
    this.IsAlive = true;
    this.Vp = 0;
  }

  public void AddItem(IItem item)
  {
    Items.Add(item);
  }

  public void RemoveItem(IItem item)
  {
    Items.Remove(item);
  }
  
  private void ReceiveAttack(IAttackItem item)
  {

    if (DefenseValue > item.AttackValue)
    {
      DefenseValue -= item.AttackValue;
    }
    else
    {
      Health -= item.AttackValue - DefenseValue;
      DefenseValue = 0;
      if (Health <= 0)
      {
        Health = 0;
        IsAlive = false;
        Console.WriteLine($"El personaje {Name} ha muerto.");
      }
    }
  }

  public void UseDefense(IDefenseItem item)
  {
    DefenseValue += item.DefenseValue;
  }

  public virtual void ModifyVp(int value)
  {
    Vp += value;
  }

  public void Cure()
  {
    Health +=30 ;
  }
}
