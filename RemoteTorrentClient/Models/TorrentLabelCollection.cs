using System.Collections.Generic;
using System.Linq;

namespace RemoteTorrentClient.Models
{
	public class TorrentLabelCollection : List<TorrentLabel>
	{
		public TorrentLabelCollection(IEnumerable<TorrentLabel> collection)
			: base(collection)
		{
		}

		public bool Contains(string text)
		{
			return this.Any(item => item.Text == text);
		}
	}
}
