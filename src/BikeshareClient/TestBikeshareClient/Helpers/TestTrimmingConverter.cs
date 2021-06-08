using System;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Xunit;

namespace TestBikeshareClient.Helpers
{
    public class TestTrimmingConverter
    {
        [Fact]
        public void ReadJson_GivenJsonWithWhiteSpace_TrimsTestProperty() 
        {
            string testJsonString = "{\"key\": \"Value  \"}";

            var testModel = JsonConvert.DeserializeObject<TestModel>(testJsonString, new TrimmingConverter());

            Assert.Equal("Value", testModel.Key);
        }

        [Fact]
        public void ReadJson_GivenStationInformationJsonWithTrailingSpace_TrimsAddress() 
        {
            string testStationInformationJson = "{\"station_id\": \"293\", \"name\": \"S. P. Andersens vei   \", \"address\": \"S. P. Andersens vei\", \"lat\": 63.409888448864876, \"lon\": 10.405212902563903, \"capacity\": 18}";

            var station = JsonConvert.DeserializeObject<Station>(testStationInformationJson);

            Assert.Equal("S. P. Andersens vei", station.Address);
        }

        private class TestModel
        {
            public string Key { get; set; }
        }
    }


}
