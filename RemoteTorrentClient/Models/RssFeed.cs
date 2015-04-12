using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Models
{
	class RssFeed
	{
		public RssFeed()
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
		public int Enabled
		{
			get;
			set;
		}

		[JsonProperty(Order = 2)]
		public int UseFeedTitle
		{
			get;
			set;
		}

		[JsonProperty(Order = 3)]
		public int UserSelected
		{
			get;
			set;
		}

		[JsonProperty(Order = 4)]
		public int Programmed
		{
			get;
			set;
		}

		[JsonProperty(Order = 5)]
		public int DownloadState
		{
			get;
			set;
		}

		[JsonProperty(Order = 6)]
		public int Url
		{
			get;
			set;
		}

		[JsonProperty(Order = 7)]
		public int NextUpdate
		{
			get;
			set;
		}

		[JsonProperty(Order = 8)]
		public int Items
		{
			get;
			set;
		}
	}
}
