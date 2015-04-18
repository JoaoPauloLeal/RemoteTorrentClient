using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.UI.Torrent.Client
{
	public class ClientSelectorViewModel : Conductor<ClientViewModel>.Collection.OneActive
	{
		private IWindowManager _windowManager;
		private Func<ConnectionParamsViewModel> _connectionParamsFactory;
		private Func<ClientViewModel> _clientFactory;

		public ClientSelectorViewModel(IWindowManager windowManager, Func<ConnectionParamsViewModel> connectionParamsFactory, Func<ClientViewModel> clientFactory)
		{
			_windowManager = windowManager;
			_connectionParamsFactory = connectionParamsFactory;
			_clientFactory = clientFactory;
		}

		public void AddClient(bool showDialog = true)
		{
			var connectionParametersVM = _connectionParamsFactory();

			if (showDialog)
			{
				var dialogResult = _windowManager.ShowDialog(connectionParametersVM);
				if (!dialogResult.GetValueOrDefault())
					return;
			}

			var connectionParameters = connectionParametersVM.GetConnectionParameters();
			var clientVM = _clientFactory().With(connectionParameters);
			ActivateItem(clientVM);
		}
	}
}
