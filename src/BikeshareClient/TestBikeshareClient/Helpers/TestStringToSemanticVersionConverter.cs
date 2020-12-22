using Xunit;
using Newtonsoft.Json;
using BikeshareClient.DTO;
using System.IO;
using BikeshareClient.Helpers;
using System;

namespace TestBikeshareClient.Helpers
{
    public class TestStringToSemanticVersionConverter
    {
        private readonly string TestFile = @"Helpers/TestableGbfsJsonV1.json";

        [Fact]
        public void ReadJson_GivenValidJSON_ReturnsSemanticVersion()
        {
            var gbfsObject = JsonConvert.DeserializeObject<GbfsDTO>(File.ReadAllText(TestFile));

            Assert.True(gbfsObject.Version.Version.Major == 1);
            Assert.True(gbfsObject.Version.Version.Minor == 1);
        }

        [Fact]
        public void ReadJson_GivenEmptyString_ReturnsDefaultVersion()
        {
            var testString = @"{ ""version"": """" }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(testString);

            Assert.True(testObject.Version.Version.Major == 1);
            Assert.True(testObject.Version.Version.Minor == 0);
        }

        [Fact]
        public void WriteJson_GivenSemanticVersion_ThrowsNotImplementedException()
        {
           var testObject = new TestObject { Version = new SemanticVersion("1.2.3") };

           Assert.Throws<NotImplementedException>(() => JsonConvert.SerializeObject(testObject));
        }

        private class TestObject
        {
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))]
            public SemanticVersion Version { get; set; }
        }
    }
}
