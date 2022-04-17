using FirstAPI.BLL.Interface;
using FirstAPI.DAL.Interface;
using FirstAPI.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.BLL.Service
{
    /// <summary>
    /// Implements IPersonService
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> GetPersonByUserId(Guid userId)
        {
            return _repository.GetAll().Where(x => x.Id == userId).ToList();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetPersonByUserName(string userName)
        {
            return _repository.GetAll().Where(x => x.UserName == userName).FirstOrDefault();
        }

        public async Task<Person> AddPerson(Person person)
        {
            return await _repository.Create(person);
        }

        public bool DeletePersonByEmail(string userEmail)
        {
            try
            {
                var dataList = _repository.GetAll().Where(x => x.UserEmail == userEmail).ToList();

                foreach(var data in dataList)
                {
                    _repository.Delete(data);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePerson(Person person)
        {
            try
            {
                var dataList = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();

                foreach (var data in dataList)
                {
                    _repository.Update(data);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
