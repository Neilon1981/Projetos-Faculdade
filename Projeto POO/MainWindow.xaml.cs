using Projeto_POO.Scripts;
using Projeto_POO.Scripts.Plataform;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
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
using static System.Net.WebRequestMethods;

namespace Projeto_POO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Game> Games { get; set; } = new ObservableCollection<Game>();

        private List<Game> AllGames = new();

        public MainWindow()
        {
            InitializeComponent();

            Games.Add(new SuperNintendo
            {
                Name = "Super Mario World",
                Category = "Aventura",
                Plataform = GamePlataform.SuperNintendo,
                Description = "Super Mario World é um clássico do SNES em que Mario e Luigi exploram Dinosaur Land para salvar a Princesa Peach. O jogo introduz Yoshi e traz fases criativas cheias de segredos, sendo um dos plataformas mais influentes e lembrados dos videogames.",
                RunPath = "https://emulatorgamer.com/pt/games/super-mario-world/play",
                Size = 0.003,
                CoverPath = "UI/Images/Games/SNES/supermarioworld.jpg",
            });

            Games.Add(new Playstation2
            {
                Name = "Grand Theft Auto III",
                Category = "Ação / Mundo Aberto",
                Plataform = GamePlataform.PlaystationTwo,
                Description = "Grand Theft Auto III revolucionou os jogos de mundo aberto, colocando o jogador na cidade de Liberty City em uma experiência livre de exploração, missões criminais e narrativa não linear. Foi o primeiro GTA totalmente 3D, marcando uma nova era para a franquia.",
                Size = 1,
                CoverPath = "UI/Images/Games/PS2/gta3.jpg",
                Installed = false
            });
            //Set all categories in combobox
            Videogames.ItemsSource = Enum.GetValues(typeof(GamePlataform));
            Videogames.SelectedItem = GamePlataform.PlaystationOne;

            Games = new ObservableCollection<Game>(Games.OrderByDescending(x => x.Plataform == (GamePlataform)Videogames.SelectedItem).ToList());
            AllGames = Games.ToList();

            DataContext = this;
        }
        private void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Run();
            }
        }
        private void InstallGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Install();

                MessageBox.Show($"{game.Name} foi instalado.");

                RefreshUI();
            }
        }
        private void UninstallGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Uninstall();

                MessageBox.Show($"{game.Name} foi desinstalado.");

                RefreshUI();
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchBox.Text.ToLower();

            Games.Clear();

            foreach (Game game in AllGames)
            {
                if (game.Name.ToLower().Contains(search))
                {
                    Games.Add(game);
                }
            }
        }
        private void RefreshUI()
        {
            DataContext = null;
            DataContext = this;
        }

        private void Videogames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Games = new ObservableCollection<Game>(Games.OrderByDescending(x => x.Plataform == (GamePlataform)Videogames.SelectedItem).ToList());
            AllGames = Games.ToList();
        }
    }
}