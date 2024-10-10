using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ProductOfferingSuiteAPI.APIUtility.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public abstract class ApiBaseController<T> : ControllerBase where T : ApiBaseController<T>
    {
        private ILogger<T> _logger;
        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}
