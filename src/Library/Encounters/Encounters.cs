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
            batallainiciada = true;
            while (!batallaterminada)
            {
                for (int i = 0; i < listadeenemigos.Count; i++)
                {
                    Enemy enemigoactual = listadeenemigos[i];
                    int numeroatacante = i % listadeheroes.Count;
                    Hero heroeactual = listadeheroes[numeroatacante];
                    heroeactual.ReceiveAttack(enemigoactual.AttackValue);
                    if (!heroeactual.IsAlive())
                    {
                        listadeheroes.Remove(heroeactual);
                    }
                }

                RevisarCondiciones();
                if (batallaterminada)
                {
                    break;
                }

                for (int i = 0; i < listadeheroes.Count; i++)
                {
                    Hero heroeactual = listadeheroes[i];
                    int numeroatacante = i % listadeenemigos.Count;
                    Enemy enemigoactual = listadeenemigos[numeroatacante];
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
