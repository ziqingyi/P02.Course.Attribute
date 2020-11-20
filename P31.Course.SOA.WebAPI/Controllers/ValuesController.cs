using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace P31.Course.SOA.WebAPI.Controllers
{
    //[RoutePrefix("api/Values/")]//[Route("~/api/Values/{id:int}")]
    public class ValuesController : ApiController
    {

        //go to Get() by default, if no, will go to method with [HttpGet]
        //if has Get() and other methods with [HttpGet], then use parameters. 


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]//if not start with Get, must have this attribute. 
        [Route("api/Values/{i:int}/{j:int}/{k:int}")]
        public int LGetTotal(int i, int j, int k)
        {
            return i + j + k;
        }


        // GET api/values/5    //~override RoutePrefix
        [Route("~/api/Values/{id:int}")]
        public string Get(int id)
        {
            return "value in get with id: " +id;
        }

        [Route("api/Values/{name}")]
        public string Get(string name)
        {
            return "value in Get with name: " + name;
        }

        [Route("api/Values/{id:int}/Type/{typeid:int}")]
        public string Get(int id, int typeid)
        {
            return $"value id is {id}  typeid is {typeid} ";
        }

        [Route("api/Values/{id?}/v2")]
        public string GetV2ConfigRoute(int id=0) //set default, as  {id?} is empty.notice conflict 
        {
            return "value in GetV2ConfigRoute with id: " + id;
        }




        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }


    class Student
    {
        public int Id;

        public string Name;

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
