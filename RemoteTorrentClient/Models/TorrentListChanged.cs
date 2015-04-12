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
		public List<string> RemovedTorrents
		{
			get;
			set;
		}

		[JsonProperty("rssfeedp")]
		public object[,] ChangedRssFeeds
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
		public object[,] ChangedRssFilters
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
