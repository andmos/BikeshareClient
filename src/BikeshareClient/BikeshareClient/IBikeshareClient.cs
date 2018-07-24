using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.Models;

namespace BikeshareClient
{
    public interface IBikeshareClient
    {
		/// <summary>
		/// Gets the GBFS system information.
        /// </summary>
        /// <returns>The system information.</returns>
		Task<SystemInformation> GetSystemInformationAsync();

        /// <summary>
		/// Gets the GBFS bike stations.
        /// </summary>
        /// <returns>The stations async.</returns>
		Task<IEnumerable<Station>> GetStationsAsync();

        /// <summary>
		/// Gets the status for all available bike stations.
        /// </summary>
        /// <returns>The stations status async.</returns>
		Task<IEnumerable<StationStatus>> GetStationsStatusAsync();

        /// <summary>
        /// Gets the status for all available bikes.
        /// </summary>
        /// <returns>The bike status async.</returns>
		Task<IEnumerable<BikeStatus>> GetBikeStatusAsync();
	}
}
