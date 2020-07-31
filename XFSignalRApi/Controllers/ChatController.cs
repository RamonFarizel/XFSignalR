using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XFSignalRApi.Models;
using XFSignalRApi.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XFSignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        IRepository<Message> _repository { get;}

        public ChatController(IRepository<Message> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult PostMessage([FromBody] Message message)
        {
            if (message is null)
                return BadRequest();

            try
            {
                var result = _repository.Create(message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            
            
            return Ok();
        }
    }
}
