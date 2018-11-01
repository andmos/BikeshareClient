using System;
using Xunit;
using Newtonsoft.Json;
using BikeshareClient.DTO;
using System.Linq;
using System.IO;

namespace TestBikeshareClient.Helpers
{
    public class TestGbfsFeedsConverter
    {
		private readonly string TestFile = @"Helpers/TestableGbfsJson.json";

		[Fact]
		public void FeedsConverter_GivenValidGbfsJsonFile_ShouldReturnFeedsData()
		{
			var gbfsObject = JsonConvert.DeserializeObject<GbfsDTO>(File.ReadAllText(TestFile));

			Assert.True(gbfsObject.FeedsData.Any());
		}

		[Fact]
		public void FeedsConverter_GivenValidGbfsJsonFile_ShouldReturnFeedsDataWithLanguages()
		{
			var gbfsObject = JsonConvert.DeserializeObject<GbfsDTO>(File.ReadAllText(TestFile));

			var firstLanguage = gbfsObject.FeedsData.Select(l => l.Language).FirstOrDefault();

			Assert.Equal("ar", firstLanguage.Name);

		}
    }
}
