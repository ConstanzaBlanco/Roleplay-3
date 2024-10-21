using Library.Encounters;
using Ucu.Poo.RoleplayGame;

namespace TestProject2;

public class Tests

{
    // Definir los campos de clase para que estén disponibles en todos los métodos
    private Hero caballerobueno1;
    private Hero caballerobueno2;
    private Hero caballerobueno3;
    private Enemy caballeromalo;
    private Enemy arqueromalo1;
    private Enemy arqueromalo2;
    private Enemy enanomalo2;
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
    public void GanaEnemigoSinDanio()
        //Como la defensa del enemigo qu en este caso es un caballero es de 25(Armadura)+14(Escudo),en total es 39,
        //por lo que los ataques de un enano y un arquero nunca superan su defensa, entonces nunca recibe danio.
    {
        Hero enano1 = new GoodDwarf("Tontin");
        Hero arquero1 = new GoodArcher("Link");
        Enemy caballero1 = new EvilKnight("Caballero oscuro", 70);
        Encounters encuentro1 = new Encounters();
        encuentro1.AddHeroe(enano1);
        encuentro1.AddHeroe(arquero1);
        encuentro1.AddEnemy(caballero1);
        encuentro1.DoEncounter();
        int vidaesperadaenemigo = 90;
        int vidaobtenidaenemigo = caballero1.Health;
        Assert.AreEqual(vidaobtenidaenemigo, vidaobtenidaenemigo);
    }

    [Test]
    public void GananHeroesMuere1()
    {
        //En este encuentro hay 2 heroes y un villano, el primer heroe de la lista de heroes es un arquero,
        //por lo que al enfrentarse a un enano y el arquero ser mas debil, el arquero muere pero de igual forma ganan los heroes.
        Hero arquero2 = new GoodArcher("Robin Hood");
        Hero caballero2 = new GoodKnight("Tristan");
        Enemy enano2 = new EvilDwarf("Gruñon", 50);
        Encounters encuentro1 = new Encounters();
        encuentro1.AddHeroe(arquero2);
        encuentro1.AddHeroe(caballero2);
        encuentro1.AddEnemy(enano2);
        encuentro1.DoEncounter();
        int vidaesperadaArquero = 0;
        int vidaobtenidaArquero = arquero2.Health;
        Assert.AreEqual(vidaesperadaArquero, vidaobtenidaArquero);
        int vidaesperadaEnemigo = 0;
        int vidaobtenidaEnemigo = enano2.Health;
        Assert.AreEqual(vidaesperadaEnemigo, vidaobtenidaEnemigo);

    }

    [Test]
    public void GanaHeroeCon1VpPorCadaEnemigo()
    {
        //En este encuentro gana el mago con toda su vida, ya que su defensa al tener el baston es de 100, mientras que los
        //ataques de los caballeros son de 20, por lo que nunca llegan a bajarle la vida
        Hero mago1 = new GoodWizard("El Hada Madrina");
        Enemy caballero1 = new EvilKnight("Galahad", 1);
        Enemy caballero2 = new EvilKnight("Gareth", 1);
        Enemy caballero3 = new EvilKnight("Pendragon", 1);
        Enemy caballero4 = new EvilKnight("Keith", 1);
        Encounters encuentro1 = new Encounters();
        encuentro1.AddHeroe(mago1);
        encuentro1.AddEnemy(caballero1);
        encuentro1.AddEnemy(caballero2);
        encuentro1.AddEnemy(caballero3);
        encuentro1.AddEnemy(caballero4);
        encuentro1.DoEncounter();
        int vpEsperado = 4;
        int vpObtenido = mago1.GetVp();
        Assert.AreEqual(vpEsperado, vpObtenido);
        int vidaEsperadaMago = 20;
        int vidaObtenidaMago = mago1.Health;
        Assert.AreEqual(vidaEsperadaMago, vidaObtenidaMago);
    }

