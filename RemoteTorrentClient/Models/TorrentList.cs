using Newtonsoft.Json;

namespace RemoteTorrentClient.Models
{
	class TorrentList : TorrentListBase
	{
		[JsonProperty("torrents")]
		public TorrentCollection Torrents
		{
			get;
			set;
		}

		[JsonProperty("rssfeeds")]
		public object[,] RssFeeds
		{
			get;
			set;
		}

		[JsonProperty("rssfilters")]
		public object[,] RssFilters
		{
			get;
			set;
		}
	}
}
