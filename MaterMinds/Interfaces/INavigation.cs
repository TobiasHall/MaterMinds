using System.Windows.Input;

namespace MaterMinds.Command
{
    public interface INavigation
    {
        public ICommand MainMenuCommand { get; set; }
        public ICommand ViewTopHighscoreCommand { get; set; }
        public ICommand ViewTopFrequentPlayersCommand { get; set; }

        void GetMainMenuView(object parameter);

        void GetHighscorePage(object parameter);
    }
}
