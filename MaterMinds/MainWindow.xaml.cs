using MaterMinds.View;
using System.Windows;

namespace MaterMinds
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var view = new MainMenuView();
            Main.Content = view;
        }
    }
}
