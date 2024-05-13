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
            List<Book> result = tmp.Result;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void FilterBooksWithLoop_Test()
        {
            // check if there is data contained in collection (this is an input to the method)
            Assert.IsNotNull(_data.Books);

            var tmp = new DataFiltering().FilterBooksWithLoop(_data.Books);
            tmp.Wait();
            List<Book> result = tmp.Result;
            Assert.IsNotNull(result);
        }
    }
}