using bc_job;
using bc_job.Models;
using bc_job.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class DataStoringTest
    {
        private List<List<Book>> _data = System.Text.Json.JsonSerializer.Deserialize<List<List<Book>>>(File.ReadAllText(Parameters.RootUrl + "//JSON_Files//storing.json")); 
        
        [TestMethod]
        public void StoreToFile_Test()
        {
            Task<bool> file = new DataStoring().StoreToFile(_data);
            file.Wait();
            
            // double validate if file has been created & remove it - just clear "junk"
            string path = Parameters.RootUrl + "//result.txt";
            if (File.Exists(path)) { File.Delete(path); }
        }
    }
}