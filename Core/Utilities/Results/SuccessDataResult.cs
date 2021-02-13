using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message) 
        {

        }
        //MESAJSIZ VERSİONU

        public SuccessDataResult(T data) : base(data, true)
        {
            //ister sadece data ver
        }

        public SuccessDataResult(string message): base(default, true, message)
        {
            //ister sadece mesaj ver
        }
        public SuccessDataResult() : base(default, true)
        {
            //ister hiçbir şey döndürme
        }
    }
}
