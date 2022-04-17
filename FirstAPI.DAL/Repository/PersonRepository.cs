using FirstAPI.DAL.Interface;
using FirstAPI.Models.Data;
using FirstAPI.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.DAL.Repository
{
   public class PersonRepository : IRepository<Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Person> Create(Person _object)
        {
            var obj = await _dbContext.Persons.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Person _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return _dbContext.Persons.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetById(Guid id)
        {
            return _dbContext.Persons.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
        }

        public void Update(Person _object)
        {
            _dbContext.Persons.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
