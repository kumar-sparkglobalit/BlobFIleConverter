using System;
using FileConverter.CloudProviders;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FileConverter.BlobReader
{
    public class BlobReader: IBlobReader
    {
        private string _containerName;
        private string _filename;
        private string _connectionString;

        public BlobReader(string pConnectionString, string pContainerName, string pFileName)
        {
            _containerName = pContainerName;
            _filename = pFileName;
            _connectionString = pConnectionString;
        }
        public string GetCloudFile()
        {
            // Setup the connection to the storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);

            // Connect to the blob storage
            CloudBlobClient serviceClient = storageAccount.CreateCloudBlobClient();
            // Connect to the blob container
            CloudBlobContainer container = serviceClient.GetContainerReference($"{_containerName}");
            // Connect to the blob file
            CloudBlockBlob blob = container.GetBlockBlobReference($"{_filename}");
            // Get the blob file as text
            string contents = blob.DownloadTextAsync().Result;

            return contents;
        }
    }
}


 

