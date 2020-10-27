using System;

namespace App_Gestion_reparation
{
    public class ReparationPhone
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string ModelPhone {get;set;}
        public string Mobil { get; set; }
        public string Email { get; set; }
        public DateTime DateRecue { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string PrixReparation { get; set; }

        public ReparationPhone(string Nom, string Prenom, string ModelPhone, string Mobil, string Email, DateTime DateRecue, string Description, string Status, string PrixReparation)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.ModelPhone = ModelPhone;
            this.Mobil = Mobil;
            this.Email = Email;
            this.DateRecue = DateRecue;
            this.Description = Description;
            this.Status = Status;
            this.PrixReparation = PrixReparation;
        }

        public ReparationPhone()
        {
        }
    }
}
