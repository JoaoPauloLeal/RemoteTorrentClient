using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoteTorrentClient.Tests
{
	[TestClass]
	class IoC
	{
		private static SimpleContainer _container;

		[AssemblyInitialize]
		public static void ClassInitialize(TestContext context)
		{
			_container = ContainerConfigurer.GetPreconfiguredContainer();
		}

		public static T Get<T>(string key = null)
		{
			return _container.GetInstance<T>(key);
		}
	}
}
