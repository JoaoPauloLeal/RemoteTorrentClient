using RemoteTorrentClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Messages
{
	public class TorrentsUpdated
	{
		public TorrentLabelCollection Labels
		{
			get;
			set;
		}

		public TorrentCollection Torrents
		{
			get;
			set;
		}

		public RssFeedCollection RssFeeds
		{
			get;
			set;
		}

		public RssFilterCollection RssFilters
		{
			get;
			set;
		}
	}
}
