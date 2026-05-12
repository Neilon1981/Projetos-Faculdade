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

        private bool ShowingFavorites = false;

        public MainWindow()
        {
            InitializeComponent();

            //Adicionar um metodo ou estrutura com varios jogos + link dos jogos para abrir e jogar diretamente.
            //Todos os jogos devem ser possiveis de jogar através do navegador.
            //Se necessario, copie as classes ja existentes para novos consoles.
            //Usar https://www.thecoverproject.net/ para salvar as capas
            //Manter a estrutura de pastas corretas para cada tipo de console
            //Ao salvar as capas, edite as propriedades do arquivo
            //Build Action = Resource
            //Copy to Output Directory = Copy if newer

            Games.Add(new SuperNintendo
            {
                Name = "Super Mario World",
                Category = "Aventura",
                Description = "Super Mario World é um clássico do SNES em que Mario e Luigi exploram Dinosaur Land para salvar a Princesa Peach. O jogo introduz Yoshi e traz fases criativas cheias de segredos, sendo um dos plataformas mais influentes e lembrados dos videogames.",
                RunPath = "https://emulatorgamer.com/pt/games/super-mario-world/play",
                Size = 0.003,
                CoverPath = "UI/Images/Games/SNES/supermarioworld.jpg",
            });

            Games.Add(new Playstation2
            {
                Name = "Grand Theft Auto III",
                Category = "Ação / Mundo Aberto",
                Description = "Grand Theft Auto III revolucionou os jogos de mundo aberto, colocando o jogador na cidade de Liberty City em uma experiência livre de exploração, missões criminais e narrativa não linear. Foi o primeiro GTA totalmente 3D, marcando uma nova era para a franquia.",
                Size = 1,
                CoverPath = "UI/Images/Games/PS2/gta3.jpg",
                Installed = false
            });

            Games = new ObservableCollection<Game>(Games.OrderByDescending(x => x.Installed).ToList());
            AllGames = Games.ToList();

            LoadFavorites();
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
            GameList.Items.Refresh();
        }
        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element &&
                element.DataContext is Game game)
            {
                game.Favorite = !game.Favorite;

                SaveFavorites();

                RefreshUI();
            }
        }
        private void AllGames_Click(object sender, RoutedEventArgs e)
        {
            Games.Clear();

            foreach (Game game in AllGames)
            {
                Games.Add(game);
            }

            RefreshUI();
        }
        private void Favorites_Click(object sender, RoutedEventArgs e)
        {
            Games.Clear();

            foreach (Game game in AllGames)
            {
                if (game.Favorite)
                {
                    Games.Add(game);
                }
            }

            RefreshUI();
        }

        private void SaveFavorites()
        {
            //Monte uma estrutura aplicando conceitos em JSON para salvar a lista de favoritos
        }

        private void LoadFavorites()
        {
            //Carregue o arquivo gerado para ler todos os favoritos salvos.
        }
    }
}