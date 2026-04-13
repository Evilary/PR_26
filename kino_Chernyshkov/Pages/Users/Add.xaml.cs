using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using kino_Chernyshkov.Classes;

namespace kino_Chernyshkov.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public ClubsContext AllClub = new ClubsContext();
        Main Main;
        Models.Users Users;
        public Add(Main main, Models.Users user = null)
        {
            InitializeComponent();
            this.Main = main;
            foreach (Models.Clubs Club in AllClub.Clubs)
                Clubs.Items.Add(Club.Name);
            Clubs.Items.Add("Выберите...");

            if (user != null )
            {
                this.Users = user;
                this.FIO.Text = user.FIO;
                this.RentStart.Text=user.RentStart.ToString("yyyy-MM-dd");
                this.RentTime.Text=user.RentStart.ToString("HH:mm");
                this.Duration.Text = user.Duration.ToString();
                Clubs.SelectedItem = AllClub.Clubs.Where(x => x.Id == user.IdClub).First().Name;
                BtnAdd.Content = "Изменить";
            }
            
        }

        private void AddUser(object sender, System.Windows.RoutedEventArgs e)
        {
            DateTime DTRentStart = new DateTime();
            DateTime.TryParse(this.RentStart.Text, out DTRentStart);
            DTRentStart = DTRentStart.Add(TimeSpan.Parse(this.RentTime.Text));
            if (this.Users == null)
            {
                Users = new Models.Users();
                Users.FIO = this.FIO.Text;
                Users.RentStart = DTRentStart;
                Users.Duration = Convert.ToInt32(this.Duration.Text);
                Users.IdClub = AllClub.Clubs.Where(x => x.Name == Clubs.SelectedItem).First().Id;
                this.Main.AllUsers.Users.Add(Users);    

            }
            else
            {
                Users.FIO = this.FIO.Text;
                Users.RentStart = DTRentStart;
                Users.Duration = Convert.ToInt32(this.Duration.Text);
                Users.IdClub = AllClub.Clubs.Where(x => x.Name == Clubs.SelectedItem).First().Id;

            }

            this.Main.AllUsers.SaveChanges();
            MainWindow.init.OpenPages(new Pages.Users.Main());
        }
    }
}
