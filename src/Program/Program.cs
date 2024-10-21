using System;
using Library.Encounters;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        Hero flechaverde = new GoodArcher("FlechaVerde");
        Hero gruñon = new GoodDwarf("Gruñon");
        Enemy caballerodearkham = new EvilKnight("ArkhamKnight", 5);
        Encounters encuentrolegendario = new Encounters();
        encuentrolegendario.AddHeroe(gruñon);
        encuentrolegendario.AddHeroe(flechaverde);
        encuentrolegendario.AddEnemy(caballerodearkham);
        encuentrolegendario.DoEncounter(); 
    }
}
