using BidOne.CodeTest.UI.Models;

namespace BidOne.CodeTest.UI.Services
{
    public interface IPersonApiService
    {
        public Task<ResponseModel> WriteToJson(PersonModel person);
    }
}
