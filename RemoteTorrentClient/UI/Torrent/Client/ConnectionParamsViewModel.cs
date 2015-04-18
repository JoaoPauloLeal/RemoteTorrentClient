using Caliburn.Micro;
using RemoteTorrentClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.UI.Torrent.Client
{
	public class ConnectionParamsViewModel : Screen
	{
		public string Host
		{
			get;
			set;
		}

		public int Port
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public WebUIConnectionParameters GetConnectionParameters()
		{
			return new WebUIConnectionParameters()
			{
				Host = Host,
				Port = Port,
				UserName = UserName,
				Password = Password,
			};
		}
	}
}
