using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteTorrentClient.UI.Torrent.Client;

namespace RemoteTorrentClient.Tests
{
	public class ClientSelectorViewModelTests
	{
		[TestClass]
		class AddClient
		{
			[TestMethod]
			public void AddingClient_InitializesNewInstanceOfClientVM()
			{
				var clientSelectorVM = IoC.Get<ClientSelectorViewModel>();
				Assert.AreEqual(0, clientSelectorVM.Items.Count);
				clientSelectorVM.AddClient(false);
				Assert.AreEqual(1, clientSelectorVM.Items.Count);
				Assert.IsNotNull(clientSelectorVM.ActiveItem);
			}
		}
	}
}
