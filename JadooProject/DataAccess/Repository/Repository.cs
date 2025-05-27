using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Context;

namespace JadooProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly JadooContext _contex;

        public Repository(JadooContext contex)
        {
            _contex = contex;
        }

        public void Create(T item)
        {
            _contex.Add(item);
            _contex.SaveChanges();
        }

        public void Delete(int Id)
        {
            var value = GetById(Id);
            _contex.Remove(value);
            _contex.SaveChanges();

            
        }

        public T GetById(int Id)
        {
            return _contex.Set<T>().Find(Id);
        }

        public List<T> GetList()
        {
            return _contex.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _contex.Update(item);
            _contex.SaveChanges();  
        }
    }
}
