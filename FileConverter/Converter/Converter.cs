using FileConverter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileConverter.Converter
{
    public static class Converter
    {
        public static Func<InputBlobFile, OutputBlobFile> blobConverstion = (inputFile) =>
         {
             var outPutFile = new OutputBlobFile();
             outPutFile.BankCode = inputFile.BankCode;
             outPutFile.State = inputFile.PostalCode.Trim() == "1" ? "USA" : "CAN";
             outPutFile.STDTermsCode = inputFile.ReferenceID + "after Conversion";
             outPutFile.VendorType = inputFile.SupplierStatus + "after conversion";
             outPutFile.ZipCode = inputFile.PostalCode + " 9001";
             return outPutFile;
         };
    }
}
