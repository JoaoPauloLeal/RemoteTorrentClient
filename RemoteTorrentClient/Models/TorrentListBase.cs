using Newtonsoft.Json;

namespace RemoteTorrentClient.Models
{
	class TorrentListBase : BuildNumber
	{
		[JsonProperty("label")]
		public TorrentLabelCollection Labels
		{
			get;
			set;
		}

		[JsonProperty("torrentc")]
		public string CacheId
		{
			get;
			set;
		}
	}
}
