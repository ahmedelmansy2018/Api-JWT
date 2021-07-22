using Login_Jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountrieesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
      
        public CountrieesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }


         [HttpGet]
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                return Ok(await countryRepository.GetCountries());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            try
            {
                var coun = await countryRepository.GetCountry(id);

                if (coun == null)
                {
                    return NotFound();
                }

                return Ok (coun);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                if (country == null)
                    return BadRequest();

  
                var createdCountry = await countryRepository.AddCountry(country);

                return CreatedAtAction(nameof(GetCountry),
                    new { id = createdCountry.CountryId }, createdCountry);
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Country record");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, Country country)
        {
            try
            {
                if (id != country.CountryId)
                    return BadRequest("Country ID mismatch");

                var CountryToUpdate = await countryRepository.GetCountry(id);

                if (CountryToUpdate == null)
                {
                    return NotFound($"Country with Id = {id} not found");
                }

                return await countryRepository.UpdateCountry(country);
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating Country record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            try
            {
                var CountryToDelete = await countryRepository.GetCountry(id);

                if (CountryToDelete == null)
                {
                    return NotFound($"Country with Id = {id} not found");
                }

                await countryRepository .DeleteCountry(id);

                return Ok($"Country with Id = {id} deleted");
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting Country record");
            }
        }
    }
}
