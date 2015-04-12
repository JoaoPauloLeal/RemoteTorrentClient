using Newtonsoft.Json;
using RemoteTorrentClient.JsonConverters;

namespace RemoteTorrentClient.Models
{
	[JsonConverter(typeof(LabelConverter))]
	class TorrentLabel
	{
		[JsonProperty(Order = 0)]
		public string Label
		{
			get;
			set;
		}

		[JsonProperty(Order = 1)]
		public int TorrentsInLabel
		{
			get;
			set;
		}
	}
}
