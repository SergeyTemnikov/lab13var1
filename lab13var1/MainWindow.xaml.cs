using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab13var1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        FootballEntities db = new FootballEntities();

        public MainWindow()
        {
            InitializeComponent();

            dgTeams.ItemsSource = db.Teams.ToList();
        }

        private void dgTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgPlayers.ItemsSource = null;
            var team = dgTeams.SelectedValue as Teams;
            dgPlayers.ItemsSource = db.Players.Where(x => x.IdTeam == team.IdTeam).ToList();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow window = new AddPlayerWindow(db);
            window.ShowDialog();
            dgPlayers.ItemsSource = null;
        }

        private void btnSeeMatches_Click(object sender, RoutedEventArgs e)
        {
            var player = dgPlayers.SelectedValue as Players;
            PlayerMatchesWindow window = new PlayerMatchesWindow(db, player);
            window.ShowDialog();
        }

        private void dgPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var player = dgPlayers.SelectedValue as Players;
            PlayerMatchesWindow window = new PlayerMatchesWindow(db, player);
            window.ShowDialog();
        }
    }
}
