using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mis321tmtromblypa4.API.Models.Interfaces;
using mis321tmtromblypa4.Models;
using Repository.mis321tmtromblypa4.API.Databases;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/songs
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            ReadFromDatabase readObject = new ReadFromDatabase();
            return readObject.GetAll();
            //return new string[] { "value1", "value2" };
            //string[] myArray = {"book1", "book2"};
            //return myArray;
        }

        // GET: api/songs/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        //[HttpGet]
        public Song Get(int id)
        {
            ReadFromDatabase readObject = new ReadFromDatabase();
            return readObject.GetOne(id);
        }

        // POST: api/songs
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            ICreateSongs insertObject = new WriteToDatabase();
            insertObject.Create(value);
        }

        // PUT: api/songs/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Song song)
        {
            IUpdateSongs favoriteObj = new UpdateToDatabase();
            favoriteObj.Update(song);
        }

        // DELETE: api/songs/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete]
        public void Delete([FromBody]Song song)
        {
            IDeleteSongs newDelete = new DeleteFromDatabase();
            newDelete.Delete(song);
        }
    }
}
