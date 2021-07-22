using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models
{
   
       public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int CountryId);
        Task<Country> AddCountry(Country Country);
        Task<Country> UpdateCountry(Country Country);
        Task DeleteCountry(int CountryId);
        
    }
}
