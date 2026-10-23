using Microsoft.AspNetCore.Components.Web;
using System.Net;

namespace TaskManagement.Api.Models
{
    public class ApiResponse
    {
        public HttpStatusCode Status {  get; set; }
        public bool IsSuccess = true;
        public List<string> Errors = [];
        public object ?Result { get; set; }
    }
}
