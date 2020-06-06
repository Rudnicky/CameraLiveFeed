using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CameraLiveFeed.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool _isLoginButtonEnabled;
        public bool IsLoginButtonEnabled
        {
            get => _isLoginButtonEnabled;
            set => SetProperty(ref _isLoginButtonEnabled, value);
        }

        public ICommand LoginButtonClickedCommand { get => new AsyncCommand(LoginButtonClickedAsync, CanExecute); }
        public ICommand WatermarkTextChangedCommand { get => new AsyncCommand<object>(WatermarkTextChanged, CanExecute); }

        private async Task WatermarkTextChanged(object arg)
        {

        }

        private async Task LoginButtonClickedAsync()
        {
            IsBusy = true;



            IsBusy = false;
        }
    }
}
    