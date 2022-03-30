using System.Linq;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public interface IRepository<T> where T : class
	{
		T GimmeOne(int id);

		IQueryable<T> GimmeAll();


		void Insert(T entity);


		void Delete(int id);

	}
}