using System;
using BikeshareClient.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace TestBikeshareClient.Helpers
{
    public class TestIntegerToBoolConverter
    {
        private JsonSerializerSettings _jsonSettings;

        public TestIntegerToBoolConverter() 
        {
            _jsonSettings = new JsonSerializerSettings();
            _jsonSettings.TypeNameHandling = TypeNameHandling.Objects;
            _jsonSettings.Converters.Add(new IntegerToBoolConverter());
        }

        [Fact]
        public void ReadJson_GivenJsonWithTrueInteger_DeserializesToTrue() 
        {
            var jsonString = "{ boolInt : 1 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.True(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithFalseInteger_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : 0 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithHigherInteger_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : 2 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithLowerInteger_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : -1 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithFalseBool_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : false }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithTrueBool_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : true }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.True(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithStringAsSomethingRandom_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : 'something-random' }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString, _jsonSettings);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void WriteJson_GivenTrueBoolProperty_SerializesToHighInteger() 
        {
            var testObject = new TestObject { boolInt = true };

            var jsonString = JsonConvert.SerializeObject(testObject, _jsonSettings);

            Assert.Contains("1", jsonString);
        }

        [Fact]
        public void WriteJson_GivenFalseBoolProperty_SerializesToLowInteger()
        {
            var testObject = new TestObject { boolInt = false };

            var jsonString = JsonConvert.SerializeObject(testObject, _jsonSettings);

            Assert.Contains("0", jsonString);
        }

        private class TestObject
        {
            public bool boolInt { get; set; }
        }
    }

}
