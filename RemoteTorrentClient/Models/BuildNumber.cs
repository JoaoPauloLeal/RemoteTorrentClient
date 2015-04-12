using Newtonsoft.Json;

namespace RemoteTorrentClient.Models
{
	class BuildNumber
	{
		[JsonProperty("build")]
		public int Build
		{
			get;
			set;
		}
	}
}
