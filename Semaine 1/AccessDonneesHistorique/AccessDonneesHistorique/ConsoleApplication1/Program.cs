using ConsoleApplication1.dsProgEFTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        public static void DataSet1_0(string firstName)
        {
            string strConnexion = "Data Source = 172.16.20.230; Initial Catalog=4DB_PROGRAMMINGEFDB1; Integrated Security = False; User ID = Etudiant; Password = Qwerty123!; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string strRequete = " SELECT * " + 
                                " FROM Contact " + 
                                " WHERE FIRSTNAME = '" + firstName + 
                               "' ORDER BY FirstName";
            SqlDataReader rdr = null;
        }

        public static void MonMain()
        {
            DataSet1_0("Hugo'; DROP DATABASE; SELECT * FROM CONTACT ");


        }
            /// <summary>
            /// Utilisation de la méthode d'accès aux données de .Net 1.0
            /// </summary>
        public static void DataSet1_0()
        {
            string strConnexion = "Data Source = 172.16.20.230; Initial Catalog=4DB_PROGRAMMINGEFDB1; Integrated Security = False; User ID = Etudiant; Password = Qwerty123!; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string strRequete = "SELECT * FROM Contact ORDER BY FirstName";
            SqlDataReader rdr = null;

            try
            {
                SqlConnection oConnection = new SqlConnection(strConnexion);
                oConnection.Open();
                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(strRequete, oConnection);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " " + rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString());
                }
                              
                oConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + e.Message);
            }

        }

        /// <summary>
        /// Utilisation de la méthode d'accès aux données de .Net 1.1
        /// </summary>
        public static void DataSet1_1()
        {
            string strConnexion = "Data Source = 172.16.20.230; Initial Catalog=4DB_PROGRAMMINGEFDB1; Integrated Security = False; User ID = Etudiant; Password = Qwerty123!; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection oConnection = new SqlConnection(strConnexion);
            SqlCommand sqlRequete = new SqlCommand( "SELECT * FROM Contact ORDER BY FirstName", oConnection);

            try
            {
                oConnection.Open();
                
                // Chargement de la liste des catégories dans oDataSet
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();

                oSqlDataAdapter.SelectCommand = sqlRequete;
                

                DataSet oDataSet = new DataSet("Contact");
                oSqlDataAdapter.Fill(oDataSet, "Contact");

                // Affichage du contenu de oDataSet avant insertion de données

                Console.WriteLine(" *** Liste des Contact avant la mise à jour *** ");
                for (int i = 0; i < oDataSet.Tables["Contact"].Rows.Count; i++)
                {
                    Console.WriteLine("\t{0}\t{1}", oDataSet.Tables["Contact"].Rows[i][0].ToString(), oDataSet.Tables["Contact"].Rows[i][1].ToString());
                }
                Console.WriteLine("\n");
                
                //// Remplissage de la commande InsetCommand
                oSqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Contact(FirstName, LastName, Title, AddDate, ModifiedDate, Age) Values(@FirstName,@LastName,@Title, @AddDate, @ModifiedDate, @Age)", oConnection);
                oSqlDataAdapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).SourceColumn = "FirstName";
                oSqlDataAdapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).SourceColumn = "LastName";
                oSqlDataAdapter.InsertCommand.Parameters.Add("@Title", SqlDbType.NVarChar).SourceColumn = "Title";
                oSqlDataAdapter.InsertCommand.Parameters.Add("@AddDate", SqlDbType.DateTime).SourceColumn = "AddDate";
                oSqlDataAdapter.InsertCommand.Parameters.Add("@ModifiedDate",  SqlDbType.DateTime).SourceColumn = "ModifiedDate";
                oSqlDataAdapter.InsertCommand.Parameters.Add("@Age", SqlDbType.Int).SourceColumn = "Age";

                DataRow oDataRow = oDataSet.Tables["Contact"].NewRow();
                oDataRow["FirstName"] = "Hortense";
                oDataRow["LastName"] = "Lamothe";
                oDataRow["Title"] = "Mrs";
                oDataRow["AddDate"] = DateTime.Now;
                oDataRow["ModifiedDate"] = DateTime.Now;
                oDataRow["Age"] = 64;


                oDataSet.Tables["Contact"].Rows.Add(oDataRow);

                // Mise à jour de la source de données à partir du DataSet
                oSqlDataAdapter.Update(oDataSet, "Contact");
                // Rechargement des données de la source mise à jour
                oDataSet.Clear();
                oSqlDataAdapter.Fill(oDataSet, "Contact");

                // Affichage du contenu de oDataSet après insertion d'une ligne de données
                Console.WriteLine(" *** Liste des Contact après la mise à jour *** ");
                for (int i = 0; i < oDataSet.Tables["Contact"].Rows.Count; i++)
                {
                    Console.WriteLine("\t{0}\t{1}", oDataSet.Tables["Contact"].Rows[i][0].ToString(), oDataSet.Tables["Contact"].Rows[i][1].ToString());
                }

                oConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + e.Message);
            }

        }

        /// <summary>
        /// Accès aux données .Net 2.0
        /// </summary>
        public static void DataSetTypeAdapter2_0()
        {
            ContactTableAdapter ct = new ContactTableAdapter();
            //Ajouter un contact
            ct.Insert("Hugo", "St-Louis", "Mr", DateTime.Now, DateTime.Now);
            dsProgEF.ContactDataTable dtEF = new dsProgEF.ContactDataTable();
            ct.Fill(dtEF);
              
            foreach (dsProgEF.ContactRow c in dtEF.Rows)
                Console.WriteLine(c.FirstName +  " " + c.LastName );
            EnumerableRowCollection<dsProgEF.ContactRow> Contactrows =
                dtEF.AsEnumerable().Where(x => x.FirstName == "Hugo");
            foreach (DataRow dr in Contactrows)
                Console.WriteLine(dr[0] );
            
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DataSet1_0();
            DataSet1_1();
            DataSetTypeAdapter2_0();
        }
    }

}
