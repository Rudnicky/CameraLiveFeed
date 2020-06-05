using Caliburn.Micro;
using CameraLiveFeed.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CameraLiveFeed
{
    public class Bootstrapper : BootstrapperBase
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            _container.RegisterInstance(typeof(ILogger), "Logger", Logger);

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            Logger.Info("Application Started.");

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
