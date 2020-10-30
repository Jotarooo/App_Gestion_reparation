using App_Gestion_reparation.Metier;
using System;

namespace App_Gestion_reparation
{
    public class ReparationPhone : BindableBase
    {
        public int Id { get; set; }
        private string nom;
        public string Nom
        {
            get
            {
                return this.nom;
            }
            set {
                SetProperty(ref this.nom, value);
            }
        }
 
        public string Prenom { get; set; }
        public string ModelPhone {get;set;}
        public string Mobil { get; set; }
        public string Email { get; set; }
        public DateTime DateRecue { get; set; }
        public DateTime DateRetour { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string PrixReparation { get; set; }

        public ReparationPhone(string Nom, string Prenom, string ModelPhone, string Mobil, string Email,string Description, string Status, string PrixReparation)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.ModelPhone = ModelPhone;
            this.Mobil = Mobil;
            this.Email = Email;
            this.DateRecue = DateTime.Now;
            this.DateRetour = this.DateRecue.AddDays(7);
            this.Description = Description;
            this.Status = Status;
            this.PrixReparation = PrixReparation;
        }               
    }
}
