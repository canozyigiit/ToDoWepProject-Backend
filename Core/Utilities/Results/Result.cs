﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class Result:IResult
    {
        public bool Success { get; }
        public string Message { get; }

      
        public Result(bool success,string message):this(success)//diğer ctor da çalışır 
        {
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success = success;
        }


    }
}
