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

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginButtonClickedCommand { get => new AsyncCommand(LoginButtonClickedAsync, CanExecute); }
        public ICommand WatermarkTextChangedCommand { get => new RelayCommand(WatermarkTextChanged, CanExecute); }
        public ICommand PasswordChangedCommand { get => new RelayCommand(PasswordChanged, CanExecute); }
        public ICommand ForgotPasswordMouseDownCommand { get => new RelayCommand(ForgotPasswordMouseDown, CanExecute); }

        private void WatermarkTextChanged()
        {
            IsLoginButtonEnabled = !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void PasswordChanged()
        {
            IsLoginButtonEnabled = !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ForgotPasswordMouseDown()
        {
            // TODO: add logic when user wants to recover a password
        }

        private async Task LoginButtonClickedAsync()
        {
            IsBusy = true;



            IsBusy = false;
        }
    }
}
    