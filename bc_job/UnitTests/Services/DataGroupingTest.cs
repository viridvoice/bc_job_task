using bc_job;
using bc_job.Models;
using bc_job.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class DataGroupingTest
    {
        ApiResponse? _data = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(File.ReadAllText(Parameters.RootUrl + "//JSON_Files//feed.json"));
        
        [TestMethod]
        public void GroupData_Test()
        {
            // check if there is data contained in collection (this is an input to the method)
            Assert.IsNotNull(_data.Books);

            var tmp = new DataGrouping().GroupData(_data.Books);
            tmp.Wait();
            List<List<Book>> result = tmp.Result;

            Assert.IsNotNull(result);
        }
    }
}