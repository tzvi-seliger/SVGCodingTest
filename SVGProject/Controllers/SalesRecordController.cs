using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SVGProject.Models;

namespace SVGProject.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRecordController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<SalesRecord>> Get()
        {
            List<SalesRecord> salesrecords = new List<SalesRecord>();
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B54NHFS; Initial Catalog=VehicleShop; Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Select * from VehicleSales", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    salesrecords.Add(new SalesRecord
                    {
                        SalesRecordId = Convert.ToInt32(r["SaleId"]),
                        VehicleType = Convert.ToString(r["VehicleName"]),
                        SaleDate = Convert.ToDateTime(r["SaleDate"])
                    });
                }
            }
            return salesrecords;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
