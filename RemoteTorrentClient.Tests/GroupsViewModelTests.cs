using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			public void GetGroup_GroupOfSpecificType_ReturnsGroupWithTheSameType()
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
			public void GetGroup_GroupOfLabelType_FailsWithException()
			{
				var groupsVM = IoC.Get<GroupsViewModel>();
				groupsVM.GetGroup(GroupType.Label);
			}

			[TestMethod]
			[ExpectedException(typeof(NotImplementedException))]
			public void GetGroup_GroupOfFeedType_FailsWithException()
			{
				var groupsVM = IoC.Get<GroupsViewModel>();
				groupsVM.GetGroup(GroupType.Feed);
			}
		}

		[TestClass]
		public class UpdateLabelsList
		{
			private static Func<GroupItemViewModel> _groupItemFactory;
			private GroupItemViewModel _labelsGroupVM;

			[ClassInitialize]
			public static void Initialize(TestContext context)
			{
				_groupItemFactory = IoC.Get<Func<GroupItemViewModel>>();
			}

			[TestInitialize]
			public void Initialize()
			{
				var groupsVM = IoC.Get<GroupsViewModel>();
				_labelsGroupVM = groupsVM.GetGroup(GroupType.AllLabels);
			}

			[TestMethod]
			public void UpdateOrAddLabelVMs_NewLabel_NewLabelCreatedAndOldLabelStaysAsIs()
			{
				var labels = new TorrentLabelCollection()
				{
					{ "My Label", 1 },
				};

				GroupsViewModel.UpdateOrAddLabelVMs(labels, _labelsGroupVM, _groupItemFactory);

				Assert.AreEqual(2, _labelsGroupVM.Childs.Count);
				var noLabelVM = _labelsGroupVM.Childs.FirstOrDefault(x => x.Type == GroupType.NoLabel);
				Assert.IsNotNull(noLabelVM);
				var customLabelVM = _labelsGroupVM.Childs.FirstOrDefault(x => x.Type == GroupType.Label);
				Assert.AreEqual(labels.First().Text, customLabelVM.Text);
				Assert.AreEqual(labels.First().Count, customLabelVM.Count);
			}

			[TestMethod]
			public void UpdateOrAddLabelVMs_ModifiedLabelCount_LabelCountValueIncremented()
			{
				var labels = new TorrentLabelCollection()
				{
					{ "My Label", 1 },
				};

				GroupsViewModel.UpdateOrAddLabelVMs(labels, _labelsGroupVM, _groupItemFactory);
				labels.First().Count++;
				GroupsViewModel.UpdateOrAddLabelVMs(labels, _labelsGroupVM, _groupItemFactory);

				Assert.AreEqual(2, _labelsGroupVM.Childs.Count);
				var noLabelVM = _labelsGroupVM.Childs.FirstOrDefault(x => x.Type == GroupType.NoLabel);
				Assert.IsNotNull(noLabelVM);
				var customLabelVM = _labelsGroupVM.Childs.FirstOrDefault(x => x.Type == GroupType.Label);
				Assert.AreEqual(labels.First().Text, customLabelVM.Text);
				Assert.AreEqual(labels.First().Count, customLabelVM.Count);
			}

			[TestMethod]
			public void RemoveOldLabelVMs_LabelRemoved_LabelIsGone()
			{
				var labels = new TorrentLabelCollection()
				{
					{ "My Label", 1 },
				};

				GroupsViewModel.UpdateOrAddLabelVMs(labels, _labelsGroupVM, _groupItemFactory);
				labels.RemoveAt(0);
				GroupsViewModel.RemoveOldLabelVMs(labels, _labelsGroupVM);

				Assert.AreEqual(1, _labelsGroupVM.Childs.Count);
				var noLabelVM = _labelsGroupVM.Childs.FirstOrDefault(x => x.Type == GroupType.NoLabel);
				Assert.IsNotNull(noLabelVM);
				var customLabelVM = _labelsGroupVM.Childs.FirstOrDefault(x => x.Type == GroupType.Label);
				Assert.IsNull(customLabelVM);
			}
		}
	}
}
