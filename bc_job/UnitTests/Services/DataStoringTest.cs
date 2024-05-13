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
            Task<bool> tmp = new DataStoring().StoreToFile(_data);
            tmp.Wait();
            bool result = tmp.Result;
            
            // double validate if file has been created & remove it - just clear "junk"
            if (File.Exists(Parameters.RootUrl + "//result.txt")) {
                File.Delete(Parameters.RootUrl + "//result.txt");
            }
        }
    }
}