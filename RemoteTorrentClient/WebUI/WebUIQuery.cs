using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteTorrentClient.WebUI
{
	class WebUIQuery : List<KeyValuePair<string, string>>
	{
		public WebUIQuery()
		{
		}

		public WebUIQuery(IEnumerable<KeyValuePair<string, string>> collection)
			: base(collection)
		{
		}

		public void Add(string key, string value)
		{
			Add(new KeyValuePair<string, string>(key, value));
		}

		public void Add(string key, IEnumerable<string> values)
		{
			foreach (var item in values)
				Add(key, item);
		}

		public override string ToString()
		{
			var pairs = this.Select(item => String.Concat(item.Key, "=", item.Value));
			var query = String.Join("&", pairs);

			return String.Concat('?', query);
		}
	}
}
