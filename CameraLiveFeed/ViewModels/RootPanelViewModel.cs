using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.ViewModels.Base;
using Prism.Regions;

namespace CameraLiveFeed.ViewModels
{
    class RootPanelViewModel : BaseViewModel
    {
        public RootPanelViewModel(ILogger logger, IRegionManager regionManager) 
            : base(logger, regionManager)
        {
        }
    }
}