    [Test]
    public void GanaEnemigoPorEmpezar()
    {
        //En este test se puede ver que los enemigos ganan,ya que son los primeros en empezar.
        //Ganan porque el heroe y el enemigo en este combate tiene los mismos valores de Ataque, Defensa y vida,
        //lo unico que cambia es quien comenza el combate, por lo que las vidas van a ir bajando casi a la par en cada turno.
        //Heroe-Enemigo: 83-100, 66-83, 49-66, 32-49, 15-32, 0-15.
        Hero arquero1 = new GoodArcher("Pedro");
        Enemy arquero2 = new EvilArcher("Juan", 30);
        Encounters encuentro1 = new Encounters();
        encuentro1.AddHeroe(arquero1);
        encuentro1.AddEnemy(arquero2);
        encuentro1.DoEncounter();
        int vidaEsperadaPedro = 0;
        int vidaObtenidaPedro = arquero1.Health;
        Assert.AreEqual(vidaObtenidaPedro, vidaEsperadaPedro);
        //Este test es posible hacerlo con arquero,enano y caballero pero no con mago, ya que su valor de defensa es 100, y su valor de
        //ataque es de 100, por lo que si 2 Magos pelean, esta batala sera infinita, ya que nunca se bajan ni punto de vida el uno al otro.
    }

    [Test]
    public void VariosEnemigosPocosHeroes()
    {
        // Este test verifica cómo se distribuyen los ataques cuando hay más enemigos que héroes.
        // Como hay más enemigos, algunos héroes recibirán múltiples ataques en el mismo turno,
        // por lo que los enemigos seran ganadores al final de la batalla.

        Hero caballero1 = new GoodKnight("Lancelot");
        Hero arquero1 = new GoodArcher("Legolas");

        Enemy enano1 = new EvilDwarf("Estornudo", 50);
        Enemy enano2 = new EvilDwarf("Dormilon", 50);
        Enemy arquero2 = new EvilArcher("Odiseo", 50);
        Enemy arquero3 = new EvilArcher("Eros", 50);

        Encounters encuentro1 = new Encounters();
        encuentro1.AddHeroe(caballero1);
        encuentro1.AddHeroe(arquero1);
        encuentro1.AddEnemy(enano1);
        encuentro1.AddEnemy(enano2);
        encuentro1.AddEnemy(arquero2);
        encuentro1.AddEnemy(arquero3);
        encuentro1.DoEncounter();

        int vidaEsperadaCaballero = 0;
        int vidaObtenidaCaballero = caballero1.Health;
        Assert.AreEqual(vidaEsperadaCaballero, vidaObtenidaCaballero);

        int vidaEsperadaArquero = 0;
        int vidaObtenidaArquero = arquero1.Health;
        Assert.AreEqual(vidaEsperadaArquero, vidaObtenidaArquero);

        bool enemigosGanan = false;
        int enemigosVivos = encuentro1.GetEnemigos().Count;

        if (enemigosVivos > 0)
        {
            enemigosGanan = true;
        }

        Assert.IsTrue(enemigosGanan);
        //Aca probamos si es verdad que los enemigos ganaron la batalla al contar cuantos quedan en la lista de enemigos, si la lista tiene
        //al menos 1 enemigo estos ganan, ya que antes ya confirmamos si los heroes de este encuentro estaban vivos.
        //Esto ocurre, ya que cuando muere un personaje, este es removido de su lista correspondiente automaticamente, quedando solo los vivos al final.
    }

    [Test]
    public void BatallaTerminada()
        //Verificación de los bools se cambian correctamente al terminar una batalla
    {
        Hero flechaverde = new GoodArcher("FlechaVerde");
        Hero dormilon = new GoodDwarf("Dormilon");
        Enemy caballerodearkham = new EvilKnight("ArkhamKnight", 5);
        Encounters encuentrolegendario = new Encounters();
        encuentrolegendario.AddHeroe(dormilon);
        encuentrolegendario.AddHeroe(flechaverde);
        encuentrolegendario.AddEnemy(caballerodearkham);
        encuentrolegendario.DoEncounter();
        bool valordebatallaesperada = true;
        Assert.AreEqual(valordebatallaesperada, encuentrolegendario.batallaterminada);
    }

