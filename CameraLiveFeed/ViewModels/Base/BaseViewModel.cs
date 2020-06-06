using CameraLiveFeed.Core.Services.LoggerFactory;
using Prism.Mvvm;
using Prism.Regions;

namespace CameraLiveFeed.ViewModels.Base
{
    public class BaseViewModel : BindableBase
    {
        protected readonly ILogger Logger;
        protected readonly IRegionManager RegionManager;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public BaseViewModel(ILogger logger, IRegionManager regionManager)
        {
            Logger = logger;
            RegionManager = regionManager;

            Logger.Info(GetType() + " CTOR invoked");
        }

        protected bool CanExecute()
        {
            return true;
        }
    }
}
