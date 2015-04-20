using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.UI.Torrent
{
	public class GroupItemViewModel : Screen
	{
		private GroupType _type;
		private int _count;

		public GroupType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				NotifyOfPropertyChange(() => Type);
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				_count = value;
				NotifyOfPropertyChange(() => Count);
			}
		}

		public BindableCollection<GroupItemViewModel> Childs
		{
			get;
			private set;
		}

		public GroupItemViewModel this[int index]
		{
			get
			{
				return Childs[index];
			}
		}

		public GroupItemViewModel With(GroupType type, string name, int count = 0, IEnumerable<GroupItemViewModel> childs = null)
		{
			IsNotifying = false;
			Initialize(type, name, count, childs);
			IsNotifying = true;

			return this;
		}

		private void Initialize(GroupType type, string name, int count, IEnumerable<GroupItemViewModel> childs)
		{
			Type = type;
			DisplayName = name;
			Count = count;

			if (childs != null)
				Childs = new BindableCollection<GroupItemViewModel>(childs);
		}
	}
}
