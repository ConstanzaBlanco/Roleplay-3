using System;
using Library.Encounters;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        Hero arquero1 = new GoodArcher("Pedro");
        Enemy arquero2 = new EvilArcher("Juan",30);
        Encounters encuentro1 = new Encounters();
        encuentro1.AddHeroe(arquero1);
        encuentro1.AddEnemy(arquero2);
        encuentro1.DoEncounter();
    }
}
