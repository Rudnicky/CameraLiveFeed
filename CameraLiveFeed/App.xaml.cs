using CameraLiveFeed.ViewModels;
using CameraLiveFeed.Views;
using System.Windows;

namespace CameraLiveFeed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitializeAutofacContainer();

            InitializeStartupWindow();
        }

        private void InitializeAutofacContainer()
        {
            // TODO: add dependencies here
        }

        private void InitializeStartupWindow()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            var mainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };
            mainWindow.Show();
        }
    }
}
