namespace JeuxOlympiques2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new _4dbJeuxOlympiqueContext())
            {
                
                // Q1 Coureur dont le nom contient un "o"
                var coureurs = context.Coureurs.Where(coureur => coureur.Nom.Contains("o")).ToList();
                Console.WriteLine("---Q1---");
                foreach(Coureur c in coureurs)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }


                // Q2 coureur avec au moins 5 records
                var coureurs_records = context.Coureurs.Where(coureur => coureur.Records.Count >= 5).ToList();
                Console.WriteLine("---Q2---");
                foreach(Coureur c in coureurs_records)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }

                //Q3 Coureur avec le meilleur record
                var coureur_meilleur_record = context.Coureurs.Where(coureur => coureur.Records.Count > 0).OrderBy(r => r.Records.Min(s => s.Record1)).First();

                //var coureur_meilleur_record = context.Coureurs.Where(coureur => coureur.Records.Count > 0).OrderBy(c => c.Records.OrderBy(r => r.Record1).Select(r => r.Record1).First());
                Console.WriteLine("---Q3---");
                Console.WriteLine(coureur_meilleur_record.Prenom + "\t" + coureur_meilleur_record.Nom);


                //Q4 Coureurs avec au moins deux records en haut de la moyenne des temps
                var coureurs_records_moyenne = context.Coureurs.Where(coureur => coureur.Records.Count(r => r.Record1 > context.Records.Average(r => r.Record1)) >= 2).ToList();
                Console.WriteLine("---Q4---");
                foreach (Coureur c in coureurs_records_moyenne)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }

                //Q5 Deux coureurs avec les meilleurs records
                var coureurs_meilleurs_records = context.Coureurs.Where(coureur => coureur.Records.Count > 0).OrderBy(r => r.Records.Min(s => s.Record1)).Take(2).ToList();
                Console.WriteLine("---Q5---");
                foreach (Coureur c in coureurs_meilleurs_records)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }

                //Q6 Coureurs qui sont entrainés par "John Deer"
                var coureurs_entraines = context.Coureurs.Where(coureur => coureur.IdEntraineurs.Any(e => e.Nom == "Deer" && e.Prenom == "John")).ToList();
                Console.WriteLine("---Q6---");
                foreach (Coureur c in coureurs_entraines)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }

                //Q7 coureurs qui ont le commanditaire le plus payant
                var coureurs_commanditaires = context.Coureurs.Where(coureur => coureur.IdCommenditaires.Count > 0).OrderByDescending(c => c.IdCommenditaires.Max(s => s.CommanditeParCoureur)).ToList();
                Console.WriteLine("---Q7---");
                foreach (Coureur c in coureurs_commanditaires)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }

                //Q8 coureurs qui proviennent du "Canada"
                var coureurs_canadiens = context.Coureurs.Where(coureur => coureur.Pays == "Canada").ToList();
                Console.WriteLine("---Q8---");
                foreach (Coureur c in coureurs_canadiens)
                {
                    Console.WriteLine(c.Prenom + "\t" + c.Nom);
                }

                //Q9 coureur qui a le plus d'argent provenant des commanditaires
                var coureur_plus_argent = context.Coureurs.Where(coureur => coureur.IdCommenditaires.Count > 0).OrderByDescending(c => c.IdCommenditaires.Sum(s => s.CommanditeParCoureur)).First();
                Console.WriteLine("---Q9---");
                Console.WriteLine(coureur_plus_argent.Prenom + "\t" + coureur_plus_argent.Nom);

                //Q10 coureur dont la somme des records est le plus bas
                var coureur_plus_bas = context.Coureurs.Where(coureur => coureur.Records.Count > 0).OrderBy(c => c.Records.Sum(s => s.Record1)).First();
                Console.WriteLine("---Q10---");
                Console.WriteLine(coureur_plus_bas.Prenom + "\t" + coureur_plus_bas.Nom);

                //Q11 coureur du "Canada" qui a le meilleur record
                var coureur_canadien_meilleur_record = context.Coureurs.Where(coureur => coureur.Pays == "Canada" && coureur.Records.Count > 0).OrderBy(r => r.Records.Min(s => s.Record1)).First();
                Console.WriteLine("---Q11---");
                Console.WriteLine(coureur_canadien_meilleur_record.Prenom + "\t" + coureur_canadien_meilleur_record.Nom);

                //Q12 coureur qui est commandité par "Adidas"
                var coureur_commandite = context.Coureurs.Where(coureur => coureur.IdCommenditaires.Any(c => c.Nom == "Adidas")).First();
                Console.WriteLine("---Q12---");
                Console.WriteLine(coureur_commandite.Prenom + "\t" + coureur_commandite.Nom);


                //Q13 coureur qui a le plus d'entraineurs
                var coureur_plus_entraineurs = context.Coureurs.Where(coureur => coureur.IdEntraineurs.Count > 0).OrderByDescending(c => c.IdEntraineurs.Count).First();
                Console.WriteLine("---Q13---");
                Console.WriteLine(coureur_plus_entraineurs.Prenom + "\t" + coureur_plus_entraineurs.Nom);


            }


        }
    }
}
