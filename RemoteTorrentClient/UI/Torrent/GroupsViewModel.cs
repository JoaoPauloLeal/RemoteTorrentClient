using Caliburn.Micro;
using RemoteTorrentClient.Messages;
using RemoteTorrentClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTorrentClient.UI.Torrent
{
	public class GroupsViewModel : Conductor<GroupItemViewModel>.Collection.AllActive, IHandle<TorrentsUpdated>
	{
		private Func<GroupItemViewModel> _groupItemFactory;

		public GroupsViewModel(IEventAggregator eventAggregator, Func<GroupItemViewModel> groupItemFactory)
		{
			_groupItemFactory = groupItemFactory;
			InitializeDefaultGroups();
			eventAggregator.Subscribe(this);
		}

		private void InitializeDefaultGroups()
		{
			var groups = new List<GroupItemViewModel>()
			{
				_groupItemFactory().With(GroupType.AllTorrents, "AllTorrents", childs: new List<GroupItemViewModel>()
				{
					_groupItemFactory().With(GroupType.Downloading, "Downloading"),
					_groupItemFactory().With(GroupType.Seeding, "Seeding"),
					_groupItemFactory().With(GroupType.Completed, "Completed"),
					_groupItemFactory().With(GroupType.Active, "Active"),
					_groupItemFactory().With(GroupType.Inactive, "Inactive"),
					_groupItemFactory().With(GroupType.AllLabels, "AllLabels", childs: new List<GroupItemViewModel>()
					{
						_groupItemFactory().With(GroupType.NoLabel, "NoLabel"),
					}),
				}),
				_groupItemFactory().With(GroupType.AllFeeds, "AllFeeds"),
			};

			Items.AddRange(groups);
		}

		#region IHandle<TorrentsUpdated>
		public void Handle(TorrentsUpdated message)
		{
			UpdateLabelsList(message.Labels);
		}

		private void UpdateLabelsList(TorrentLabelCollection labels)
		{
			var allLabelsVM = GetGroup(GroupType.AllLabels);
			allLabelsVM.Childs.IsNotifying = false;

			foreach (var label in labels)
			{
				var customLabelVM = allLabelsVM.Childs.FirstOrDefault(item => item.DisplayName == label.Text);

				if (customLabelVM != null)
					customLabelVM.Count = label.Count;
				else
					allLabelsVM.Childs.Add(_groupItemFactory().With(GroupType.Label, label.Text, label.Count));
			}

			var removedCustomLabelVMs = allLabelsVM.Childs.Where(item => item.Type != GroupType.NoLabel && !labels.Contains(item.DisplayName));
			allLabelsVM.Childs.RemoveRange(removedCustomLabelVMs.ToList());

			allLabelsVM.Childs.IsNotifying = true;
			allLabelsVM.Childs.Refresh();
		}

		public GroupItemViewModel GetGroup(GroupType type)
		{
			switch (type)
			{
				case GroupType.AllTorrents:
					return Items[0];
				case GroupType.Downloading:
					return Items[0][0];
				case GroupType.Seeding:
					return Items[0][1];
				case GroupType.Completed:
					return Items[0][2];
				case GroupType.Active:
					return Items[0][3];
				case GroupType.Inactive:
					return Items[0][4];
				case GroupType.AllLabels:
					return Items[0][5];
				case GroupType.NoLabel:
					return Items[0][5][0];
				case GroupType.AllFeeds:
					return Items[1];
				default:
					throw new NotImplementedException();
			}
		}
		#endregion
	}
}
