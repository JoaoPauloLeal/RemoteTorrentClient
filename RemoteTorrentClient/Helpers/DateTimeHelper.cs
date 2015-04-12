using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Helpers
{
	static class DateTimeHelper
	{
		private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static double ToUnixTime(DateTime dateTime)
		{
			var unixTime = (dateTime.ToUniversalTime() - UnixEpoch);
			return Math.Floor(unixTime.TotalSeconds);
		}

		public static DateTime FromUnixTime(double unixTime)
		{
			return UnixEpoch.AddSeconds(unixTime);
		}
	}
}
