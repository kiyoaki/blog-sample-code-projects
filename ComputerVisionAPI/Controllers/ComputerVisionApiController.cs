using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace ComputerVisionAPI.Controllers
{
    public class ComputerVisionApiController : ApiController
    {
        public async Task<AnalysisResult> Get(string url)
        {
            var client = new VisionServiceClient("xxxxxxxxx");
            var result = await client.AnalyzeImageAsync(url);
            return result;
        }
    }
}
