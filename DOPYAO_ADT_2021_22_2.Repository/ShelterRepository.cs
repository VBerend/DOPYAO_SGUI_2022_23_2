using DOPYAO_ADT_2021_22_2.Data;
using DOPYAO_ADT_2021_22_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public class ShelterRepository : Repository<Shelter>, IShelterRepository
	{
		public ShelterRepository(ShelterDbContext context) : base(context)
		{
		}

		public void ChangeAddress(int id, string newCity, string newAddress)
		{
			var shelter = this.GimmeOne(id);
			if (shelter == null)
			{
				throw new InvalidOperationException("Record not found");
			}
			shelter.City = newCity;
			shelter.Address = newAddress;
			this.Context.SaveChanges();
		}

		public override void Delete(int id)
		{
			Shelter obj = this.GimmeOne(id);
			this.Context.Set<Shelter>().Remove(obj);
			this.Context.SaveChanges();
		}

		public override Shelter GimmeOne(int id)
		{
			return this.GimmeAll().SingleOrDefault(x => x.Id == id);
		}

		public override void Insert(Shelter entity)
		{
			this.Context.Set<Shelter>().Add(entity);
			this.Context.SaveChanges();
		}
	}
}
