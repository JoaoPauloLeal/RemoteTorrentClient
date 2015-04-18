using Caliburn.Micro;
using RemoteTorrentClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.UI.Torrent.Client
{
	public class ClientViewModel : Screen
	{
		private TorrentsViewModel _torrents;

		public ClientViewModel(TorrentsViewModel torrents)
		{
			_torrents = torrents;
		}

		public ClientViewModel With(WebUIConnectionParameters connectionParameters)
		{
			return this;
		}
	}
}
