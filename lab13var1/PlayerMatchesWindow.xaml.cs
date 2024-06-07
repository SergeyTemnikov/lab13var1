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
using System.Windows.Shapes;

namespace lab13var1
{
    /// <summary>
    /// Логика взаимодействия для PlayerMatchesWindow.xaml
    /// </summary>
    public partial class PlayerMatchesWindow : Window
    {

        FootballEntities db;
        Players player;

        public PlayerMatchesWindow(FootballEntities db, Players player)
        {
            InitializeComponent();
            this.db=db;
            this.player = player;

            var playerMatches = db.Matches.Where(x => x.HomeTeam == player.IdTeam || x.GuestTeam == player.IdTeam).ToList();
            dgMatches.ItemsSource = playerMatches;

            txtName.Text += player.Name + "(" + player.Teams.Name + ")";
            txtMatchesCount.Text += playerMatches.Count();
            
        }
    }
}
