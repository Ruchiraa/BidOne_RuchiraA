namespace BidOne.CodeTest.Api.Models
{
    public class PersonConvertion
    {
        public BidOne.CodeTest.Core.Entities.Person ConvertToPersonRequest(PersonRequest personRequest)
        {
            if (personRequest == null)
            {
                return null;
            }

            var request = new BidOne.CodeTest.Core.Entities.Person
            {
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
            };

            return request;
        }
    }
}
