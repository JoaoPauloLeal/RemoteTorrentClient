using Caliburn.Micro;
using RemoteTorrentClient.UI.Torrent;
using RemoteTorrentClient.UI.Torrent.Client;
using RemoteTorrentClient.WebAPI;

namespace RemoteTorrentClient
{
	public static class ContainerConfigurer
	{
		public static SimpleContainer GetPreconfiguredContainer()
		{
			var container = new SimpleContainer();

			container.Singleton<IWindowManager, WindowManager>();
			container.Singleton<IEventAggregator, EventAggregator>();
			container.PerRequest<IShell, ShellViewModel>();

			// WebAPI
			container.PerRequest<WebUIClient>();

			// UI.Torrent
			container.PerRequest<FilesViewModel>();
			container.PerRequest<GroupsViewModel>();
			container.PerRequest<InfoViewModel>();
			container.PerRequest<PeersViewModel>();
			container.PerRequest<RatingsViewModel>();
			container.PerRequest<SpeedViewModel>();
			container.PerRequest<StatusBarViewModel>();
			container.PerRequest<ToolBarViewModel>();
			container.PerRequest<TorrentsViewModel>();
			container.PerRequest<TrackersViewModel>();

			// UI.Torrent.Client
			container.PerRequest<ClientSelectorViewModel>();
			container.PerRequest<ConnectionParamsViewModel>();
			container.Handler<IScreen>((c) => c.GetInstance<ConnectionParamsViewModel>());
			container.PerRequest<ClientViewModel>();
			container.Handler<IScreen>((c) => c.GetInstance<ClientViewModel>());

			// UI.Torrent.Preferences
			return container;
		}
	}
}
