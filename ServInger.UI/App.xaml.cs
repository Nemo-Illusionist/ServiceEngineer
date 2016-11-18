using System;
using System.Globalization;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.Xaml;
using Prism.Events;
using Prism.Mvvm;
using Prism.Unity.Windows;
using DAL.Manager;
using Microsoft.Practices.Unity;
using ServInger.UILogic.Services;
using DAL.Entites;
using ServInger.UILogic.Attributes;
using Windows.Storage;
using Microsoft.VisualBasic;

namespace ServInger.UI {
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    sealed partial class App : PrismUnityApplication {
        public IEventAggregator EventAggregator { get; set; }
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args) {
            try {
                new DBTestManager().CreateDB();
                new DBTestManager().CreateTestDB();
            } catch { }
            NavigationService.Navigate("Login", null);

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) {
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 255, 255, 255);
                statusBar.BackgroundOpacity = 1;
            }

            Window.Current.Activate();
            return Task.FromResult<object>(null);
        }

        protected override void OnRegisterKnownTypesForSerialization() {
            SessionStateService.RegisterKnownType(typeof(UserEntity));
            SessionStateService.RegisterKnownType(typeof(TaskEntity));
            SessionStateService.RegisterKnownType(typeof(TimeoutException));
            SessionStateService.RegisterKnownType(typeof(TechnicalCardEntity));

        }


        protected override Task OnInitializeAsync(IActivatedEventArgs args) {
            EventAggregator = new EventAggregator();

            Container.RegisterType<IAccountService, AccountService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ITaskService, TaskService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDBUserManager, DBUserManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDBTaskManager, DBTaskManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IFlashlight, Flashlight>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICamera, Camera>(new ContainerControlledLifetimeManager());

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) => {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "ServInger.UILogic.ViewModels.{0}ViewModel, ServInger.UILogic, Version=1.0.0.0, Culture=neutral", viewType.Name);
                var viewModelType = Type.GetType(viewModelTypeName);
                if (viewModelType == null) {
                    viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "ServInger.UILogic.ViewModels.{0}ViewModel, ServInger.UILogic.Windows, Version=1.0.0.0, Culture=neutral", viewType.Name);
                    viewModelType = Type.GetType(viewModelTypeName);
                }
                return viewModelType;
            });

            return base.OnInitializeAsync(args);

        }
    }
}
