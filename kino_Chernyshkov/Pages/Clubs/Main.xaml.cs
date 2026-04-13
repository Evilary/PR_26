
using System.Windows.Controls;
using kino_Chernyshkov.Classes;

namespace kino_Chernyshkov.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public ClubsContext AllClub = new ClubsContext();
        public Main()
        {
            InitializeComponent();
            foreach (Models.Clubs Club in AllClub.Clubs)
                Parent.Children.Add(new Elements.Item(Club, this));
        }

        private void AddClub(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this));
    }
}
