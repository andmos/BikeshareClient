using BikeshareClient.Helpers;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestBikeshareClient.Helpers
{
    public class TestSemanticVersion
    {
        [Fact]
        public void SemanticVersion_GivenValidJSONString_ReturnsSemanticVersion()
        {
            var json = @"{ Version : ""1.2.3"" }";
            SemanticVersion parsedValue;

            var semanticModel = JsonConvert.DeserializeObject<Dictionary<string, string>>(json).FirstOrDefault();
            var semantic = SemanticVersion.TryParse(semanticModel.Value, out parsedValue);

            Assert.True(semantic);
            Assert.True(parsedValue.Version.Major == 1);
            Assert.True(parsedValue.Version.Minor == 2);
            Assert.True(parsedValue.Version.Build == 3);
        }

        [Fact]
        public void SemanticVersion_GivenValidSemanticVersionString_ReturnsCorrectObject()
        {
            var semantic = new SemanticVersion("1.2.3");

            Assert.True(semantic.Version.Major == 1);
            Assert.True(semantic.Version.Minor == 2);
            Assert.True(semantic.Version.Build == 3);
        }

        [Fact]
        public void SemanticVersion_GivenValidSemanticVersionIntegers_ReturnsCorrectObject()
        {
            var semantic = new SemanticVersion(1,2,3,4);

            Assert.True(semantic.Version.Major == 1);
            Assert.True(semantic.Version.Minor == 2);
            Assert.True(semantic.Version.Build == 3);
            Assert.True(semantic.Version.Revision == 4);
        }

        [Fact]
        public void SemanticVersion_GivenValidSemanticVersionSpecial_ReturnsCorrectObject()
        {
            var semantic = new SemanticVersion(1, 2, 3, "build-0001");

            Assert.Equal(semantic.SpecialVersion, "build-0001");
        }

        [Fact]
        public void SemanticVersion_GivenValidVersion_ReturnsCorrectObject()
        {
            var semantic = new SemanticVersion(new Version(1,2,3));

            Assert.True(semantic.Version.Major == 1);
            Assert.True(semantic.Version.Minor == 2);
            Assert.True(semantic.Version.Build == 3);
        }

    }


}
