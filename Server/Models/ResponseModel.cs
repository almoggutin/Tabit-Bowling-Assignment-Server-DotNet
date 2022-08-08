using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Server.Models
{
    interface IResponseModel
    {
        int StatusCode { get; set; }
        string StatusMessage { get; set; }
        object? Data { get; set; }
        string Message { get; set; }
    }

    public class ResponseModel: IResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object? Data { get; set; }
        public string Message { get; set; } = "";

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
