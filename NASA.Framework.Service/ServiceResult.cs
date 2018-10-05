using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Framework.Service {

    public class ServiceResult {
        public ServiceResult() {
            ResultStatus = ServiceResultStatus.Success;
            ErrorMessage = "";
        }
        
        public ServiceResultStatus ResultStatus { get; set; }
        private string message = "";
        public string ErrorMessage
        {
            get
            {
                return $@"An error occurred, please contact your administrator. 
Error Message:{message}";
            }
            set
            {
                message = value;
            }
        }
    }

    public class ServiceResult<T> where T : class {
        public ServiceResult() {
            ResultStatus = ServiceResultStatus.Success;
            ErrorMessage = "";
            Response = null;
        }

        public T Response { get; set; }
        public ServiceResultStatus ResultStatus { get; set; }
        private string message = "";
        public string ErrorMessage
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}
