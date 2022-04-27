using DOPYAO_ADT_2021_22_2.Data;
using DOPYAO_ADT_2021_22_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public class AnimalRepository : Repository<Animal>, IAnimalRepository
	{
		public AnimalRepository(ShelterDbContext context) : base(context)
		{
		}

		public void ChangeName(int id, string newName)
		{
			var animal = this.GimmeOne(id);
			if (animal == null)
			{
				throw new InvalidOperationException("Record not found");
			}
			animal.Name = newName;
			this.Context.SaveChanges();
		}

		public override void Delete(int id)
		{
			Animal obj = this.GimmeOne(id);
			this.Context.Set<Animal>().Remove(obj);
			this.Context.SaveChanges();
		}

		public override Animal GimmeOne(int id)
		{
			return this.GimmeAll().SingleOrDefault(x => x.Id == id);
		}

		public override void Insert(Animal entity)
		{
			this.Context.Set<Animal>().Add(entity);
			this.Context.SaveChanges();
		}
	}
}
