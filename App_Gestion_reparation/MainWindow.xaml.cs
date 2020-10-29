using App_Gestion_reparation.Metier;
using App_Gestion_reparation.UI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_Gestion_reparation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml blandine14
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            ReparationPhoneAccess.GetAllReparation();
            reparerPhone.ItemsSource = Business.ReparationPhones;

        }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Saisie saisie = new Saisie();
            saisie.ShowDialog();
        }

        private void aPropos_Click(object sender, RoutedEventArgs e)
        {
            APropos aPropos = new APropos();
            aPropos.Show();
        }

        private void sauvegarder_Click(object sender, RoutedEventArgs e)//marche
        {
            Business.SaveFile(Business.ReparationPhones);
        }

        private void ouvrir_Click(object sender, RoutedEventArgs e)//pas encore fait pcq je veux pas imorter la liste mais plutot ouvrir l'appli et la liste est là.
        {
           // OpenFile();
        }

        public void reparerPhone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ReparationPhone item = reparerPhone.SelectedItem as ReparationPhone;
            //afficher le client dans les textbox de saisie
            

            Saisie modifierclient = new Saisie(item);
            modifierclient.Show();


            
        }

    }
    
}
