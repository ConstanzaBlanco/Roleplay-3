using Library.Encounters;
using Ucu.Poo.RoleplayGame;

namespace SpellsBookTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AgregarHechizoALibro()
    {
        ISpell Hechizo1 = new SpellOne();
        SpellsBook Librito = new SpellsBook();
        Librito.AddSpell(Hechizo1);
        List<ISpell> listadelibritos = Librito.GetLista();
        bool resultadoesperado = listadelibritos.Contains(Hechizo1);
        Assert.IsTrue(resultadoesperado);
    }

    [Test]
    public void EliminarHechizoALibro()
    {
        ISpell Hechizo2 = new SpellOne();
        SpellsBook Librito1 = new SpellsBook();
        Librito1.AddSpell(Hechizo2);
        Librito1.RemoveSpell(Hechizo2);
        List<ISpell> listadelibritos = Librito1.GetLista();
        bool resultadoesperado = listadelibritos.Contains(Hechizo2);
        Assert.IsFalse(resultadoesperado);
    }

    [Test]
    public void ConocerLaDefensaDeLibro()
    {
        ISpell Hechizo3 = new SpellOne();
        ISpell Hechizo4 = new SpellOne();
        SpellsBook Librito2 = new SpellsBook();
        Librito2.AddSpell(Hechizo4);
        Librito2.AddSpell(Hechizo3);
        int defensalibrito2 = Librito2.DefenseValue;
        int defensaesperada = 140;
        Assert.AreEqual(defensalibrito2,defensaesperada);
    }

    [Test]
    public void ConocerElAtaqueDeLibro()
    {
        ISpell Hechizo5 = new SpellOne();
        ISpell Hechizo6 = new SpellOne();
        SpellsBook Librito3 = new SpellsBook();
        Librito3.AddSpell(Hechizo5);
        Librito3.AddSpell(Hechizo6);
        int ataquelibrito3 = Librito3.AttackValue;
        int ataqueesperado = 140;
        Assert.AreEqual(ataquelibrito3,ataqueesperado);
    }

    [Test]
    public void EncuentroDeMagoUtilizandoLibro()
    {
        ISpell Hechizo7 = new SpellOne();
        ISpell Hechizo8 = new SpellOne();
        SpellsBook Librito4 = new SpellsBook();
        Librito4.AddSpell(Hechizo7);
        Librito4.AddSpell(Hechizo8);
        GoodWizard Mago = new GoodWizard("Gandalf");
        EvilWizard MagoMalo = new EvilWizard("Dobby",10);
        MagoMalo.AddItem(Librito4);
        Encounters encuentro = new Encounters();
        encuentro.AddHeroe(Mago);
        encuentro.AddEnemy(MagoMalo);
        encuentro.DoEncounter();
        int estadodevidademagoesperado = 0;
        int estadodevidaobtenido = Mago.Health;
        Assert.AreEqual(estadodevidademagoesperado,estadodevidaobtenido);

    }
}