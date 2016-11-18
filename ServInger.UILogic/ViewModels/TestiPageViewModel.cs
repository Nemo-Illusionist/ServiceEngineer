using DAL.Manager;
using DAL.Entites;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ServInger.UILogic.Services;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using System;
using ServInger.UILogic.Attributes;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ServInger.UILogic.ViewModels {
    class TestiPageViewModel : ViewModelBase {

        private readonly IDBTaskManager _dbTaskManager;
        private readonly INavigationService _navigationService;
        private readonly ITaskService _taskService;
        private readonly ICamera _camera;
        private readonly IFlashlight _flashlight;

        private List<TestimonyEntity> _testimony;
        public List<TestimonyEntity> Testimony {
            get { return _testimony; }
            set { SetProperty(ref _testimony, value); }
        }
        public ICommand CameraCommand => new DelegateCommand(OnCameraCommand);
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

        private async void OnCameraCommand() {
            bool flag = false;
            string ErrMess = "";
            try {
                string path = await _camera.Screen();
                _dbTaskManager.setPhoto(_taskService.get(), path);
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
        }

        public TestiPageViewModel(IDBTaskManager dbTaskManager, INavigationService navigationService, ITaskService taskService, ICamera camera, IFlashlight flashlight) {
            _dbTaskManager = dbTaskManager;
            _navigationService = navigationService;
            _taskService = taskService;
            _camera = camera;
            _flashlight = flashlight;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            bool flag = false;
            string ErrMess = "";
            try {
                Testimony = _dbTaskManager.getTestimony(_taskService.get());
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
            base.OnNavigatedTo(e, viewModelState);
        }

        public override async void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending) {
            bool flag = false;
            string ErrMess = "";
            try {
                _dbTaskManager.updateTestimony(Testimony);
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
            base.OnNavigatingFrom(e, viewModelState, suspending);
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
