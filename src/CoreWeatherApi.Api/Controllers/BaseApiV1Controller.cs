using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeatherApi.Api.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseApiV1Controller : ControllerBase
    {

    }
}