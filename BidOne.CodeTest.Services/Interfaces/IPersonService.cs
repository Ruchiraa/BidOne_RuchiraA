using BidOne.CodeTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOne.CodeTest.Services.Interfaces
{
    public interface IPersonService
    {
        public bool WriteToJsonFile(Person person);
    }
}
