using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Models;

namespace NetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel{Id=1,FirstName="Sabri",LastName="İRGE"}
            };
        }
    }
}