    [Test]
    public void BatallaNoTerminada()
        //Como la batalla no termina en los 100 turno damos por centado que los personajes se estancaron (Es decir que ninguno puede dañar al otro y viseversa) 
    {
        Hero maguito = new GoodWizard("HarryPotter");
        Enemy magomalvado = new EvilWizard("ElInnombrables", 5);
        Encounters encuentrolegendario = new Encounters();
        encuentrolegendario.AddHeroe(maguito);
        encuentrolegendario.AddEnemy(magomalvado);
        encuentrolegendario.DoEncounter();
        bool valordebatallaesperada = false;
        Assert.AreEqual(valordebatallaesperada, encuentrolegendario.batallaterminada);
    }

    [Test]
    public void BatallaNoIniciada()
        //La batalla no puede iniciar faltan personajes, por lo tanto el bool queda en falso
    {
        Hero enano = new GoodDwarf("Genaro");
        Encounters encuentrodistinto = new Encounters();
        encuentrodistinto.AddHeroe(enano);
        encuentrodistinto.DoEncounter();
        bool valordebatallaesperada = false;
        Assert.AreEqual(valordebatallaesperada, encuentrodistinto.batallainiciada);
    }

    [Test]
    public void BatallaIniciada()
        //La batalla se puede iniciar, cambiando el bool
    {
        Hero baltazar = new GoodWizard("Baltasar");
        Hero sombra = new GoodArcher("Sombra");
        Enemy guerrerooscuro = new EvilKnight("GuerreroOscuro", 10);
        Encounters batallaEpica = new Encounters();
        batallaEpica.AddHeroe(baltazar);
        batallaEpica.AddHeroe(sombra);
        batallaEpica.AddEnemy(guerrerooscuro);
        batallaEpica.DoEncounter();
        bool resultadoEsperado = true;
        Assert.AreEqual(resultadoEsperado, batallaEpica.batallainiciada);
    }

    [Test]
    public void TestAtaqueAcumulado()
    {
        //Verificamos aún puede acumular ataque agregandole armas de atacas
        Hero Batman = new GoodKnight("Batman"); //Ya tiene 40 de ataque al crearlo
        Batman.AddItem(new Axe()); // El acha tiene 50 de ataque
        int ataqueEsperado = 90; // 50 + 40 
        Assert.AreEqual(ataqueEsperado, Batman.AttackValue);
    }
    

    
    [Test]
    public void TestCura() // Testeo que el héroe se cure tras vencer a un enemigo
    {
        int vidaEsperada = 100;
        int vidaReal = caballerobueno2.Health;
        
        Assert.AreEqual(vidaEsperada, vidaReal);

    }

    [Test]
    public void TestperdidadeVP() // Testeo que el heroe haya perdido 5 vp tras curarse
    {
        int vpEsperados = 1;
        int vpReales = caballerobueno2.GetVp();
        Assert.AreEqual(vpEsperados, vpReales); //el heroe perdió 5vp y se quedó con 1

    }
    [Test]
    public void TestMismoVP() // Testeo que el caballero2 a pesar de haber contribuido en la pelea, no se quedó con los vp del enemigo 
    {
        int vpEsperados = 0;
        int vpReales = caballerobueno1.GetVp();
        
        Assert.AreEqual(vpEsperados, vpReales); //El caballero2 se mantuvo con sus 0 vp
    }
    [Test]
    public void TestSumadeVP() //Testeo para ver que al derrotar a más de un enemigo, se suman los vp
    {
        int vpEsperados = 3;
        int vpReales = caballerobueno3.GetVp();
        
        Assert.AreEqual(vpEsperados, vpReales); //El caballero3 tiene en total 3 de vp por haber derrotado a los 2 enemigos
    }
    [Test]
    public void TestNoCura() // Testeo que el caballero1 no se puede curar si tiene menos de 5 vp, (tendría 100 de vida sino)
    {
        int vidaEsperada = 90;
        int vidaReal = caballerobueno3.Health;
        
        Assert.AreEqual(vidaEsperada, vidaReal);
    }
}

