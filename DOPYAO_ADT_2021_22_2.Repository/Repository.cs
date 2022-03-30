using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		private DbContext context;

		public Repository(DbContext context)
		{
			this.context = context;
		}

		protected DbContext Context { get => this.context; set => this.context = value; }

		public abstract void Delete(int id);

		public IQueryable<T> GimmeAll()
		{
			return this.context.Set<T>();
		}
		public abstract T GimmeOne(int id);

		public abstract void Insert(T entity);
	}
}
