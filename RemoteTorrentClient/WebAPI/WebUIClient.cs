using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RemoteTorrentClient.WebAPI
{
	class WebUIClient : IDisposable
	{
		private HttpClient _client;
		private string _token;

		public WebUIClient(string host, int port, string userName, string password)
		{
			var url = new UriBuilder("http", host, port, "gui/").Uri;
			var handler = CreateHttpHandler(userName, password);

			_client = new HttpClient(handler, false);
			_client.BaseAddress = url;
		}

		private HttpClientHandler CreateHttpHandler(string userName, string password)
		{
			var handler = new HttpClientHandler();
			handler.Credentials = new NetworkCredential(userName, password);
			handler.PreAuthenticate = true;
			handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

			return handler;
		}

		public async Task RenewToken()
		{
			var query = WebUIQueryBuilder.GetToken();
			string responseHtml = await _client.GetStringAsync(query);
			_token = GetTokenFromHtml(responseHtml);
		}

		private string GetTokenFromHtml(string html)
		{
			var doc = new HtmlDocument();
			doc.LoadHtml(html);
			var tokenNode = doc.DocumentNode.SelectSingleNode(".//div[@id='token']");
			return tokenNode.InnerText;
		}

		public async Task<string> GetTorrentsAndLabels()
		{
			var query = WebUIQueryBuilder.GetTorrentsAndLabels(_token);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> GetChangedTorrentsAndLabels(string cacheID)
		{
			var query = WebUIQueryBuilder.GetChangedTorrentsAndLabels(_token, cacheID);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> GetSettings()
		{
			var query = WebUIQueryBuilder.GetSettings(_token);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> SetSetting(string setting, string value)
		{
			var query = WebUIQueryBuilder.SetSetting(_token, setting, value);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> GetFiles(string hash)
		{
			var query = WebUIQueryBuilder.GetFiles(_token, hash);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> GetJobProperties(string hash)
		{
			var query = WebUIQueryBuilder.GetJobProperties(_token, hash);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> SetJobProperty(string setting, string value, string hash)
		{
			var query = WebUIQueryBuilder.SetJobProperty(_token, setting, value, hash);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> AddTorrentURL(string url)
		{
			var query = WebUIQueryBuilder.AddTorrentURL(_token, url);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> GetDirectories()
		{
			var query = WebUIQueryBuilder.GetDirectories(_token);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> AddTorrentFile(string path, int downloadDirectoryIndex = 0, string downloadPath = null)
		{
			var query = WebUIQueryBuilder.AddTorrentFile(_token, path, downloadDirectoryIndex, downloadPath);
			var content = CreateMultipartFormDataContent(path);

			HttpResponseMessage response = await _client.PostAsync(query, content);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}

		private MultipartFormDataContent CreateMultipartFormDataContent(string path)
		{
			var content = new MultipartFormDataContent();

			// double quotes should be removed, otherwise uTorrent will fail to find content
			var boundary = content.Headers.ContentType.Parameters.First();
			boundary.Value = boundary.Value.Substring(1, boundary.Value.Length - 2);

			content.Add(new StreamContent(File.OpenRead(path)), "\"torrent_file\"", path);
			return content;
		}

		public async Task<string> Start(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.Start(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> Stop(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.Stop(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> Pause(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.Pause(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> UnPause(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.UnPause(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> ForceStart(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.ForceStart(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> ReCheck(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.ReCheck(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> Remove(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.Remove(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> RemoveData(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.RemoveData(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> RemoveTorrent(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.RemoveTorrent(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> RemoveDataAndTorrent(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.RemoveDataAndTorrent(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> SetPriority(string priority, int fileIndex, IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.SetPriority(_token, priority, fileIndex, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> QueueBottom(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.QueueBottom(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> QueueDown(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.QueueDown(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> QueueTop(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.QueueTop(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		public async Task<string> QueueUp(IEnumerable<string> hashes)
		{
			var query = WebUIQueryBuilder.QueueUp(_token, hashes);
			return await _client.GetStringAsync(query);
		}

		#region IDisposable
		private volatile bool disposed;

		public void Dispose()
		{
			_client.Dispose();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !this.disposed)
			{
				this.disposed = true;
				_client.Dispose();
			}
		}
		#endregion
	}
}
