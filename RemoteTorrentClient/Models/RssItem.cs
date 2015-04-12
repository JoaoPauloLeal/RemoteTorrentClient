using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Models
{
	class RssItem
	{
		public RssItem()
		{
			throw new NotImplementedException();
		}

		[JsonProperty(Order = 0)]
		public int Name
		{
			get;
			set;
		}

		[JsonProperty(Order = 1)]
		public int NameFull
		{
			get;
			set;
		}

		[JsonProperty(Order = 2)]
		public int Url
		{
			get;
			set;
		}

		[JsonProperty(Order = 3)]
		public int Quality
		{
			get;
			set;
		}

		[JsonProperty(Order = 4)]
		public int Codec
		{
			get;
			set;
		}

		[JsonProperty(Order = 5)]
		public int Timestamp
		{
			get;
			set;
		}

		[JsonProperty(Order = 6)]
		public int Season
		{
			get;
			set;
		}

		[JsonProperty(Order = 7)]
		public int Episode
		{
			get;
			set;
		}

		[JsonProperty(Order = 8)]
		public int EpisodeTo
		{
			get;
			set;
		}

		[JsonProperty(Order = 9)]
		public int FeedId
		{
			get;
			set;
		}

		[JsonProperty(Order = 10)]
		public int Repack
		{
			get;
			set;
		}

		[JsonProperty(Order = 11)]
		public int InHistory
		{
			get;
			set;
		}
	}
}
