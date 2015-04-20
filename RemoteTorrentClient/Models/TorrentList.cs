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
		public RssFeedCollection RssFeeds
		{
			get;
			set;
		}

		[JsonProperty("rssfilters")]
		public RssFilterCollection RssFilters
		{
			get;
			set;
		}
	}
}
