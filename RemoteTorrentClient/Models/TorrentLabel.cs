using Newtonsoft.Json;
using RemoteTorrentClient.JsonConverters;

namespace RemoteTorrentClient.Models
{
	[JsonConverter(typeof(LabelConverter))]
	public class TorrentLabel
	{
		[JsonProperty(Order = 0)]
		public string Text
		{
			get;
			set;
		}

		[JsonProperty(Order = 1)]
		public int Count
		{
			get;
			set;
		}
	}
}
