using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using NLog;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ILogger _logger;

        private Visibility _isMediaPlayerViewVisible = Visibility.Visible;
        public Visibility IsMediaPlayerViewVisible
        {
            get => _isMediaPlayerViewVisible;
            set
            {
                _isMediaPlayerViewVisible = value;
                OnPropertyChanged(nameof(IsMediaPlayerViewVisible));
            }
        }

        private string _buttonTextTest = "Test Test Test";
        public string ButtonTextTest
        {
            get => _buttonTextTest;
            set
            {
                _buttonTextTest = value;
                OnPropertyChanged(nameof(ButtonTextTest));
            }
        }

        public ICommand TestButtonClickedCommand { get => new AsyncCommand(TestButtonClickedAsync, CanExecute); }

        public MainWindowViewModel(ILogger logger)
        {
            _logger = logger;
        }

        private async Task TestButtonClickedAsync()
        {
            IsBusy = true;

            _logger.Info("testbuttonclickedasync entered");

            await Task.Delay(2000);

            _logger.Info("TestButtonClickedAsync Finished");

            IsBusy = false;
        }
    }
}
