using System.Collections.Generic;
using System.Linq;

namespace RemoteTorrentClient.Models
{
	public class TorrentLabelCollection : List<TorrentLabel>
	{
		public bool Contains(string text)
		{
			return this.Any(item => item.Text == text);
		}

		public void Add(string text, int count)
		{
			var item = new TorrentLabel()
			{
				Text = text,
				Count = count,
			};

			Add(item);
		}
	}
}
