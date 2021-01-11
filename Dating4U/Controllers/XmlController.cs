using Dating4U.Data;
using Dating4U.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        [Route("ExportProfile")]
        [HttpPost]
        //En metod som tar emot ett json-objekt
        public void ConvertJson([FromBody] XmlJson profile)
        {
            XmlProfile xmlProfile = profile.Profile;
            string fileName = profile.FileName;
            //await
            ExportProfile(xmlProfile, fileName);
        }

        // POST api/<XmlController>
        //[HttpPost]
        public void ExportProfile(XmlProfile profile, string fileName)
        {
            SerializeXML serializer = new SerializeXML();
            serializer.ExportProfileToXml(profile, fileName);
        }
    }
}
