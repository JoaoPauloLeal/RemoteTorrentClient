using Caliburn.Micro;
using RemoteTorrentClient.WebUI;

namespace RemoteTorrentClient
{
	public class ShellViewModel : PropertyChangedBase, IShell
	{
		private WebUIClient _client;

		public ShellViewModel()
		{
			string host = "";
			int port = 8080;
			string userName = "";
			string password = "";

			_client = new WebUIClient(host, port, userName, password);
		}
	}
}