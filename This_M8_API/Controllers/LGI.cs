using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace This_M8_API.Controllers
{
    [Route("this/rxxh/[controller]")]
    [ApiController]
    public class LGI : ControllerBase
    {
        // GET: api/<LGI>
        /// <summary>
        /// 定位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            Dictionary<string, object> s = new Dictionary<string, object>()
            {
                {  "ak"," " },{ " coor" , "bd09ll" }
            };
            string ss=   Https.Get("http://api.map.baidu.com/location/ip?",s);
            JObject jo = (JObject)JsonConvert.DeserializeObject(ss);
            if (jo["status"].ToString()=="0")
            {
                return Get(jo["content"]["address_detail"]["city"].ToString());
            }
            return Get("北京市");
        }
        string getId(string st)
        {
            return Server_Add.hiso[st].ToString();
        }
        // GET api/<LGI>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            id= getId(id);
            string respons=   Https.Get("http://api.map.baidu.com/weather/v1/?district_id="+ id + "&data_type=all&ak= ");
            JObject jo = (JObject)JsonConvert.DeserializeObject(respons);
            if (jo["status"].ToString()=="0")
            {
                return jo.ToString();
            }
            return Get();          
        }
        // POST api/<LGI>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        // PUT api/<LGI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        // DELETE api/<LGI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
