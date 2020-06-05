using Prism.Mvvm;

namespace CameraLiveFeed.ViewModels.Base
{
    public class BaseViewModel : BindableBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        protected bool CanExecute()
        {
            return true;
        }
    }
}
