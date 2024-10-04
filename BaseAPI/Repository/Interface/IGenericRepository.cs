using TasksManager.Model.Base;

namespace Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity, ICollectionNameProvider
    {
        Task<List<T>> Get();
        Task<T> GetById(string id);
        Task RemoveById(string id);
        Task<T> Save(T item);
    }
}
