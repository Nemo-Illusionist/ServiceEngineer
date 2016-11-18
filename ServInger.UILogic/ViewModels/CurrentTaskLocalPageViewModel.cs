using DAL.Manager;
using DAL.Entites;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ServInger.UILogic.Services;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Graphics.Display;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ServInger.UILogic.Attributes;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Controls;

namespace ServInger.UILogic.ViewModels {
    class CurrentTaskLocalPageViewModel : ViewModelBase {
        private readonly IDBTaskManager _dbTaskManager;
        private readonly INavigationService _navigationService;
        private readonly ITaskService _taskService;
        private readonly ICamera _camera;


        private List<PhotoEntity> _myPhoto;
        public List<PhotoEntity>/*ImageSource*/ MyPhoto {
            get { return _myPhoto; }
            set { SetProperty(ref _myPhoto, value); }
        }

        private string _idTask;
        public string IDTask {
            get { return _idTask; }
            set { SetProperty(ref _idTask, value); }
        }

        private string _dateEnd;
        public string DateEnd {
            get { return _dateEnd; }
            set { SetProperty(ref _dateEnd, value); }
        }

        private string _dateStart;
        public string DateStart {
            get { return _dateStart; }
            set { SetProperty(ref _dateStart, value); }
        }

        private int _status;
        public int Status {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        private string _manufacturer;
        public string Manufacturer {
            get { return _manufacturer; }
            set { SetProperty(ref _manufacturer, value); }
        }

        private string _mark;
        public string Mark {
            get { return _mark; }
            set { SetProperty(ref _mark, value); }
        }

        private string _factoryNomber;
        public string FactoryNomber {
            get { return _factoryNomber; }
            set { SetProperty(ref _factoryNomber, value); }
        }

        private string Address;

        public ICommand MapsCommand => new DelegateCommand(OnMapsCommand);
        public ICommand TechnicalCardCommand => new DelegateCommand(OnTechnicalCardCommand);
        public ICommand TestimonyCommand => new DelegateCommand(OnTestimonyCommand);
        public ICommand CameraCommand => new DelegateCommand(OnCameraCommand);

        private async void OnMapsCommand() {
            bool flag = false;
            string ErrMess = "";
            try {
                await new Maps().Show(Address);
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
        }

        private async void OnCameraCommand() {
            string path = await _camera.Screen();
            _dbTaskManager.setPhoto(_taskService.get(), path);
            MyPhoto = _dbTaskManager.getPhoto(_taskService.get());
        }

        public CurrentTaskLocalPageViewModel(IDBTaskManager dbTaskManager, INavigationService navigationService,
                          ITaskService taskService, ICamera camera) {
            _dbTaskManager = dbTaskManager;
            _navigationService = navigationService;
            _taskService = taskService;
            _camera = camera;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            TaskEntity task = _taskService.get();
            if (task == null)
                await dialog("Error", "Не удалось отоброзить текущее задание");
            else {
                //StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                //await localFolder.GetFileAsync("");
                MyPhoto = _dbTaskManager.getPhoto(task);


                Address = task.Address;
                IDTask = task.IDTask;
                DateEnd = task.DateEnd.ToString("d");
                DateStart = task.DateStart.ToString("d");
                Status = task.Status;
                Manufacturer = task.Manufacturer;
                Mark = task.Mark;
                FactoryNomber = task.FactoryNomber;
            }
            base.OnNavigatedTo(e, viewModelState);
        }

        public override async void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending) {
            bool flag = false;
            string ErrMess = "";
            try {
                TaskEntity task = _taskService.get();
                task.Status = Status;
                _dbTaskManager.updateTask(task);
                _taskService.set(task);
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

        public void OnTechnicalCardCommand() {
            _navigationService.Navigate("TechnicalCard", null);
        }

        public void OnTestimonyCommand() {
            _navigationService.Navigate("Testi", null);
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
