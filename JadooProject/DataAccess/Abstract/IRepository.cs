namespace JadooProject.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
       List<T> GetList();

        T GetById(int Id);

        void Create(T item);

        void Delete(int Id);

        void Update(T item);

      
    }
}
