namespace JeuxOlympiques
{
    public partial class frmCourse : Form
    { 
        /// Auteur:Hugo St-Louis
        /// Description: Ensemble de requêtes qui permettent de déterminer qui gagne la course.
        /// Date: 21/01/2023
        /// </summary>
        //Liste des contrôles images pour déplacer les coureurs. Cette liste ne doit pas être utilisé par les étudiants.    {
        /// <summary>

        private TranspControl.TranspControl[] _tabImageCoureurs = new TranspControl.TranspControl[5];

        public frmCourse()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            //_tabImageCoureurs[0] = tcCoureur1;
            //_tabImageCoureurs[1] = tcCoureur2;
            //_tabImageCoureurs[2] = tcCoureur3;
            //_tabImageCoureurs[3] = tcCoureur4;
            //_tabImageCoureurs[4] = tcCoureur5;

            //ENLEVER CE CODE DES COMMENTAIRES
            // _coureurs = new JeuxOlympiqueEntities();
        }

        private void btnRequete1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("asdfasd");
            //Q1. Trouver les coureurs dont le nom contient un "o".
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;


            //Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);

        }

        /// <summary>
        /// Exécute la requête #2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete2_Click(object sender, EventArgs e)
        {
            //Q2. Trouver les coureurs ayant fait au moins cinq(5) records.
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;


            //Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
        }

        /// <summary>
        /// Exécute la requête #3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete3_Click(object sender, EventArgs e)
        {
            //Q3. trouver le coureur qui a le meilleur record.
            //Compléter la requête.

            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            //Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);

        }

        /// <summary>
        /// Exécute la requête #4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete4_Click(object sender, EventArgs e)
        {
            //Q4. Trouver les coureurs qui ont deux records en haut de la moyenne des temps.


            ////Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
        }

        /// <summary>
        /// Exécute la requête #5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete5_Click(object sender, EventArgs e)
        {
            //Q5. Trouver les deux coureurs ayant les meilleurs records.
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
        }

        /// <summary>
        /// Exécute la requête #6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete6_Click(object sender, EventArgs e)
        {
            //Q6. Trouver les coureurs qui sont entrainé par "John Deer"
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
        }

        /// <summary>
        /// Exécute la requête #7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete7_Click(object sender, EventArgs e)
        {
            //Q7. Trouver les coureurs qui ont le commanditaire le plus payant.
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
            //_tabImageCoureurs[0].BackImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// Exécute la requête #8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete8_Click(object sender, EventArgs e)
        {
            //Q8. Trouver les coureurs qui proviennent du "Canada".
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
        }

        /// <summary>
        /// Exécute la requête #9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete9_Click(object sender, EventArgs e)
        {
            //Q9. Trouver le coureur qui a le plus d'argent provenant des commanditaires.
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);

        }

        /// <summary>
        /// Exécute la requête #10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete10_Click(object sender, EventArgs e)
        {
            //Q10. Trouver le coureur dont la somme des records est le plus bas.
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);

        }

        /// <summary>
        /// Exécute la requête #11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete11_Click(object sender, EventArgs e)
        {
            //Q11. Trouver le coureur du "Canada" qui a le meilleur record.
            ////Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);

        }

        /// <summary>
        /// Exécute la requête #12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete12_Click(object sender, EventArgs e)
        {
            //Q12. Trouver le coureur qui est commandité par "Adidas".
            //Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);

        }

        /// <summary>
        /// Exécute la requête #13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequete13_Click(object sender, EventArgs e)
        {
            //Q13 Trouver le coureur qui a le plus d'entraineurs.
            ////Compléter la requête.
            //var req = from coureur in _coureurs.Coureurs
            //          select coureur;

            ////Déplace le coureur en fonctionne 
            //DeplacerCoureur(req);
            //DeterminerGagnant();
        }

        /// <summary>
        /// Permet de déplacer les images en fonction des réponses des requêtes
        /// </summary>
        /// <param name="req"></param>
        //private void DeplacerCoureur(IEnumerable<Coureur> req)
        //{

        //    foreach (Coureur c in req)
        //        _tabImageCoureurs[c.Id - 1].Location = new Point(_tabImageCoureurs[c.Id - 1].Location.X + 150, _tabImageCoureurs[c.Id - 1].Location.Y);
        //}

        /// <summary>
        /// Détermine le gagnant
        /// </summary>
        private void DeterminerGagnant()
        {
            int maxPosition = 0;
            TranspControl.TranspControl tcMax = null;
            foreach (TranspControl.TranspControl tc in _tabImageCoureurs)
            {
                if (maxPosition < tc.Location.X)
                {
                    tcMax = tc;
                    maxPosition = tc.Location.X;
                }
            }

            string index = tcMax.Name.Substring(tcMax.Name.Length - 2);
            int valeur = 0;
            bool isNum = int.TryParse(index, out valeur);
            if (!isNum)
            {
                index = tcMax.Name.Substring(tcMax.Name.Length - 1);
                isNum = int.TryParse(index, out valeur);
                if (!isNum)
                    valeur = 0;
            }

            //var req = from coureur in _coureurs.Coureurs
            //          where coureur.Id == valeur
            //          select coureur.Prenom + " " + coureur.Nom + " du pays " + coureur.Pays;
            //foreach (string s in req)
            //    MessageBox.Show("La gagnante est " + s);

        }
    }
}