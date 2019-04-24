using System;
using BikeshareClient.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace TestBikeshareClient.Helpers
{
    public class TestIntegerToBoolConverter
    {
        [Fact]
        public void ReadJson_GivenJsonWithTrueInteger_DeserializesToTrue() 
        {
            var jsonString = "{ boolInt : 1 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString);

            Assert.True(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithFalseInteger_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : 0 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithHigherInteger_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : 2 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void ReadJson_GivenJsonWithLowerInteger_DeserializesToFalse()
        {
            var jsonString = "{ boolInt : -1 }";

            var testObject = JsonConvert.DeserializeObject<TestObject>(jsonString);

            Assert.False(testObject.boolInt);
        }

        [Fact]
        public void WriteJson_GivenTrueBoolProperty_SerializesToHighInteger() 
        {
            var testObject = new TestObject { boolInt = true };

            var jsonString = JsonConvert.SerializeObject(testObject);

            Assert.Contains("1", jsonString);
        }

        [Fact]
        public void WriteJson_GivenFalseBoolProperty_SerializesToLowInteger()
        {
            var testObject = new TestObject { boolInt = false };

            var jsonString = JsonConvert.SerializeObject(testObject);

            Assert.Contains("0", jsonString);
        }

        private class TestObject
        {
            [JsonConverter(typeof(IntegerToBoolConverter))]
            public bool boolInt { get; set; }
        }
    }

}
