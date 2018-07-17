using System;
namespace BikeshareClient.Models
{
    public class Feed
    {
        public Feed(string name, string url)
        {
			Name = name;
			Url = url;
		}

		public string Name { get; private set; }
		public string Url { get; private set; }
    }
}
