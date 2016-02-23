using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;

namespace ComputerVisionAPI.Controllers
{
    public class GoogleVisionApiController : ApiController
    {
        public async Task<BatchAnnotateImagesResponse> Get(string gsObjectName)
        {
            var service = new VisionService(new BaseClientService.Initializer
            {
                ApiKey = "xxxxx",
                ApplicationName = "xxxxx"
            });

            var request = service.Images.Annotate(new BatchAnnotateImagesRequest
            {
                Requests = new[]
                {
                    new AnnotateImageRequest
                    {
                        Image = new Image
                        {
                            Source = new ImageSource()
                            {
                                GcsImageUri = "gs://xxxxx/" + gsObjectName
                            }
                        },
                        Features = new[]
                        {
                            "LABEL_DETECTION",
                            "TEXT_DETECTION",
                            "FACE_DETECTION",
                            "LANDMARK_DETECTION",
                            "LOGO_DETECTION",
                            "SAFE_SEARCH_DETECTION",
                            "IMAGE_PROPERTIES"
                        }.Select(x=> new Feature { Type = x }).ToArray()
                    }
                }
            });

            var response = await request.ExecuteAsync();
            return response;
        }
    }
}
