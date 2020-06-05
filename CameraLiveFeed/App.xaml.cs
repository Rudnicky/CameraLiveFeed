using CameraLiveFeed.Views;
using NLog;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace CameraLiveFeed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(ILogger), Logger);
        }
    }
}
