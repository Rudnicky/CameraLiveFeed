using CameraLiveFeed.Core.Services.LoggerFactory;
using CameraLiveFeed.Core.Services.RelayCommand;
using CameraLiveFeed.ViewModels.Base;
using CameraLiveFeed.Views;
using Prism.Regions;
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

        private bool _isWaterMarkFocused;
        public bool IsWaterMarkFocused
        {
            get => _isWaterMarkFocused;
            set => SetProperty(ref _isWaterMarkFocused, value);
        }

        private bool _isPasswordBoxFocused;
        public bool IsPasswordBoxFocused
        {
            get => _isPasswordBoxFocused;
            set => SetProperty(ref _isPasswordBoxFocused, value);
        }

        private bool _isLoginButtonFocused;
        public bool IsLoginButtonFocused
        {
            get => _isLoginButtonFocused;
            set => SetProperty(ref _isLoginButtonFocused, value);
        }

        public ICommand LoginButtonClickedCommand { get => new AsyncCommand(LoginButtonClickedAsync, CanExecute); }
        public ICommand LoginViewLoadedCommand { get => new RelayCommand(LoginViewLoaded, CanExecute); }
        public ICommand LoginButtonLostFocusCommand { get => new RelayCommand(LoginButtonLostFocus); }
        public ICommand WatermarkTextChangedCommand { get => new RelayCommand(WatermarkTextChanged, CanExecute); }
        public ICommand WatermarkEnterKeyPressedCommand { get => new RelayCommand(WatermarkEnterKeyPressed); }
        public ICommand WatermarkLostFocusCommand { get => new RelayCommand(WatermarkLostFocus); }
        public ICommand PasswordChangedCommand { get => new RelayCommand(PasswordChanged, CanExecute); }
        public ICommand PasswordEnterKeyPressedCommand { get => new RelayCommand(PasswordEnterKeyPressed); }
        public ICommand PasswordBoxLostFocusCommand { get => new RelayCommand(PasswordBoxLostFocus); }
        public ICommand ForgotPasswordMouseDownCommand { get => new RelayCommand(ForgotPasswordMouseDown, CanExecute); }

        public LoginViewModel(ILogger logger, IRegionManager regionManager)
            : base(logger, regionManager)
        {
        }

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

        private void WatermarkEnterKeyPressed()
        {
            IsWaterMarkFocused = false;
            IsPasswordBoxFocused = true;
            IsLoginButtonFocused = false;
        }

        private void PasswordEnterKeyPressed()
        {
            IsWaterMarkFocused = false;
            IsPasswordBoxFocused = false;

            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                IsLoginButtonFocused = false;
                IsLoginButtonEnabled = true;

                NavigateToRootPanel();
            } 
            else
            {
                IsLoginButtonFocused = true;
            }
        }

        private void PasswordBoxLostFocus()
        {
            IsPasswordBoxFocused = false;
        }

        private void LoginButtonLostFocus()
        {
            IsLoginButtonFocused = false;
        }

        private void WatermarkLostFocus()
        {
            IsWaterMarkFocused = false;
        }

        private async Task LoginButtonClickedAsync()
        {
            Logger.ProcessStarted(nameof(LoginButtonClickedAsync));

            IsBusy = true;

            NavigateToRootPanel();

            Logger.ProcessEnded(nameof(LoginButtonClickedAsync));

            IsBusy = false;
        }

        private void NavigateToRootPanel()
        {
            try
            {
                RegionManager.RequestNavigate("ContentRegion", nameof(RootPanelView));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void LoginViewLoaded()
        {
            IsWaterMarkFocused = true;
        }
    }
}
    