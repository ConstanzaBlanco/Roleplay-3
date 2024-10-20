namespace Ucu.Poo.RoleplayGame;

  public abstract class Hero :Character
  {
      public Hero(string name)
          :base(name)
      { 
          Vp = 0;
      }

      public void ModifyVp(int value)
      {
          Vp += value;
      }
  }
