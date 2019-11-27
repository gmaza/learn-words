using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWords.Models
{
    public class Result
    {
        public Result(bool isSuccess, int code, string message)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
