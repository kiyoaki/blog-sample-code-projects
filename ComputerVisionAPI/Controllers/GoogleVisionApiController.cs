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
                            new Feature
                            {
                                Type = "LABEL_DETECTION"
                            },
                            new Feature
                            {
                                Type = "TEXT_DETECTION"
                            },
                            new Feature
                            {
                                Type = "FACE_DETECTION"
                            },
                            new Feature
                            {
                                Type = "LANDMARK_DETECTION"
                            },
                            new Feature
                            {
                                Type = "LOGO_DETECTION"
                            },
                            new Feature
                            {
                                Type = "SAFE_SEARCH_DETECTION"
                            },
                            new Feature
                            {
                                Type = "IMAGE_PROPERTIES"
                            },
                        }
                    }
                }
            });

            var response = await request.ExecuteAsync();
            return response;
        }
    }
}
