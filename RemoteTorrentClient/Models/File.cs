using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Models
{
	class File
	{
		public File()
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
		public int Size
		{
			get;
			set;
		}

		[JsonProperty(Order = 2)]
		public int Downloaded
		{
			get;
			set;
		}

		[JsonProperty(Order = 3)]
		public int Priority
		{
			get;
			set;
		}

		[JsonProperty(Order = 4)]
		public int FirstPiece
		{
			get;
			set;
		}

		[JsonProperty(Order = 5)]
		public int PiecesCount
		{
			get;
			set;
		}

		[JsonProperty(Order = 6)]
		public int Streamable
		{
			get;
			set;
		}

		[JsonProperty(Order = 7)]
		public int EncodedRate
		{
			get;
			set;
		}

		[JsonProperty(Order = 8)]
		public int Duration
		{
			get;
			set;
		}

		[JsonProperty(Order = 9)]
		public int Width
		{
			get;
			set;
		}

		[JsonProperty(Order = 10)]
		public int Height
		{
			get;
			set;
		}

		[JsonProperty(Order = 11)]
		public int StreamETA
		{
			get;
			set;
		}

		[JsonProperty(Order = 12)]
		public int Streamability
		{
			get;
			set;
		}
	}
}
