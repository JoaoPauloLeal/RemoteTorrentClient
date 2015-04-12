using System;

namespace RemoteTorrentClient.Models
{
	[Flags]
	enum RssFilterFlag
	{
		Enable = (1 << 0),
		OrigName = (1 << 1),
		HighPriority = (1 << 2),
		SmartEpFilter = (1 << 3),
		AddStopped = (1 << 4),
	}
}
