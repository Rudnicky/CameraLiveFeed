using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using CameraLiveFeed.Views;
using NLog;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly ILogger _logger;
        private readonly IRegionManager _regionManager;

        public ICommand TestButtonClickedCommand { get => new AsyncCommand(TestButtonClickedAsync, CanExecute); }

        public ShellViewModel(ILogger logger, IRegionManager regionManager)
        {
            _logger = logger;
            _regionManager = regionManager;
        }

        private async Task TestButtonClickedAsync()
        {
            IsBusy = true;

            _logger.Info("testbuttonclickedasync entered");

            // simulate some work
            await Task.Delay(500);

            // navigate to another view
            _regionManager.RequestNavigate("ContentRegion", nameof(CameraFinderView));

            _logger.Info("TestButtonClickedAsync Finished");

            IsBusy = false;
        }
    }
}
