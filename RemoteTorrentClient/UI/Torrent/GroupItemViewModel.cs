using Caliburn.Micro;
using System.Collections.Generic;

namespace RemoteTorrentClient.UI.Torrent
{
	public class GroupItemViewModel : Screen
	{
		private GroupType _type;
		private string _text;
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

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				NotifyOfPropertyChange(() => Text);
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

		public virtual BindableCollection<GroupItemViewModel> Childs
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

		public GroupItemViewModel With(GroupType type, string text, int count = 0, IEnumerable<GroupItemViewModel> childs = null)
		{
			IsNotifying = false;
			Initialize(type, text, count, childs);
			IsNotifying = true;

			return this;
		}

		private void Initialize(GroupType type, string text, int count, IEnumerable<GroupItemViewModel> childs)
		{
			Type = type;
			Text = text;
			Count = count;

			if (childs != null)
				Childs = new BindableCollection<GroupItemViewModel>(childs);
		}
	}
}
