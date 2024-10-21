using Ucu.Poo.RoleplayGame;

namespace Library.Encounters;

public class Encounters
{
    private List<Hero> listadeheroes = new List<Hero>();
    private List<Enemy> listadeenemigos = new List<Enemy>();
    private bool batallainiciada;
    private bool batallaterminada;

    public Encounters()
    {
        batallainiciada = false;
        batallaterminada = false;

    }

    public void DoEncounter()
    {
        if (listadeheroes.Count > 0 && listadeenemigos.Count > 0)
        {
            Console.WriteLine("");
            batallainiciada = true;
            while (!batallaterminada)
            {
                for (int i = 0; i < listadeenemigos.Count && listadeheroes.Count > 0; i++) //Asi evitamos el throw exception de divisibilidad entre 0
                {
                    Enemy enemigoactual = listadeenemigos[i];
                    int numeroatacante = i % listadeheroes.Count;
                    Hero heroeactual = listadeheroes[numeroatacante];
                    Console.WriteLine($"{enemigoactual.Name} ha atacado a {heroeactual.Name}");
                    heroeactual.ReceiveAttack(enemigoactual.AttackValue);
                    if (!heroeactual.IsAlive())
                    {
                        listadeheroes.Remove(heroeactual);
                    }
                    Console.WriteLine("");
                }

                RevisarCondiciones();
                if (batallaterminada)
                {
                    break;
                }

                for (int i = 0; i < listadeheroes.Count && listadeenemigos.Count > 0; i++) //Asi evitamos el throw exception de que no llegue a ser 0 el divisor
                {
                    Hero heroeactual = listadeheroes[i];
                    int numeroatacante = i % listadeenemigos.Count;
                    Enemy enemigoactual = listadeenemigos[numeroatacante];
                    Console.WriteLine($"{heroeactual.Name} ha atacado a {enemigoactual.Name}");
                    enemigoactual.ReceiveAttack(heroeactual.AttackValue);
                    if (!enemigoactual.IsAlive())
                    {
                        listadeenemigos.Remove(enemigoactual);
                        heroeactual.ModifyVp(enemigoactual.GetVp());
                        if (heroeactual.GetVp() >= 5)
                        {
                            heroeactual.Cure();
                            heroeactual.ModifyVp(-5); //Le retiro 5 vps por curarse
                        }
                    }
                    Console.WriteLine("");
                }
                RevisarCondiciones();
            }
            Console.WriteLine("El encuentro ha terminado");
            if (listadeheroes.Count > 0)
            {
                Console.WriteLine("Ha ganado el equipo de los heroes");
            }
            else
            {
                Console.WriteLine("Ha ganado el equipo enemigo");
            }
        }
        else
        {
            Console.WriteLine("No se cuenta con los miembros necesarios para hacer la batalla");
        }
    }

    private void RevisarCondiciones()
    {
        bool malosvivos = false;
        for (int i = 0; i < listadeenemigos.Count; i++)
        {
            if (listadeenemigos[i].IsAlive())
            {
                malosvivos = true;
                break;
            }
        }

        bool heroesvivos = false;
        for (int i = 0; i < listadeheroes.Count; i++)
        {
            if (listadeheroes[i].IsAlive())
            {
                heroesvivos = true;
                break; 
            }
        }
        batallaterminada = !(heroesvivos && malosvivos);
    }

    
    public void AddHeroe(Hero heroe)
    {
        listadeheroes.Add(heroe);
    }
    
    public void AddEnemy(Enemy enemigo)
    {
        listadeenemigos.Add(enemigo);
    }
}
