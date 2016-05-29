using System.Collections.Generic;

namespace MediaContentService.DTO
{
    public class ResponseDTO
    {
        public List<Response> response { get; set; }
        public string status { get; set; }
        public string error { get; set; }
        
        public class Response
        {
            public string image { get; set; }
            public string slug { get; set; }
            public string title { get; set; }
        }
    }
}
