using BidOne.CodeTest.UI.Models;

namespace BidOne.CodeTest.UI.Services
{
    public class PersonApiService:IPersonApiService
    {
        private readonly HttpClient _httpClient;

        public PersonApiService(HttpClient httpClient)
        {  
            _httpClient = httpClient; 
        }

        public async Task<ResponseModel> WriteToJson(PersonModel person)
        {
            var response = await _httpClient.PostAsJsonAsync("api/persons", new { FirstName = person.FirstName, LastName = person.LastName });
            try
            {
                
                response.EnsureSuccessStatusCode();
                return new ResponseModel { IsSuccess = true, Message = "Successfully inserted" };
                
            }
            catch (HttpRequestException)
            {
                return new ResponseModel { IsSuccess = false, Message = response.Content.ReadAsStringAsync().GetAwaiter().GetResult() };
            }


        }
    }
}
