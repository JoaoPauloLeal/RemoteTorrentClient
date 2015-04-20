using System;

namespace RemoteTorrentClient.Models
{
	[Flags]
	public enum TorrentStatus
	{
		Started = (1 << 0),
		Checking = (1 << 1),
		StartAfterCheck = (1 << 2),
		Checked = (1 << 3),
		Error = (1 << 4),
		Paused = (1 << 5),
		Queued = (1 << 6),
		Loaded = (1 << 7),
	}
}
