using Newtonsoft.Json;
using System.Collections.Generic;

namespace RemoteTorrentClient.Models
{
	class TorrentListChanged : TorrentListBase
	{
		[JsonProperty("torrentp")]
		public TorrentCollection ChangedTorrents
		{
			get;
			set;
		}

		[JsonProperty("torrentm")]
		public string[] RemovedTorrents
		{
			get;
			set;
		}

		[JsonProperty("rssfeedp")]
		public RssFeedCollection ChangedRssFeeds
		{
			get;
			set;
		}

		[JsonProperty("rssfeedm")]
		public string[] RemovedRssFeeds
		{
			get;
			set;
		}

		[JsonProperty("rssfilterp")]
		public RssFilterCollection ChangedRssFilters
		{
			get;
			set;
		}

		[JsonProperty("rssfilterm")]
		public string[] RemovedRssFilters
		{
			get;
			set;
		}
	}
}
