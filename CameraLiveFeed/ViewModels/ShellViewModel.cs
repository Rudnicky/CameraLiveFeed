using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using CameraLiveFeed.Views;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public ICommand TestButtonClickedCommand { get => new AsyncCommand(TestButtonClickedAsync, CanExecute); }
        public ICommand ShellWindowLoadedCommand { get => new RelayCommand(ShellWindowLoaded, CanExecute); }

        public ShellViewModel(ILogger logger, IRegionManager regionManager) 
            : base(logger, regionManager)
        {
        }

        private void ShellWindowLoaded()
        {
            RegionManager.RequestNavigate("ContentRegion", nameof(LoginView));
        }

        private async Task TestButtonClickedAsync()
        {
            IsBusy = true;

            Logger.Info("testbuttonclickedasync entered");

            // simulate some work
            await Task.Delay(500);

            // navigate to another view
            RegionManager.RequestNavigate("ContentRegion", nameof(CameraFinderView));

            Logger.Info("TestButtonClickedAsync Finished");

            IsBusy = false;
        }
    }
}
