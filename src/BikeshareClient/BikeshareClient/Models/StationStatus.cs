using System;
using System.Diagnostics;
using BikeshareClient.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.Models
{
	[DebuggerDisplay("Station id {Id} has {BikesAvailable} bikes available, {BikesDisabled} bikes disabled, {DocksAvailable} docs available, {DocksDisabled} docs disabled")]
    public class StationStatus
    {
		[JsonConstructor]
		public StationStatus(
			[JsonProperty("station_id")] string id,
			[JsonProperty("num_bikes_available")] int bikesAvailable,
			[JsonProperty("num_bikes_disabled")] int bikesDisabled,
			[JsonProperty("num_docks_available")]int docksAvailable, 
			[JsonProperty("is_installed"),JsonConverter(typeof(IntegerToBoolConverter))]bool installed,
			[JsonProperty("is_renting"), JsonConverter(typeof(IntegerToBoolConverter))]bool renting,
			[JsonProperty("is_returning"), JsonConverter(typeof(IntegerToBoolConverter))]bool returning, 
			[JsonProperty("num_docks_disabled")]int docsDisabled,
			[JsonProperty("last_reported"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastReported)
        {
			Id = id;
			BikesAvailable = bikesAvailable;
			BikesDisabled = bikesDisabled;
			DocksAvailable = docksAvailable;
			Installed = installed;
			Renting = renting;
			Returning = returning;
			DocksDisabled = docsDisabled;
			LastReported = lastReported;
		}

		public string Id { get; }

		public int BikesAvailable { get; }

		public int BikesDisabled { get; }

		public int DocksAvailable { get; }

		public bool Installed { get; }

		public bool Renting { get; }

		public bool Returning { get; }

		public int DocksDisabled { get; }

		public DateTime LastReported { get; }

	}
}
