using System;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
	public class SystemInformationProvider : ProviderBase
    {
    
		public async Task<SystemInformation> GetSystemInformationAsync(string pathUrl)
		{
			var systemInformationDto = await base.GetProivderEndpointDtoAsync<SystemInformationDTO>(pathUrl);

			return systemInformationDto.SystemInformation; 
			 
		}   
    }
}
