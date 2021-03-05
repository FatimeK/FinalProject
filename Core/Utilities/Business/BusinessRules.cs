using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {

        //parametre ile yolladığım iş kurallarından başarısız olanı seçer ve iş kuralını döndürür
        //logic kurallarım oluyo
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; 
                }
                
            }
            return null;

        }
    }
}
