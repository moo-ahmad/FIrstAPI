using FirstAPI.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.BLL.Interface
{
    /// <summary>
    /// Person service interface
    /// </summary>
   public interface IPersonService
    {
        public IEnumerable<Person> GetPersonByUserId(Guid userId);
        public IEnumerable<Person> GetAllPersons();
        public Person GetPersonByUserName(string userName);
        public Task<Person> AddPerson(Person person);
        public bool DeletePersonByEmail(string userEmail);
        public bool UpdatePerson(Person person);
    }
}
