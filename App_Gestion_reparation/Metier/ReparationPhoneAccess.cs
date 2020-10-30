using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Gestion_reparation.Metier
{
    class ReparationPhoneAccess
    {

        public static MySqlConnection connection;



        static ReparationPhoneAccess()
        {
            String connString = "Server=localhost;Database=reparation;userid=root;Pwd=";
            connection = new MySqlConnection(connString);
            //connection.Open();
        }



        public static void GetAllReparation()
        {

            // on prepare la requête
            String sql = "SELECT * FROM clients";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                // On exécute la requête
                using (DbDataReader dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        int Id = dbReader.GetInt32(0);
                        string Nom = dbReader.GetString(1);
                        string Prenom = dbReader.GetString(2);
                        string ModelePhone = dbReader.GetString(3);
                        string Mobil = dbReader.GetString(4);
                        string Email = dbReader.GetString(5);
                        DateTime DateRecu = dbReader.GetDateTime(6);
                        DateTime DateRetour = dbReader.GetDateTime(7);
                        string Description = dbReader.GetString(8);
                        string Status = dbReader.GetString(9);
                        string PrixReparation = dbReader.GetString(10);
                        ReparationPhone rep = new ReparationPhone(Nom, Prenom, ModelePhone, Mobil, Email, Description, Status, PrixReparation);
                        rep.Id = Id;
                        Business.ReparationPhones.Add(rep);
                    }
                }

                command.Connection.Close();
            }
        }

        public static bool InsertReparation(ReparationPhone r)
        {
            string sql = "INSERT INTO clients   (id,    Nom,    Prenom,     ModelePhone,    Mobil,  Email,              DateRecu,   DateRetour,     Description,    Status, PrixReparation)" +
                "VALUES                         (@id,   @nom,   @prenom,    @modeltelephone,          @mobil,  @email,  @daterecu,  @dateretour,    @description,   @status,@prixreparation)";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@nom", r.Nom);
                cmd.Parameters.AddWithValue("@prenom", r.Prenom);
                cmd.Parameters.AddWithValue("@modeltelephone", r.ModelPhone);
                cmd.Parameters.AddWithValue("@mobil", r.Mobil);
                cmd.Parameters.AddWithValue("@email", r.Email);
                cmd.Parameters.AddWithValue("@daterecu", r.DateRecue);
                cmd.Parameters.AddWithValue("@dateretour", r.DateRetour);
                cmd.Parameters.AddWithValue("@description", r.Description);
                cmd.Parameters.AddWithValue("@status", r.Status);
                cmd.Parameters.AddWithValue("@prixreparation", r.PrixReparation);


                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;
            }


        }

        public static bool Modif(ReparationPhone r)
        {
            string sql = "UPDATE clients SET  Nom = @nom, Prenom = @prenom, ModelePhone = @modeltelephone, Mobil = @mobil, Email = @email, DateRecu = @daterecu, DateRetour = @dateretour, Description = @description, Status = @status, PrixReparation = @prixreparation WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@id", r.Id);
                cmd.Parameters.AddWithValue("@nom", r.Nom);
                cmd.Parameters.AddWithValue("@prenom", r.Prenom);
                cmd.Parameters.AddWithValue("@modeltelephone", r.ModelPhone);
                cmd.Parameters.AddWithValue("@mobil", r.Mobil);
                cmd.Parameters.AddWithValue("@email", r.Email);
                cmd.Parameters.AddWithValue("@daterecu", r.DateRecue);
                cmd.Parameters.AddWithValue("@dateretour", r.DateRetour);
                cmd.Parameters.AddWithValue("@description", r.Description);
                cmd.Parameters.AddWithValue("@status", r.Status);
                cmd.Parameters.AddWithValue("@prixreparation", r.PrixReparation);


                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;
            }
        } 
    }
}
