using Ucu.Poo.RoleplayGame;

namespace Library.Encounters;

public class Encounters
{
    private List<Character> listadeheroes = new List<Character>();
    private List<Character> listadeenemigos = new List<Character>();
    private bool turno;
    private bool batallainiciada;
    private bool batallaterminada;
    private Character EnemigoLugar1;
    private Character HeroeLugar1;
    private Random random;

    public Encounters()
    {
        turno = random.Next(2) == 0;
        
    }

    public void DoEncounter()
    {
        if (EnemigoLugar1 != null & HeroeLugar1 != null)
        {
            batallainiciada = true;
            while (!batallaterminada)
            {
                if (turno)
                {
                    EjecutarAccion(listadeheroes, listadeenemigos);
                }
                else
                {
                    // Turno de enemigos
                    EjecutarAccion(listadeenemigos, listadeheroes);
                }
                AvanzarTurno();
            }
        }
    }

    private void EjecutarAccion(List<Character> atacantes, List<Character> defensores)
    {
        int numero = random.Next(atacantes[0].Items.Count);
        IItem arma = atacantes[0].Items[numero];
        if (arma is IAttackItem armaataque)
        {
            defensores[0].ReceiveAttack(armaataque);
        }
        if (arma is IDefenseItem armadefensa)
        {
            atacantes[0].UseDefense(armadefensa);
        }
    }

    private void AvanzarTurno()
    {
        if (!RevisarCondiciones())
        {
            
        }
        turno = !turno;
    }

    private bool RevisarCondiciones()
    {
        if ()
    }
    
    public void AddHeroe(Hero heroe)
    {
        if (listadeheroes.Count < 1)
        {
            HeroeLugar1 = heroe;
        }
        listadeheroes.Add(heroe);
    }
    
    public void AddEnemy(Enemy enemigo)
    {
        if (listadeenemigos.Count < 1)
        {
            EnemigoLugar1 = enemigo;
        }
        listadeenemigos.Add(enemigo);
    }
}