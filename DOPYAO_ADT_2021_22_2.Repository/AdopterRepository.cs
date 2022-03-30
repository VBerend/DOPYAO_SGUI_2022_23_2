using DOPYAO_ADT_2021_22_2.Data;
using DOPYAO_ADT_2021_22_2.Models;
using System;
using System.Linq;

namespace DOPYAO_ADT_2021_22_2.Repository
{
	public class AdopterRepository : Repository<Adopter>, IAdopterRepository
	{
		public AdopterRepository(ShelterDbContext context) : base(context)
		{
		}

		public void ChangeAddress(int id, string newCity, string newAddress)
		{
			var adopter = this.GimmeOne(id);
			if (adopter == null)
			{
				throw new InvalidOperationException("Record not found");
			}
			adopter.City = newCity;
			adopter.Address = newAddress;
			this.Context.SaveChanges();
		}

		public void ChangeHasKids(int id, bool hasKid)
		{
			var adopter = this.GimmeOne(id);
			if (adopter == null)
			{
				throw new InvalidOperationException("Record not found");
			}
			adopter.HasKid = hasKid;
			this.Context.SaveChanges();
		}

		public override void Delete(int id)
		{
			Adopter obj = this.GimmeOne(id);
			this.Context.Set<Adopter>().Remove(obj);
			this.Context.SaveChanges();
		}

		public override Adopter GimmeOne(int id)
		{
			return this.GimmeAll().SingleOrDefault(x => x.Id == id);
		}

		public override void Insert(Adopter entity)
		{
			this.Context.Set<Adopter>().Add(entity);
			this.Context.SaveChanges();
		}
	}
}
