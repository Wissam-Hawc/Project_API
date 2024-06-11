using System.Net;

namespace Trendit_ProjectAPI.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
