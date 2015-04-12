using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Models
{
	class Peer
	{
		public Peer()
		{
			throw new NotImplementedException();
		}

		[JsonProperty(Order = 0)]
		public int Country
		{
			get;
			set;
		}

		[JsonProperty(Order = 1)]
		public int Ip
		{
			get;
			set;
		}

		[JsonProperty(Order = 2)]
		public int Revdns
		{
			get;
			set;
		}

		[JsonProperty(Order = 3)]
		public int Utp
		{
			get;
			set;
		}

		[JsonProperty(Order = 4)]
		public int Port
		{
			get;
			set;
		}

		[JsonProperty(Order = 5)]
		public int Client
		{
			get;
			set;
		}

		[JsonProperty(Order = 6)]
		public int Flags
		{
			get;
			set;
		}

		[JsonProperty(Order = 7)]
		public int Progress
		{
			get;
			set;
		}

		[JsonProperty(Order = 8)]
		public int DownloadSpeed
		{
			get;
			set;
		}

		[JsonProperty(Order = 9)]
		public int UploadSpeed
		{
			get;
			set;
		}

		[JsonProperty(Order = 10)]
		public int ReqsOut
		{
			get;
			set;
		}

		[JsonProperty(Order = 11)]
		public int ReqsIn
		{
			get;
			set;
		}

		[JsonProperty(Order = 12)]
		public int Waited
		{
			get;
			set;
		}

		[JsonProperty(Order = 13)]
		public int Uploaded
		{
			get;
			set;
		}

		[JsonProperty(Order = 14)]
		public int Downloaded
		{
			get;
			set;
		}

		[JsonProperty(Order = 15)]
		public int Hasherr
		{
			get;
			set;
		}

		[JsonProperty(Order = 16)]
		public int Peerdl
		{
			get;
			set;
		}

		[JsonProperty(Order = 17)]
		public int Maxup
		{
			get;
			set;
		}

		[JsonProperty(Order = 18)]
		public int Maxdown
		{
			get;
			set;
		}

		[JsonProperty(Order = 19)]
		public int Queued
		{
			get;
			set;
		}

		[JsonProperty(Order = 20)]
		public int Inactive
		{
			get;
			set;
		}

		[JsonProperty(Order = 21)]
		public int Relevance
		{
			get;
			set;
		}
	}
}
