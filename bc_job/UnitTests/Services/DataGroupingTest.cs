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
            List<List<Book>>? result = tmp.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 34);
            Assert.AreEqual(result[0].Count, 184);
            
            Assert.IsNotNull(result[0][0]);
            Assert.AreEqual(result[0][0].Id, 34);
            Assert.IsNull(result[0][0].AffiliateId);
            
            Assert.IsNotNull(result[0][0].BookMeta);
            Assert.IsFalse(result[0][0].BookMeta.Legal);
            
            Assert.IsNotNull(result[0][0].BookMeta.Logos);
            Assert.IsNull(result[0][0].BookMeta.Logos.Primary);
            
            Assert.IsNotNull(result[0][0].BookMeta.DeepLink);
            Assert.IsFalse(result[0][0].BookMeta.DeepLink.Multi);
            
            Assert.IsNotNull(result[0][0].BookMeta.States);
            Assert.AreEqual(result[0][0].BookMeta.States.Count, 0);
        }
    }
}