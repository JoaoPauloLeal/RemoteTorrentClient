using Newtonsoft.Json;
using System;

namespace RemoteTorrentClient.Helpers
{
	static class JsonReaderExtensions
	{
		public static long? ReadAsInt64(this JsonReader reader)
		{
			long? result = null;

			if (reader.Read())
				result = Convert.ToInt64(reader.Value);

			return result;
		}

		public static bool IsEndOfArray(this JsonReader reader)
		{
			return (reader.Read() && reader.TokenType == JsonToken.EndArray);
		}
	}
}
