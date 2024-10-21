using Library.Encounters;
using Ucu.Poo.RoleplayGame;

namespace TestProject3;

public class Tests
{
    // Define los campos de clase para que estén disponibles en todos los métodos
    private Hero caballerobueno1;
    private Hero caballerobueno2;
    private Hero caballerobueno3;
    private Enemy caballeromalo;
    private Enemy arqueromalo1;
    private Enemy arqueromalo2;
    private Encounters encuentro1;
    private Encounters encuentro2;


    [SetUp]
    public void Setup()
    {
        // Inicializar las variables en el Setup
        caballerobueno1 = new GoodKnight("Shrek");  
        caballerobueno2 = new GoodKnight("Arnold");  
        caballeromalo = new EvilKnight("PrincipeEncantador", 6);
        caballerobueno3 = new GoodKnight("Lancelot");
        arqueromalo1 = new EvilArcher("Juan", 1);
        arqueromalo2 = new EvilArcher("Pedro", 2);

        encuentro1 = new Encounters();
        encuentro1.AddHeroe(caballerobueno1);
        encuentro1.AddHeroe(caballerobueno2);
        encuentro1.AddEnemy(caballeromalo);
        encuentro1.DoEncounter();

        encuentro2 = new Encounters();
        encuentro2.AddHeroe(caballerobueno3);
        encuentro2.AddEnemy(arqueromalo1);
        encuentro2.AddEnemy(arqueromalo2);
        encuentro2.DoEncounter();

    }
    
    [Test]
    public void Test1() // Testeo que el héroe se cure tras vencer a un enemigo
    {
        int vidaEsperada = 100;
        int vidaReal = caballerobueno2.Health;
        
        Assert.AreEqual(vidaEsperada, vidaReal);
        Assert.Pass();

    }

    [Test]
    public void Test2() // Testeo que el heroe haya perdido 5 vp tras curarse
    {
        int vpEsperados = 1;
        int vpReales = caballerobueno2.GetVp();
        Assert.AreEqual(vpEsperados, vpReales); //el heroe perdió 5vp y se quedó con 1

    }
    [Test]
    public void Test3() // Testeo que el caballero2 a pesar de haber contribuido en la pelea, no se quedó con los vp del enemigo 
    {
        int vpEsperados = 0;
        int vpReales = caballerobueno1.GetVp();
        
        Assert.AreEqual(vpEsperados, vpReales); //El caballero2 se mantuvo con sus 0 vp
    }
    [Test]
    public void Test4() //Testeo para ver que al derrotar a más d eun enemigo, se suman los vp
    {
        int vpEsperados = 3;
        int vpReales = caballerobueno3.GetVp();
        
        Assert.AreEqual(vpEsperados, vpReales); //El caballero3 tiene en total 3 de vp por haber derrotado a los 2 enemigos
    }
    [Test]
    public void Test5() // Testeo que el caballero1 no se puede curar si tiene menos de 5 vp, (tendría 100 de vida sino)
    {
        int vidaEsperada = 90;
        int vidaReal = caballerobueno3.Health;
        
        Assert.AreEqual(vidaEsperada, vidaReal);
    }
}