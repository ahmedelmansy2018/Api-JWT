using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Country> AddCountry(Country Country)
        {
            var result = await appDbContext.Countries.AddAsync(Country);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCountry(int CountryId)
        {
            var result = await appDbContext.Countries
                .FirstOrDefaultAsync(e => e.CountryId == CountryId);

            if (result != null)
            {
                appDbContext.Countries.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
        public async Task<Country> GetCountry(int CountryId)
        {
            return await appDbContext.Countries

                .FirstOrDefaultAsync(e => e.CountryId == CountryId);
        }


        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await appDbContext.Countries.ToListAsync();
        }

        public async Task<Country> UpdateCountry(Country Country)
        {
            {
                var result = await appDbContext.Countries
                    .FirstOrDefaultAsync(e => e.CountryId == Country.CountryId);

                if (result != null)
                {
                    result.CountryId = Country.CountryId;

                    result.Name = Country.Name;
                    await appDbContext.SaveChangesAsync();

                    return result;
                }

                return null;
            }
        }

       
    }
}