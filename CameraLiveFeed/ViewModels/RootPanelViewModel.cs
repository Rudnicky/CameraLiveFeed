using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using CameraLiveFeed.Views;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    class RootPanelViewModel : BaseViewModel
    {
        public ICommand RootViewLoadedCommand { get => new RelayCommand(RootViewLoaded, CanExecute); }

        public RootPanelViewModel(ILogger logger, IRegionManager regionManager) 
            : base(logger, regionManager)
        {

        }

        private void RootViewLoaded()
        {
            try
            {
                RegionManager.RequestNavigate("MainRegion", nameof(CameraFinderView));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
