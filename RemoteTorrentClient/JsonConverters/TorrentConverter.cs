using Newtonsoft.Json;
using RemoteTorrentClient.Helpers;
using RemoteTorrentClient.Models;
using System;

namespace RemoteTorrentClient.JsonConverters
{
	class TorrentConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = new Torrent()
			{
				Hash = reader.ReadAsString(),
				Status = (TorrentStatus)reader.ReadAsInt32().GetValueOrDefault(),
				Name = reader.ReadAsString(),
				Size = reader.ReadAsInt64().GetValueOrDefault(),
				Progress = reader.ReadAsInt32().GetValueOrDefault(),
				Downloaded = reader.ReadAsInt64().GetValueOrDefault(),
				Uploaded = reader.ReadAsInt64().GetValueOrDefault(),
				Ratio = reader.ReadAsInt32().GetValueOrDefault(),
				UploadSpeed = reader.ReadAsInt64().GetValueOrDefault(),
				DownloadSpeed = reader.ReadAsInt64().GetValueOrDefault(),
				ETA = reader.ReadAsInt32().GetValueOrDefault(),
				Label = reader.ReadAsString(),
				PeersConnected = reader.ReadAsInt32().GetValueOrDefault(),
				PeersInSwarm = reader.ReadAsInt32().GetValueOrDefault(),
				SeedsConnected = reader.ReadAsInt32().GetValueOrDefault(),
				SeedsInSwarm = reader.ReadAsInt32().GetValueOrDefault(),
				Availability = reader.ReadAsInt32().GetValueOrDefault(),
				QueuePosition = reader.ReadAsInt32().GetValueOrDefault(),
				Remaining = reader.ReadAsInt64().GetValueOrDefault(),
				DownloadUrl = reader.ReadAsString(),
				RssFeedUrl = reader.ReadAsString(),
				StatusMessage = reader.ReadAsString(),
				StreamId = reader.ReadAsString(),
				DateAdded = DateTimeHelper.FromUnixTime(reader.ReadAsInt32().GetValueOrDefault()),
				DateCompleted = DateTimeHelper.FromUnixTime(reader.ReadAsInt32().GetValueOrDefault()),
				AppUpdateUrl = reader.ReadAsString(),
				SavePath = reader.ReadAsString(),
				UnknownField1 = reader.ReadAsInt32().GetValueOrDefault(),
				UnknownField2 = reader.ReadAsString(),
			};

			if (!reader.IsEndOfArray())
				throw new JsonReaderException();

			return obj;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
