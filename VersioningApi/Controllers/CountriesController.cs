﻿using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersioningApi.Models.DTOs;

namespace VersioningApi.Controllers
{
    [Route("api/v/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountriesController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetV1() 
        {
            var countriesDomainModel = CountriesData.Get();
            // map domain to dto
            var response = new List<CountryDTOV1>();
            foreach (var countryDomain in countriesDomainModel) 
            {
                response.Add(new CountryDTOV1
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name,
                });
            }
            return Ok(response);

        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetV2()
        {
            var countriesDomainModel = CountriesData.Get();
            // map domain to dto
            var response = new List<CountryDTOV2>();
            foreach (var countryDomain in countriesDomainModel)
            {
                response.Add(new CountryDTOV2
                {
                    Id = countryDomain.Id,
                    CountryName = countryDomain.Name,
                });
            }
            return Ok(response);

        }

    }
}
