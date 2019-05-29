using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Con1
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeController : ControllerBase
    {
        #region Methods

        [HttpGet("Some")]
        public string GetSome()
        {
            return JsonConvert.SerializeObject(new { Tag = "SomeTag" });
        }

        #endregion
    }
}
