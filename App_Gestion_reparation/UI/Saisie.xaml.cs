using System;
using App_Gestion_reparation.Metier;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace App_Gestion_reparation.UI
{
    /// <summary>
    /// Interaction logic for Saisie.xaml
    /// </summary>
    public partial class Saisie : Window
    {
        private ReparationPhone reparationPhone;
        public bool EditMode = true;
        

        /**
* création client
*/
        public Saisie()
        {
            InitializeComponent();
            
            this.reparationPhone = new ReparationPhone();
            this.DataContext = reparationPhone; 
        }

        public Saisie(ReparationPhone phone)
        {
            this.EditMode = true;
        
            InitializeComponent();

            this.reparationPhone = phone;
            this.DataContext = reparationPhone;
        }


        public void save_Click(object sender, RoutedEventArgs e)
        {
            this.reparationPhone.Nom = nom.Text;
            this.reparationPhone.ModelPhone =  modeleTelephone.Text;
            this.reparationPhone.Mobil = vini.Text;
            this.reparationPhone.Email = email.Text;
            this.reparationPhone.Description = description.Text;
            this.reparationPhone.Status = status.Text;
            this.reparationPhone.PrixReparation = prix.Text;

            if (EditMode == false)
            {
                ReparationPhoneAccess.InsertReparation(reparationPhone);
                Business.ReparationPhones.Add(reparationPhone);                
            }
            else
            {
                ReparationPhoneAccess.Modif(reparationPhone);
            }
           
        }

        private void fermer_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
