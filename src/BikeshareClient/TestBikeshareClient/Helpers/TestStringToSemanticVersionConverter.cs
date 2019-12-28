using System;
using Xunit;
using Newtonsoft.Json;
using BikeshareClient.DTO;
using System.Linq;
using System.IO;
using BikeshareClient.Helpers;
using System.Collections;
using System.Collections.Generic;

namespace TestBikeshareClient.Helpers
{
    public class TestStringToSemanticVersionConverter
    {
        private readonly string TestFile = @"Helpers/TestableGbfsJson.json";

        [Fact]
        public void ReadJson_GivenValidJSON_ReturnsSemanticVersion()
        {
            var gbfsObject = JsonConvert.DeserializeObject<GbfsDTO>(File.ReadAllText(TestFile));

            Assert.True(gbfsObject.Version.Version.Major == 1);
            Assert.True(gbfsObject.Version.Version.Minor == 5);
        }

        [Fact]
        public void ReadJson_GivenEmptyString_ReturnsDefaultVersion()
        {
            var testString = @"{ ""version"": """" }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(testString);

            Assert.True(testObject.Version.Version.Major == 1);
            Assert.True(testObject.Version.Version.Minor == 0);

        }

        private class TestObject
        {
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))]
            public SemanticVersion Version { get; set; }
        }
    }
}
