using System;

namespace RemoteTorrentClient.Models
{
	[Flags]
	enum bt_transp_disposition
	{
		Utp = (OutUtp | InUtp),
		OutTcp = (1 << 0),
		OutUtp = (1 << 1),
		InTcp = (1 << 2),
		InUtp = (1 << 3),
		UtpNewHeader = (1 << 4),
	}
}
