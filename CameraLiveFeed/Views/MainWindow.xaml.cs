using CameraLiveFeed.ViewModels;
using System.Windows;

namespace CameraLiveFeed.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataContext();
        }

        private void InitializeDataContext()
        {
            this.DataContext = new MainWindowViewModel();
        }
    }
}
