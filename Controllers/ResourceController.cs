using BookingApi.Data;
using BookingApi.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using BookingApi.Interfaces;

namespace BookingApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ResourceController : ControllerBase
{

    private readonly BookingContext _bookingContext;
    private readonly IResourceService _resourceService;

    public ResourceController(BookingContext bookingContext,IResourceService resourceService)
    {
        _bookingContext= bookingContext;
        _resourceService=resourceService;
    }

      // GET: api/Resources
        [HttpGet]
        public async Task<IEnumerable<Resource>> GetResources()
        {
            return await  _resourceService.GetAllResources();
           
        }
}
