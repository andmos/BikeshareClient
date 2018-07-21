using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Models;

namespace BikeshareClient.Providers
{
	public class SystemInformationProvider : ProviderBase
    {
    
		public async Task<SystemInformation> GetSystemInformationAsync(string pathUrl)
		{
			var resourceName = "system_information.json";
			var systemInformationDto = await base.GetProivderEndpointDtoAsync<SystemInformationDTO>(pathUrl, resourceName);

			return systemInformationDto.SystemInformation; 
			 
		}   
    }
}
