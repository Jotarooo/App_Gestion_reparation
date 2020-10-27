using Microsoft.Win32;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace App_Gestion_reparation.Metier
{
    class Business
    {
        public static ObservableCollection<ReparationPhone> ReparationPhones { get; set; }

        static Business()
        {
            ReparationPhones = new ObservableCollection<ReparationPhone>();

            ReparationPhone Annie = new ReparationPhone("Pomme", "Annie", "Samsung", "87666666", "anniepomme@mail.com", DateTime.Now, "Chalala", "En cours", "20000");
            ReparationPhone Emma = new ReparationPhone("Digue", "Emma", "Huawei", "89364878", "emmadigue@mail.com", DateTime.Now, "Chalala", "Livraison", "10000");
            ReparationPhone George = new ReparationPhone("Doupe", "George", "Iphone", "87215689", "georgedoupe@mail.com", DateTime.Now, "Chalala", "Endommagé...", "0");

            ReparationPhones.Add(Annie);
            ReparationPhones.Add(Emma);
            ReparationPhones.Add(George);

        }

        public static void SaveFile(ObservableCollection<ReparationPhone> reparationPhones)
        {
            int Taille = reparationPhones.Count;
            string[] content = new string[Taille];
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            int conteur = 0;

            string csv = reparationPhones.ToCsv();
            Console.WriteLine(csv);

            foreach(ReparationPhone phone in reparationPhones) //pour chaque phone cad chaque ligne de clients dans la liste de reparaionPhone faire
            {
                string s = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", phone.Nom, phone.Prenom, phone.ModelPhone, phone.Mobil, phone.Email, phone.DateRecue, phone.Description, phone.Status, phone.PrixReparation);
                content[conteur] = s;
                Console.WriteLine(s);
                conteur++;
            } 
            


            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, content);
            }

           
        } 


    }
}
