using System.Net;

namespace RomanCalculator.UI.Model
{
    public class HttpResponse
    {
		public HttpStatusCode StatusCode { get; set; }
	}

    public class HttpResponse<T> : HttpResponse where T: class,new()
    {
        public  T? Response { get; set; }
    }


}
