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
        //En metod som tar emot ett json-objekt från javascript functionen ExportProfile.
        //profile parametern ger värden till xmlProfile och fileName variablarna som används när metoden ExportProfile kallas.
        public void ConvertJson([FromBody] XmlJson profile)
        {
            XmlProfile xmlProfile = profile.Profile;
            string fileName = profile.FileName;
            //await
            ExportProfile(xmlProfile, fileName);
        }

        
        //Sparar ner profilen till en XML-fil. Filen ligger i Dating4U mappen.
        public void ExportProfile(XmlProfile profile, string fileName)
        {
            SerializeXML serializer = new SerializeXML();
            serializer.ExportProfileToXml(profile, fileName);
        }
    }
}
