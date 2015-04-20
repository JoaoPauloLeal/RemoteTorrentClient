using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteTorrentClient.Messages;
using RemoteTorrentClient.Models;
using RemoteTorrentClient.UI.Torrent;
using System;
using System.Linq;

namespace RemoteTorrentClient.Tests
{
	
	public class GroupsViewModelTests
	{
		[TestClass]
		public class GetGroup
		{
			[TestMethod]
			public void GetGroupOfSpecificType_ReturnsGroupWithTheSameType()
			{
				var groupsVM = IoC.Get<GroupsViewModel>();
				var types = Enum.GetValues(typeof(GroupType));

				foreach (GroupType item in types)
				{
					if (item == GroupType.Label || item == GroupType.Feed)
						continue;

					var groupVM = groupsVM.GetGroup(item);
					Assert.AreEqual(item, groupVM.Type);
				}
			}

			[TestMethod]
			[ExpectedException(typeof(NotImplementedException))]
			public void GetGroupOfLabelType_FailsWithException()
			{
				var groupsVM = IoC.Get<GroupsViewModel>();
				groupsVM.GetGroup(GroupType.Label);
			}

			[TestMethod]
			[ExpectedException(typeof(NotImplementedException))]
			public void GetGroupOfFeedType_FailsWithException()
			{
				var groupsVM = IoC.Get<GroupsViewModel>();
				groupsVM.GetGroup(GroupType.Feed);
			}
		}

		[TestClass]
		public class UpdateLabelsList
		{
			private static IEventAggregator _eventAggregator;
			private static GroupsViewModel _groupsVM;
			private static GroupItemViewModel _allLabelsVM;

			public static TorrentLabel _label;

			[ClassInitialize]
			public static void Initialize(TestContext context)
			{
				_eventAggregator = IoC.Get<IEventAggregator>();
				_groupsVM = IoC.Get<GroupsViewModel>();
				_allLabelsVM = _groupsVM.GetGroup(GroupType.AllLabels);

				_label = new TorrentLabel()
				{
					Text = "My Label",
					Count = 1,
				};
			}

			[TestMethod]
			public void PublishNewLabel_LabelAdded()
			{
				PublishLabels();
				var labelExistedBefore = _allLabelsVM.Childs.Any((item) => item.DisplayName == _label.Text);
				Assert.IsFalse(labelExistedBefore);

				PublishLabels(_label);
				var labelExistsNow = _allLabelsVM.Childs.Any((item) => item.DisplayName == _label.Text);
				Assert.IsTrue(labelExistsNow);
			}

			[TestMethod]
			public void PublishModifiedLabel_CountValueChanged()
			{
				PublishLabels(_label);
				var oldValue = _allLabelsVM.Childs.First((item) => item.DisplayName == _label.Text).Count;
				Assert.AreEqual(_label.Count, oldValue);

				var expectedValue = oldValue + 1;
				_label.Count = expectedValue;

				PublishLabels(_label);
				var newValue = _allLabelsVM.Childs.First((item) => item.DisplayName == _label.Text).Count;
				Assert.AreEqual(expectedValue, newValue);
			}

			[TestMethod]
			public void PublishWithoutExistingLabel_LabelRemoved()
			{
				PublishLabels(_label);
				var labelExistedBefore = _allLabelsVM.Childs.Any((item) => item.DisplayName == _label.Text);
				Assert.IsTrue(labelExistedBefore);

				PublishLabels();
				var labelExistsNow = _allLabelsVM.Childs.Any((item) => item.DisplayName == _label.Text);
				Assert.IsFalse(labelExistsNow);
				var labelNoLabelStillExists = _allLabelsVM.Childs.Any((item) => item.Type == GroupType.NoLabel);
				Assert.IsTrue(labelNoLabelStillExists);
			}

			private void PublishLabels(params TorrentLabel[] labels)
			{
				var message = new TorrentsUpdated()
				{
					Labels = new TorrentLabelCollection(labels)
				};

				_eventAggregator.PublishOnCurrentThread(message);
			}
		}
	}
}
