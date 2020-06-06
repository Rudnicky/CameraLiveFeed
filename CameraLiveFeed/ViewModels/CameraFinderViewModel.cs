using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using CameraLiveFeed.Views;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    public class CameraFinderViewModel : BaseViewModel
    {
        public ICommand ScanAvailableCameraButtonClickedCommand { get => new AsyncCommand(ScanAvailableCameraButtonClickedAsync, CanExecute); }

        public CameraFinderViewModel(ILogger logger, IRegionManager regionManager)
            : base(logger, regionManager)
        {
        }

        private async Task ScanAvailableCameraButtonClickedAsync()
        {
            // TODO: navigate to a proper page. This is just for the tests purposes.

            IsBusy = true;

            // simulate some work
            await Task.Delay(500);

            // navigate to another view
            RegionManager.RequestNavigate("ContentRegion", nameof(MediaPlayerView));


            IsBusy = false;
        }
    }
}
