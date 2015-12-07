using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccerBackoffice.Helpers
{
    class UploadImageHelper
    {
        #region Fields

        private CloudStorageAccount _storageAccount;
        private CloudBlobContainer _blobContainer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initialize blob connector
        /// </summary>
        public UploadImageHelper()
        {
            var StorageAccountName = ConfigurationManager.AppSettings["storageAccountName"];
            var StorageAccountKey = ConfigurationManager.AppSettings["storageAccessKey"];

            var connectionString = string.Format(@"DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            _storageAccount = storageAccount;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// อัพโหลดรูปภาพ
        /// </summary>
        /// <param name="fileName">ชื่อไฟล์ที่จะทำการอัพโหลด</param>
        /// <param name="fileStream">ข้อมูลไฟล์ที่จะทำการอัพโหลด</param>
        /// <param name="fileType">ประเภทข้อมูลที่ทำการอัพโหลด</param>
        /// <returns>Uploaded part URL</returns>
        public async Task<string> UploadImage(string fileName, System.IO.Stream fileStream, string fileType)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("filename", "Upload file name can't be empty");
            else if (fileStream == null) throw new ArgumentNullException("fileSteam", "Stream can't be null");

            var blobClient = _storageAccount.CreateCloudBlobClient();
            _blobContainer = blobClient.GetContainerReference(fileType);
            _blobContainer.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            var blob = _blobContainer.GetBlockBlobReference(fileName);
            blob.Properties.ContentType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
            await blob.UploadFromStreamAsync(fileStream);

            return blob.Uri.AbsoluteUri;
        }

        #endregion Methods
    }
}
