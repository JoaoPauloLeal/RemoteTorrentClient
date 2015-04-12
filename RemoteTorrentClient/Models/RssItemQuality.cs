using System;

namespace RemoteTorrentClient.Models
{
	[Flags]
	enum RssItemQuality
	{
		All = -1,
		None = 0,
		HDTV = (1 << 0),
		TVRIP = (1 << 1),
		DVDRIP = (1 << 2),
		SVCD = (1 << 3),
		DSRIP = (1 << 4),
		DVBRIP = (1 << 5),
		PDTV = (1 << 6),
		HRHDTV = (1 << 7),
		HRPDTV = (1 << 8),
		DVDR = (1 << 9),
		DVDSCR = (1 << 10),
		HD720P = (1 << 11),
		HD1080I = (1 << 12),
		HD1080P = (1 << 13),
		WEBRIP = (1 << 14),
		SATRIP = (1 << 15),
	}
}
