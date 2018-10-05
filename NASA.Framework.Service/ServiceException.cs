using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Framework.Service {
    public class ServiceException : Exception {

        public ServiceException(string exceptionMessage)
            : base(exceptionMessage) {
        }
    }
}
