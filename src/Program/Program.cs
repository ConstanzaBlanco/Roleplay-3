using System;
using Library.Encounters;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        EvilArcher arqueromalo = new EvilArcher("ArqueroReMalo", 10);
        GoodKnight caballerodeluz = new GoodKnight("caballeroluminante");
        GoodKnight supercaballero = new GoodKnight("hipercaballero");
        EvilWizard magohorrible = new EvilWizard("voldemor", 20);
        Encounters batalladelapiedras = new Encounters();
        batalladelapiedras.AddEnemy(magohorrible);
        batalladelapiedras.AddHeroe(supercaballero);
        batalladelapiedras.AddEnemy(arqueromalo);
        batalladelapiedras.AddHeroe(caballerodeluz);
        batalladelapiedras.DoEncounter();
    }
}
