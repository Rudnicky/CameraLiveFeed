using CameraLiveFeed.ViewModels.Base;

namespace CameraLiveFeed.ViewModels
{
    public class MediaPlayerViewModel : BaseViewModel
    {
        private string _cameraUrl;
        public string CameraUrl
        {
            get => _cameraUrl;
            set
            {
                _cameraUrl = value;
                OnPropertyChanged(nameof(CameraUrl));
            }
        }
    }
}
