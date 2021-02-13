using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base(success,message)
        {
            //alttakini çağıramadığmz için burda da adatayı set etdicz
            Data = data;

        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data; //ctor da datayı set ettik
        }
        public T Data { get; }
    }
}
