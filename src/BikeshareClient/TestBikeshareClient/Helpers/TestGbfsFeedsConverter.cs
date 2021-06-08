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
	    private const string TestFile = @"Helpers/TestableGbfsJsonV1.json";

	    [Fact]
		public void ReadJson_GivenValidGbfsJsonFile_ShouldReturnFeedsData()
		{
			var gbfsObject = JsonConvert.DeserializeObject<GbfsDTO>(File.ReadAllText(TestFile));

			Assert.True(gbfsObject.FeedsData.Any());
		}
		
		[Fact]
		public void ReadJson_GivenValidGbfsJsonFile_ShouldReturnFeedsDataWithLanguages()
		{
			var gbfsObject = JsonConvert.DeserializeObject<GbfsDTO>(File.ReadAllText(TestFile));

			var firstLanguage = gbfsObject.FeedsData.Select(l => l.Language).FirstOrDefault();

			Assert.Equal("ar", firstLanguage.Name);
		}
    }
}
