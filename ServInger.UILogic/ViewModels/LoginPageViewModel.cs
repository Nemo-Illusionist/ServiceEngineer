using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using DAL.Manager;
using System.Threading.Tasks;
using ServInger.UILogic.Services;
using ServInger.UILogic.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq.Expressions;

namespace ServInger.UILogic.ViewModels {
    class LoginPageViewModel : ViewModelBase {

        private readonly IDBUserManager _dbUserManager;
        private readonly INavigationService _navigationService;
        private readonly IAccountService _accountService;
        private readonly IFlashlight _flashlight;

        private string _login;
        [Required(ErrorMessage = "Заполните поле \"Логин\"")]
        public string Login {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        private string _password;
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private bool _isProcessLogin;
        public bool IsProcessLogin {
            get { return _isProcessLogin; }
            set { SetProperty(ref _isProcessLogin, value); }
        }

        private readonly DelegateCommand _loginCommand;
        public ICommand LoginCommand => _loginCommand;

        public ICommand FlashlightCommand => new DelegateCommand(OnFlashlightCommand);

        private async void OnFlashlightCommand() {
            bool flag = false;
            string ErrMess = "";
            try {
                await _flashlight.OnOf();
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
        }

        public LoginPageViewModel(IDBUserManager dbUserManager, INavigationService navigationService,
                                  IAccountService accountService, IFlashlight flashlight) {
            _dbUserManager = dbUserManager;
            _navigationService = navigationService;
            _accountService = accountService;
            _flashlight = flashlight;

            _loginCommand = new DelegateCommand(OnLogin, () => !IsProcessLogin).ObservesProperty(() => IsProcessLogin);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            Login = "Гость";
            Password = "";
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            base.OnNavigatedTo(e, viewModelState);
        }

        public async void OnLogin() {
            bool flag = false;
            string ErrMess = "";
            try {
                if (!String.IsNullOrEmpty(Login)) {
                    await _accountService.authorization(Login, Password);
                    _navigationService.Navigate("Tasks", null);
                } else
                    throw new Exception("Заполните поле \"Логин\"");
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if(flag)
                await dialog("Error", ErrMess);
        }

        private async Task dialog(string header, string text) {
            var dialog = new MessageDialog(text, header) {
                Commands = { new UICommand("Закрыть") { Id = 1 } },
                CancelCommandIndex = 1
            };

            var result = await dialog.ShowAsync();
        }

    }
}
