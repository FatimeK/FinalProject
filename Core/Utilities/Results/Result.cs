using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public Result(bool success, string message):this(success)
        {
            Message = message; //hani geter di set edilemzdi
            
           
        }
        public Result(bool success)
        {
           //ben mesaj versin istemyrm dedein ve böyle de yazdın = overloading(aşırı yükleme)
           //ama bunun yerine üattekinde succesi set etmeyek de o işi buna verek
            Success = success;

        }

        public bool Success { get; }

        public string Message { get; }
    }
}
