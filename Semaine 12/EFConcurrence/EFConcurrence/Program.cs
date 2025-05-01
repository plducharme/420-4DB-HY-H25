using Microsoft.EntityFrameworkCore;

namespace EFConcurrence
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            using (var context = new JeuxDBContext())
            {
                Console.WriteLine("Suppression du data existant");
              
                // context.Database.EnsureDeleted();
                // context.Database.EnsureCreated();

                var editeur = new Editeur { 
                    Nom = "Bethesda", 
                    Id = 1 , 
                    Pays = "USA"
                };
                context.Editeurs.Add(editeur);
                Console.WriteLine("Insertion de data");
                context.SaveChanges();
                var jeu = new Jeu
                {
                    Nom = "Oblivion: Remastered",
                    Description = "Oblivion avec UE5",
                    EditeurId = editeur.Id
                };
                context.Jeux.Add(jeu);
                context.SaveChanges();

                Console.WriteLine("Modification concurrente");
                List<Thread> threads = new List<Thread>();


                for (int i = 0; i < 50; i++)
                {
                    int threadId = i;
                    var thread = new Thread(() => new Program().modifierJeu(new JeuxDBContext(), jeu.Id, threadId));
                    threads.Add(thread);
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                jeu = context.Jeux.Find(jeu.Id);
                if (jeu != null)
                {
                    Console.WriteLine($"Jeu après modification : {jeu.Nom} - {jeu.Description}");
                }
                else
                {
                    Console.WriteLine("Le jeu n'existe pas.");
                }

            }

        }

        private void modifierJeu(JeuxDBContext context, int id, int threadId)
        {
            var jeu = context.Jeux.Find(id);
            if (jeu != null)
            {
                Console.WriteLine($"Thread {threadId} : Modification du jeu {jeu.Nom}");
                jeu.Nom = "Oblivion: Remastered";
                jeu.Description = "Oblivion avec UE5 " + threadId.ToString();
                context.SaveChanges();
            }
        }
    }
}
