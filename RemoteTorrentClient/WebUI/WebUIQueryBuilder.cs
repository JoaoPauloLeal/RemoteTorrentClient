using RemoteTorrentClient.Helpers;
using System;
using System.Collections.Generic;

namespace RemoteTorrentClient.WebUI
{
	class WebUIQueryBuilder
	{
		private static class FieldNames
		{
			public const string Token = "token";
			public const string Time = "t";
			public const string List = "list";
			public const string CacheID = "cid";
			public const string Action = "action";
			public const string Hash = "hash";
			public const string Setting = "s";
			public const string Value = "v";
			public const string Priority = "p";
			public const string FileIndex = "f";
			public const string DownloadDirIndex = "download_dir";
			public const string DownloadPath = "path";
		}

		private static class ActionNames
		{
			public const string GetSettings = "getsettings";
			public const string SetSettings = "setsetting";
			public const string GetFiles = "getfiles";
			public const string GetProperties = "getprops";
			public const string SetProperties = "setprops";
			public const string ListDirs = "list-dirs";
			public const string AddUrl = "add-url";
			public const string AddFile = "add-file";
			public const string Start = "start";
			public const string Stop = "stop";
			public const string Pause = "pause";
			public const string UnPause = "unpause";
			public const string ForceStart = "forcestart";
			public const string ReCheck = "recheck";
			public const string Remove = "remove";
			public const string RemoveData = "removedata";
			public const string RemoveTorrent = "removetorrent";
			public const string RemoveDataTorrent = "removedatatorrent";
			public const string SetPriority = "setprio";
			public const string QueueBottom = "queuebottom";
			public const string QueueDown = "queuedown";
			public const string QueueTop = "queuetop";
			public const string QueueUp = "queueup";
		}

		private static WebUIQuery GetBaseQuery(string token)
		{
			return new WebUIQuery()
			{
				{ FieldNames.Token, token },
				{ FieldNames.Time, DateTimeHelper.ToUnixTime(DateTime.Now).ToString() },
			};
		}

		public static string GetToken()
		{
			return "token.html" + new WebUIQuery()
			{
				{ FieldNames.Time, DateTimeHelper.ToUnixTime(DateTime.Now).ToString() },
			}.ToString();
		}

		public static string GetTorrentsAndLabels(string token)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.List, "1"},
			}.ToString();
		}

		public static string GetChangedTorrentsAndLabels(string token, string cacheID)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.List, "1"},
				{ FieldNames.CacheID, cacheID},
			}.ToString();
		}

		public static string GetSettings(string token)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.GetSettings },
			}.ToString();
		}

		public static string SetSetting(string token, string setting, string value)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.SetSettings },
				{ FieldNames.Setting, setting },
				{ FieldNames.Value, value},
			}.ToString();
		}

		public static string GetFiles(string token, string hash)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.GetFiles },
				{ FieldNames.Hash, hash},
			}.ToString();
		}

		public static string GetJobProperties(string token, string hash)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.GetProperties },
				{ FieldNames.Hash, hash},
			}.ToString();
		}

		public static string SetJobProperty(string token, string setting, string value, string hash)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.SetProperties },
				{ FieldNames.Setting, setting },
				{ FieldNames.Value, value},
				{ FieldNames.Hash, hash},
			}.ToString();
		}

		public static string AddTorrentURL(string token, string url)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.AddUrl },
				{ FieldNames.Setting, url },
			}.ToString();
		}

		public static string GetDirectories(string token)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.ListDirs },
			}.ToString();
		}

		public static string AddTorrentFile(string token, string path, int downloadDirectoryIndex, string downloadPath)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.AddFile },
				{ FieldNames.DownloadDirIndex, downloadDirectoryIndex.ToString() },
				{ FieldNames.DownloadPath, downloadPath },
			}.ToString();
		}

		public static string Start(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.Start },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string Stop(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.Stop },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string Pause(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.Pause },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string UnPause(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.UnPause },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string ForceStart(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.ForceStart },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string ReCheck(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.ReCheck },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string Remove(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.Remove },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string RemoveData(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.RemoveData },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string RemoveTorrent(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.RemoveTorrent },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string RemoveDataAndTorrent(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.RemoveDataTorrent },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string SetPriority(string token, string priority, int fileIndex, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.SetPriority },
				{ FieldNames.Priority, priority },
				{ FieldNames.FileIndex, fileIndex.ToString() },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string QueueBottom(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.QueueBottom },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string QueueDown(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.QueueDown },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string QueueTop(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.QueueTop },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}

		public static string QueueUp(string token, IEnumerable<string> hashes)
		{
			return new WebUIQuery(GetBaseQuery(token))
			{
				{ FieldNames.Action, ActionNames.QueueUp },
				{ FieldNames.Hash, hashes },
			}.ToString();
		}
	}
}
