using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModuleService.Models
{
    public enum ResponseCode
    {
        OK = 1,
        Error = 2
    }

    public class ResponseModel
    {
        public ResponseModel(ResponseCode responseCode, string responeMessage, object dataset)
        {
            ResponseCode = responseCode;
            ResponseMessage = responeMessage;
            DataSet = dataset;
        }
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object DataSet { get; set; }
    }
}
