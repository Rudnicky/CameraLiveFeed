using CameraLiveFeed.ViewModels;
using CameraLiveFeed.Views;
using System;
using System.Windows;

namespace CameraLiveFeed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            Logger.Info("Application Started");

            InitializeAutofacContainer();

            InitializeStartupWindow();
        }

        private void InitializeAutofacContainer()
        {
            // TODO: add dependencies here
        }

        private void InitializeStartupWindow()
        {
            var mainWindowViewModel = new MainWindowViewModel(Logger);
            var mainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };
            mainWindow.Show();
        }
    }
}
