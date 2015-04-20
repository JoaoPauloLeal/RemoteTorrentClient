using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.UI.Torrent
{
	public enum GroupType
	{
		AllTorrents,
		Downloading,
		Seeding,
		Completed,
		Active,
		Inactive,
		AllLabels,
		NoLabel,
		Label,
		AllFeeds,
		Feed,
	}
}
