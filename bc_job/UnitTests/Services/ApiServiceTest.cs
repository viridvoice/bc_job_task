using bc_job;
using bc_job.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class ApiServiceTest
    {
        [TestMethod]
        public void GetRequest_Test() {
            
            // use method to get actual value
            var task = new ApiService().GetRequest(Parameters.FeedUrl);
            task.Wait();
            string result = task.Result;
            Assert.AreNotEqual(result, "");
        }
    }
}