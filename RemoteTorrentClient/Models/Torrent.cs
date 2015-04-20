using Newtonsoft.Json;
using RemoteTorrentClient.JsonConverters;
using System;

namespace RemoteTorrentClient.Models
{
	[JsonConverter(typeof(TorrentConverter))]
	public class Torrent
	{
		/// <summary>
		/// Torrent hash is a 40-character ASCII string.
		/// <example>"0CE39652D46A3B9DA3C69D33F54FA7CA3C3CE75E"</example>
		/// </summary>
		[JsonProperty(Order = 0)]
		public string Hash
		{
			get;
			set;
		}

		/// <summary>
		/// The STATUS is a bitwise value, which is obtained by adding
		/// up the different values for corresponding statuses.
		/// <example>201</example>
		/// </summary>
		[JsonProperty(Order = 1)]
		public TorrentStatus Status
		{
			get;
			set;
		}

		/// <summary>
		/// Torrent name.
		/// </summary>
		[JsonProperty(Order = 2)]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Total content size in bytes.
		/// <example>17442868397</example>
		/// </summary>
		[JsonProperty(Order = 3)]
		public long Size
		{
			get;
			set;
		}

		/// <summary>
		/// Download progress per mille.
		/// <example>1000</example>
		/// </summary>
		[JsonProperty(Order = 4)]
		public int Progress
		{
			get;
			set;
		}

		/// <summary>
		/// Downloaded amount in bytes.
		/// Might be larger than Size value.
		/// <example>17476537517</example>
		/// </summary>
		[JsonProperty(Order = 5)]
		public long Downloaded
		{
			get;
			set;
		}

		/// <summary>
		/// Uploaded amount in bytes.
		/// <example>2569469952</example>
		/// </summary>
		[JsonProperty(Order = 6)]
		public long Uploaded
		{
			get;
			set;
		}

		/// <summary>
		/// Downloaded/Uploaded ratio per mille.
		/// <example>147</example>
		/// </summary>
		[JsonProperty(Order = 7)]
		public int Ratio
		{
			get;
			set;
		}

		/// <summary>
		/// Upload speed in bytes per second.
		/// <example>64737</example>
		/// </summary>
		[JsonProperty(Order = 8)]
		public long UploadSpeed
		{
			get;
			set;
		}

		/// <summary>
		/// Download speed in bytes per second.
		/// <example>0</example>
		/// </summary>
		[JsonProperty(Order = 9)]
		public long DownloadSpeed
		{
			get;
			set;
		}

		/// <summary>
		/// Estimated time in seconds.
		/// <example>-1</example>
		/// </summary>
		[JsonProperty(Order = 10)]
		public int ETA
		{
			get;
			set;
		}

		/// <summary>
		/// Torrent label.
		/// <example>"Podcasts"</example>
		/// </summary>
		[JsonProperty(Order = 11)]
		public string Label
		{
			get;
			set;
		}

		[JsonProperty(Order = 12)]
		public int PeersConnected
		{
			get;
			set;
		}

		[JsonProperty(Order = 13)]
		public int PeersInSwarm
		{
			get;
			set;
		}

		[JsonProperty(Order = 14)]
		public int SeedsConnected
		{
			get;
			set;
		}

		[JsonProperty(Order = 15)]
		public int SeedsInSwarm
		{
			get;
			set;
		}

		/// <summary>
		/// Unique copies of the file are available between yourself and the peers (1/65536ths).
		/// <example>98682</example>
		/// </summary>
		[JsonProperty(Order = 16)]
		public int Availability
		{
			get;
			set;
		}

		/// <summary>
		/// <example>-1</example>
		/// </summary>
		[JsonProperty(Order = 17)]
		public int QueuePosition
		{
			get;
			set;
		}

		/// <summary>
		/// Remaining bytes to download.
		/// <example>0</example>
		/// </summary>
		[JsonProperty(Order = 18)]
		public long Remaining
		{
			get;
			set;
		}

		/// <summary>
		/// <example>""</example>
		/// </summary>
		[JsonProperty(Order = 19)]
		public string DownloadUrl
		{
			get;
			set;
		}

		/// <summary>
		/// <example>""</example>
		/// </summary>
		[JsonProperty(Order = 20)]
		public string RssFeedUrl
		{
			get;
			set;
		}

		/// <summary>
		/// <example>"Seeding 100.0 %"</example>
		/// </summary>
		[JsonProperty(Order = 21)]
		public string StatusMessage
		{
			get;
			set;
		}

		/// <summary>
		/// <example>"7413f40c"</example>
		/// </summary>
		[JsonProperty(Order = 22)]
		public string StreamId
		{
			get;
			set;
		}

		/// <summary>
		/// <example>1427830832</example>
		/// </summary>
		[JsonProperty(Order = 23)]
		public DateTime DateAdded
		{
			get;
			set;
		}

		/// <summary>
		/// <example>1427956295</example>
		/// </summary>
		[JsonProperty(Order = 24)]
		public DateTime DateCompleted
		{
			get;
			set;
		}

		/// <summary>
		/// <example>""</example>
		/// </summary>
		[JsonProperty(Order = 25)]
		public string AppUpdateUrl
		{
			get;
			set;
		}

		/// <summary>
		/// <example>"D:\\Downloads"</example>
		/// </summary>
		[JsonProperty(Order = 26)]
		public string SavePath
		{
			get;
			set;
		}

		/// <summary>
		/// <example>0</example>
		/// </summary>
		[JsonProperty(Order = 27)]
		public int UnknownField1
		{
			get;
			set;
		}

		/// <summary>
		/// <example>"42B0C7DB"</example>
		/// </summary>
		[JsonProperty(Order = 28)]
		public string UnknownField2
		{
			get;
			set;
		}
	}
}
