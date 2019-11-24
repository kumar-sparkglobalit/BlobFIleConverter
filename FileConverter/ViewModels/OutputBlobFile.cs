using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileConverter.ViewModels
{
    public class OutputBlobFile
    {
        public string State { get; set; }
        [JsonProperty("Zip-Code")]
        public string ZipCode { get; set; }
        [JsonProperty("STD-Terms-Code")]
        public string STDTermsCode { get; set; }
        public string VendorType { get; set; }
        public string BankCode { get; set; }
    }
}
