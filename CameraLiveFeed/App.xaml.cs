using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.Views;
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
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILogger, Logger>();

            containerRegistry.RegisterForNavigation<CameraFinderView>();
            containerRegistry.RegisterForNavigation<MediaPlayerView>();
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<RootPanelView>();
            containerRegistry.RegisterForNavigation<LeftPanelView>();
        }
    }
}
