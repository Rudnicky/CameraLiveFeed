using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.ViewModels.Base;
using Prism.Regions;

namespace CameraLiveFeed.ViewModels
{
    public class MediaPlayerViewModel : BaseViewModel
    {
        public MediaPlayerViewModel(ILogger logger, IRegionManager regionManager) 
            : base(logger, regionManager)
        {
        }
    }
}
