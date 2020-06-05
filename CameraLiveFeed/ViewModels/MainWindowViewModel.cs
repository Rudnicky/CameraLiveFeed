using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Visibility _isMediaPlayerViewVisible = Visibility.Hidden;
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

        private async Task TestButtonClickedAsync()
        {
            IsBusy = true;

            Debug.WriteLine("TestButtonClickedAsync Entered");

            await Task.Delay(2000);

            Debug.WriteLine("TestButtonClickedAsync Finished");

            IsBusy = false;
        }

        public MainWindowViewModel()
        {

        }
    }
}
