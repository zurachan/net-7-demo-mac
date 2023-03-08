using bikestore.Core.Entity;

namespace bikestore.Core
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns>List Entities</returns>
        List<T> GetAll();

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(int id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        ExecutionResult Insert(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        ExecutionResult Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Entity</param>
        ExecutionResult Delete(int id);
    }
}

