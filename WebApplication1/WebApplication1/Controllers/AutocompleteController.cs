using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/autocomplete")]
    public class AutocompleteController : Controller
    {
        // GET: api/Autocomplete
        [HttpGet]
        public IEnumerable<string> Get([FromQuery]string term)
        {
            var autocompleter = new RedisAutocomplete.RedisAutoComplete<string>("104.198.139.9:6379");
            var result = autocompleter.GetValues(term,10);
            return result;
        }
    }
}
