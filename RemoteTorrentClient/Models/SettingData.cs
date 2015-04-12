using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.Models
{
	class SettingData
	{
		public SettingData()
		{
			throw new NotImplementedException();
		}

		[JsonProperty(Order = 0)]
		public string Name
		{
			get;
			set;
		}

		[JsonProperty(Order = 1)]
		public SettingType Type
		{
			get;
			set;
		}

		[JsonProperty(Order = 2)]
		public string Value
		{
			get;
			set;
		}

		[JsonProperty(Order = 3)]
		public SettingAccess Params
		{
			get;
			set;
		}
	}
}
