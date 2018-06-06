using System;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
    public class SystemInformationProvider
    {
    
		public async Task<SystemInformation> GetSystemInformationAsync(string pathUrl)
		{
			if(string.IsNullOrEmpty(pathUrl))
			{
				throw new ArgumentNullException();	
			}

			SystemInformationDTO systemInformationDto;

			using(var client = new HttpClient())
			{
				var responseString = await client.GetStringAsync(pathUrl);
				systemInformationDto = JsonConvert.DeserializeObject<SystemInformationDTO>(responseString);
			}

			return systemInformationDto.SystemInformation; 
			 
		}   
    }
}
