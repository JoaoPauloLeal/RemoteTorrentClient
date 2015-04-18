using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace RemoteTorrentClient
{
	public class AppBootstrapper : BootstrapperBase
	{
		SimpleContainer _container;

		public AppBootstrapper()
		{
			Initialize();
		}

		protected override void Configure()
		{
			_container = ContainerConfigurer.GetPreconfiguredContainer();
		}

		protected override object GetInstance(Type service, string key)
		{
			var instance = _container.GetInstance(service, key);
			if (instance != null)
				return instance;

			throw new InvalidOperationException("Could not locate any instances.");
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}

		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
		{
			DisplayRootViewFor<IShell>();
		}
	}
}