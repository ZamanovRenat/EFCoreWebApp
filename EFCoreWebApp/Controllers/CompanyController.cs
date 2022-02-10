using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreWebApp.Core.Domain;
using EFCoreWebApp.DaraAccess;
using Microsoft.Extensions.Logging;

namespace EFCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(DataContext dataContext, ILogger<CompanyController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
            
        }
    }
}
