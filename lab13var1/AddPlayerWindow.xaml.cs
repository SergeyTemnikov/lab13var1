using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace lab13var1
{
    /// <summary>
    /// Логика взаимодействия для AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {

        FootballEntities db;
        byte[] image;

        public AddPlayerWindow(FootballEntities db)
        {
            InitializeComponent();
            this.db=db;

            cmbTeams.ItemsSource = db.Teams.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txbSurname.Text.Length == 0 ||
                txbName.Text.Length == 0 ||
                txbFathername.Text.Length == 0 ||
                txbNumber.Text.Length == 0 ||
                dpBirth.Text.Length == 0 ||
                cmbTeams.SelectedIndex == -1) 
            {
                MessageBox.Show("Не все данные введены!");
            }

            int number = 0;
            try
            {
                number = int.Parse(txbNumber.Text);
            }
            catch
            {
                MessageBox.Show("Номер введен неправильно!");
                return;
            }

            Players player = new Players();

            player.Surname = txbSurname.Text;
            player.Name = txbName.Text;
            player.FatherName = txbFathername.Text;
            player.Birthday = dpBirth.DisplayDate;
            player.PhoneNumber = number;
            player.Teams = cmbTeams.SelectedValue as Teams;
            player.Photo = image;

            try
            {
                db.Players.Add(player);
                db.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось записать игрока");
            }

        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                image = File.ReadAllBytes(openFile.FileName);
                imgPplayer.Source = new ImageSourceConverter().ConvertFrom(openFile.FileName) as ImageSource;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
