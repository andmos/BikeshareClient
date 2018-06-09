using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;

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
