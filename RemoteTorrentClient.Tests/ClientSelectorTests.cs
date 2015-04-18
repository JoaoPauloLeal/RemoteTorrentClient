using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Caliburn.Micro;
using RemoteTorrentClient.UI.Torrent.Client;

namespace RemoteTorrentClient.Tests
{
	[TestClass]
	public class ClientSelectorTests
	{
		private ClientSelectorViewModel _clientSelector;

		[TestMethod]
		public void AddClient()
		{
			_clientSelector = IoC.Get<ClientSelectorViewModel>();
			_clientSelector.AddClient(false);
			Assert.IsNotNull(_clientSelector.ActiveItem);
		}
	}
}
