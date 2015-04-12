using Newtonsoft.Json;
using RemoteTorrentClient.Helpers;
using RemoteTorrentClient.Models;
using System;

namespace RemoteTorrentClient.JsonConverters
{
	class LabelConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = new TorrentLabel()
			{
				Label = reader.ReadAsString(),
				TorrentsInLabel = reader.ReadAsInt32().GetValueOrDefault()
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
