using System;
using RealEstate.Models;

namespace RealEstate.Services
{
    public interface IGeocodingService
    {
        Task<GeocodeResponse> Geocode(string address);
    }

    public class GeocodingService : IGeocodingService
    {
        public async Task<GeocodeResponse> Geocode(string address)
        {
            // Replace with your Google Maps API key
            string apiKey = "YOUR_API_KEY";

            string requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                string jsonResult = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    GeocodeResponse geocodeResponse = JsonConvert.DeserializeObject<GeocodeResponse>(jsonResult);
                    return geocodeResponse;
                }
                else
                {
                    // Handle failure
                    return null;
                }
            }
        }
    }

}

