using DAL.Manager;
using DAL.Entites;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ServInger.UILogic.Services;
using System.Collections.Generic;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Windows.Input;
using Prism.Commands;
using ServInger.UILogic.Attributes;
using System.Linq;

namespace ServInger.UILogic.ViewModels {
    class TasksPageViewModel : ViewModelBase {
        private readonly IDBUserManager _dbUserManager;
        private readonly IDBTaskManager _dbTaskManager;
        private readonly INavigationService _navigationService;
        private readonly IAccountService _accountService;
        private readonly ITaskService _taskService;

        private List<TaskEntity> _currentTasks;
        public List<TaskEntity> CurrentTasks {
            get { return _currentTasks; }
            set { SetProperty(ref _currentTasks, value); }
        }

        public ICommand MapsCommand => new DelegateCommand(OnMapsCommand);
        public ICommand FilterCommand => new DelegateCommand(OnFilterCommand);
        public ICommand SyncCommand => new DelegateCommand(OnSyncCommand);

        private async void OnSyncCommand() {
            await dialog("Error!", "Нет соеденения с сервером");
        }

        private async void OnMapsCommand() {
            bool flag = false;
            string ErrMess = "";
            try {
                List<string> addres = new List<string>();
                foreach (var task in CurrentTasks)
                    addres.Add(task.Address);
                await new Maps().Show(addres);
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
        }

        private string _numberTasks;
        public string NumberTasks {
            get { return _numberTasks; }
            set { SetProperty(ref _numberTasks, value); }
        }

        private List<TaskEntity> TasksFilter;

        private void OnFilterCommand() {
            List<TaskEntity> Filter = CurrentTasks;
            CurrentTasks = TasksFilter;
            TasksFilter = Filter;
            NumberTasks = "ЗАДАНИЯ (" + CurrentTasks.Count + ")";
        }

        public TasksPageViewModel(IDBUserManager dbUserManager, IDBTaskManager dbTaskManager, INavigationService navigationService,
                                  IAccountService accountService, ITaskService tascService) {
            _dbUserManager = dbUserManager;
            _dbTaskManager = dbTaskManager;
            _navigationService = navigationService;
            _accountService = accountService;
            _taskService = tascService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            bool flag = false;
            string ErrMess = "";
            try {
                UserEntity user = _accountService.get();
                CurrentTasks = _dbTaskManager.getTaskList(user);
                TasksFilter = CurrentTasks.Where(x => x.Status == 0 || x.Status == 1).ToList();
                NumberTasks = "ЗАДАНИЯ (" + CurrentTasks.Count + ")";
            } catch (Exception ex) {
                flag = true;
                ErrMess = ex.Message;
            }
            if (flag)
                await dialog("Error", ErrMess);
            base.OnNavigatedTo(e, viewModelState);
        }

        private async Task dialog(string header, string text) {
            var dialog = new MessageDialog(text, header) {
                Commands = { new UICommand("Закрыть") { Id = 1 } },
                CancelCommandIndex = 1
            };

            var result = await dialog.ShowAsync();
        }

        public void TaskItemClick(object sender, object parametr) {
            var arg = parametr as ItemClickEventArgs;
            var item = arg?.ClickedItem as TaskEntity;
            _taskService.set(item);
            _navigationService.Navigate("CurrentTaskLocal", null);
        }
    }
}
