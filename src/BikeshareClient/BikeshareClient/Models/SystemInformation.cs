﻿using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
    [DebuggerDisplay("{Name}, {OperatorName}")]
    public class SystemInformation
    {   
        [JsonConstructor]
        public SystemInformation(
            [JsonProperty("system_id")] string id, 
            [JsonProperty("name")] string name, 
            [JsonProperty("language")]string language, 
            [JsonProperty("operator")]string operatorName,
            [JsonProperty("timezone")]string timeZone, 
            [JsonProperty("phone_number")]string phoneNumber,
            [JsonProperty("email")] string email)
        {
            Id = id;
            Name = name;
            Language = language; 
            OperatorName = operatorName;
            TimeZone = timeZone;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Id { get; } 

        public string Name { get; }

        public string Language { get; }

        public string OperatorName { get; }

        public string TimeZone { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

    }
}
