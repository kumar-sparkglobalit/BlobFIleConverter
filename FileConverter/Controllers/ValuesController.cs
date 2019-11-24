using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileConverter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using FileConverter.CloudProviders;
using Microsoft.Extensions.Logging;

namespace FileConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IBlobReader _blobReader;
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(IBlobReader pBlobReader, ILogger<ValuesController> pLogger)
        {
            _blobReader = pBlobReader;
            _logger = pLogger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
            //JsonConvert.DeserializeObject<ConverFileModel>(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<OutputBlobFile>> Get(int blobId)
        {
            _logger.LogInformation("starting reading the blob file");
            //string inputData = System.IO.File.ReadAllText("InputFile/inputJson.json"); //read from local file
            string inputData = _blobReader.GetCloudFile(); //read from clod file
            List<InputBlobFile> inputDeserialized = JsonConvert.DeserializeObject<List<InputBlobFile>>(inputData);
            _logger.LogInformation("completed the operation for blob updation at:" + System.DateTime.Now);
            return inputDeserialized.Select(Converter.Converter.blobConverstion).ToList();
            
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
