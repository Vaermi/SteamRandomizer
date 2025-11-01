using SteamRandomizer.src.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SteamRandomizer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {

    private bool isFavorited = false;

    List<Game> games = new List<Game> {
            new Game { Id = 1, Title = "Portal 2", Genre = "Puzzle, Co-op", ImagePath = "Images/portal2.jpg" },
            new Game { Id = 2, Title = "Hades", Genre = "Rogue-like, Action", ImagePath = "Images/hades.jpg" },
            new Game { Id = 3, Title = "Dark Souls", Genre = "Souls-Like", ImagePath = "Images/dark-souls.jpg" },
            new Game { Id = 4, Title = "Elden Ring", Genre = "Souls-Like", ImagePath = "Images/elden-ring.jpg" }
    };

    public MainWindow() {
        InitializeComponent();
        
    }

    private void RandomButton_Click(object sender, RoutedEventArgs e) {
        ContentControl content = (ContentControl)sender;
        var game = this.ShuffleGames();
        if (game != null) {
            GameTitle.Text = game.Title;
            GameGenre.Text = game.Genre;
            //GameImage.Source = new BitmapImage(new Uri(Path.GetFullPath(game.ImagePath)));
        }
    }

    private void FavoriteButton_Click(object sender, RoutedEventArgs e) {
        isFavorited = !isFavorited;

        if (isFavorited) {
            FavoriteButton.Content = "✅ Gespeichert";
            FavoriteButton.Background = Brushes.Gold;
            FavoriteButton.Foreground = Brushes.Black;
        }
        else {
            FavoriteButton.Content = "⭐ Favorit";
            FavoriteButton.ClearValue(Button.BackgroundProperty);
            FavoriteButton.ClearValue(Button.ForegroundProperty);
        }
    }

    private void FilterButton_Click(object sender, RoutedEventArgs e) {

    }

    private Game ShuffleGames(){
        if (games == null || games.Count == 0) {
            return null;
        }
            
        Random rand = new Random();
        int randomIndex = rand.Next(games.Count);
        return games[randomIndex];
    }
}