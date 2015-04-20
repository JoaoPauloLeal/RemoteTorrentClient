using Newtonsoft.Json;
using System;

namespace RemoteTorrentClient.Models
{
	public class RssFilter
	{
		public RssFilter()
		{
			throw new NotImplementedException();
		}

		[JsonProperty(Order = 0)]
		public int Id
		{
			get;
			set;
		}

		[JsonProperty(Order = 1)]
		public int Flags
		{
			get;
			set;
		}

		[JsonProperty(Order = 2)]
		public int Name
		{
			get;
			set;
		}

		[JsonProperty(Order = 3)]
		public int Filter
		{
			get;
			set;
		}

		[JsonProperty(Order = 4)]
		public int NotFilter
		{
			get;
			set;
		}

		[JsonProperty(Order = 5)]
		public int Directory
		{
			get;
			set;
		}

		[JsonProperty(Order = 6)]
		public int Feed
		{
			get;
			set;
		}

		[JsonProperty(Order = 7)]
		public int Quality
		{
			get;
			set;
		}

		[JsonProperty(Order = 8)]
		public int Label
		{
			get;
			set;
		}

		[JsonProperty(Order = 9)]
		public int PostponeMode
		{
			get;
			set;
		}

		[JsonProperty(Order = 10)]
		public int LastMatch
		{
			get;
			set;
		}

		[JsonProperty(Order = 11)]
		public int SmartEpFilter
		{
			get;
			set;
		}

		[JsonProperty(Order = 12)]
		public int RepackEpFilter
		{
			get;
			set;
		}

		[JsonProperty(Order = 13)]
		public int EpisodeFilterStr
		{
			get;
			set;
		}

		[JsonProperty(Order = 14)]
		public int EpisodeFilter
		{
			get;
			set;
		}

		[JsonProperty(Order = 15)]
		public int ResolvingCandidate
		{
			get;
			set;
		}
	}
}
