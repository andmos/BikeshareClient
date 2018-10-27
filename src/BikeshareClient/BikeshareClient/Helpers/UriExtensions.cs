using System;
using System.Linq;
namespace BikeshareClient.Helpers
{
	public static class UriExtensions
    {
        public static Uri Append(this Uri uri, params string[] paths)
        {
            return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) =>
			                               string.Format("{0}/{1}", current.TrimEnd('/'), path.TrimStart('/'))));
        }
		public static Uri RemoveLastElement(this Uri uri)
		{
			var noLastSegment = string.Format("{0}://{1}", uri.Scheme, uri.Authority);

            for (int i = 0; i < uri.Segments.Length - 1; i++)
            {
                noLastSegment += uri.Segments[i];
            }

			return new Uri(noLastSegment.Trim("/".ToCharArray()));
		}
    }
}
