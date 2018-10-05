using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Framework.BusinessLogic {
    public class BusinessLogicException : Exception {

        public BusinessLogicException(string exceptionMessage) 
            :base(exceptionMessage){
        }
    }
}
