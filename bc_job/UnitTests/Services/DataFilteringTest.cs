using bc_job;
using bc_job.Models;
using bc_job.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class DataFilteringTest
    {
        ApiResponse? _data = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(File.ReadAllText(Parameters.RootUrl + "//JSON_Files//feed.json"));
        
        [TestMethod]
        public void FilterBooksWithWhere_Test()
        {
            // check if there is data contained in collection (this is an input to the method)
            Assert.IsNotNull(_data.Books);

            var tmp = new DataFiltering().FilterBooksWithWhere(_data.Books);
            tmp.Wait();
            List<Book>? result = tmp.Result;
            Assert.IsNotNull(result);
            
            Assert.AreEqual(result.Count, 26);
            
            Assert.AreEqual(result[0].Name, "BetMGM NJ");
            Assert.AreEqual(result[0].Id, 75);
            
            Assert.IsNotNull(result[0].BookMeta);
            Assert.IsTrue(result[0].BookMeta.Legal);
            Assert.IsFalse(result[0].BookMeta.Promoted);
            
            Assert.IsNotNull(result[0].BookMeta.States);
            Assert.AreEqual(result[0].BookMeta.States.Count, 1);
            
            Assert.IsNotNull(result[0].BookMeta.Logos);
            Assert.AreEqual(result[0].BookMeta.Logos.Promo, "https://assets.actionnetwork.com/744974_MGMActionBS2.jpeg");
            
            Assert.IsNotNull(result[0].BookMeta.DeepLink);
            Assert.IsTrue(result[0].BookMeta.DeepLink.Multi);
        }
        
        [TestMethod]
        public void FilterBooksWithLoop_Test()
        {
            // check if there is data contained in collection (this is an input to the method)
            Assert.IsNotNull(_data.Books);

            var tmp = new DataFiltering().FilterBooksWithLoop(_data.Books);
            tmp.Wait();
            List<Book>? result = tmp.Result;
            Assert.IsNotNull(result);
            
            Assert.AreEqual(result.Count, 26);
            
            Assert.AreEqual(result[0].ParentName, "BetMGM");
            Assert.AreEqual(result[0].AffiliateId, 1);
            
            Assert.IsNotNull(result[0].BookMeta);
            Assert.IsTrue(result[0].BookMeta.FastBetEnabledApp);
            Assert.IsFalse(result[0].BookMeta.Preferred);
            
            Assert.IsNotNull(result[0].BookMeta.States);
            Assert.AreEqual(result[0].BookMeta.States[0], "NJ");
            
            Assert.IsNotNull(result[0].BookMeta.Logos);
            Assert.AreEqual(result[0].BookMeta.Logos.Primary, "https://assets.actionnetwork.com/779359_BetMGM800x200@1x.png");
            
            Assert.IsNotNull(result[0].BookMeta.DeepLink);
            Assert.IsTrue(result[0].BookMeta.DeepLink.Supported);
        }
    }
}