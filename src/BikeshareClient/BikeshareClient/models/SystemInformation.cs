using System;
using Newtonsoft.Json;

namespace BikeshareClient.models
{
    public class SystemInformation
    {      
		public SystemInformation(string id, string name, string language, string operatorName, string timeZone, string phoneNumber, string email)
		{
			Id = id;
			Name = name;
			Language = language; 
			OperatorName = operatorName;
			TimeZone = timeZone;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		[JsonProperty("id")]
		public string Id { get; private set; } 

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("language")]
        public string Language { get; private set; }

		[JsonProperty("operator")]
		public string OperatorName { get; private set; }

		[JsonProperty("timezone")]
		public string TimeZone { get; private set; }

		[JsonProperty("phone_number")]
		public string PhoneNumber { get; private set; }

		[JsonProperty("email")]
		public string Email { get; private set; }

    }
}
