using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.DAL.Interface
{
    /// <summary>
    /// CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public interface IRepository <T>
    {
        /// <summary>
        /// Creates new person in database
        /// </summary>
        /// <param name="_object">Object Type</param>
        /// <returns>Object Type</returns>
        public Task<T> Create(T _object);

        /// <summary>
        /// Updates existing record
        /// </summary>
        /// <param name="_object">Object type</param>
        public void Update(T _object);

        /// <summary>
        /// Returns all records
        /// </summary>
        /// <returns>Object Type</returns>
        public IEnumerable<T> GetAll();

        /// <summary>
        /// Returns record by Id
        /// </summary>
        /// <param name="id">Object Type</param>
        /// <returns>Object Type</returns>
        public T GetById(Guid id);

        /// <summary>
        /// Deletes record
        /// </summary>
        /// <param name="_object">Object Type</param>
        public void Delete(T _object);
    }
}
