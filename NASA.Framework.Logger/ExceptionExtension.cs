using System;
using System.Collections.Generic;
using System.Text;

namespace System {

    static class Extensions {
        public static string GetaAllMessages(this Exception exp) {
            string message = string.Empty;
            Exception innerException = exp;

            do {
                message += (string.IsNullOrEmpty($" Message:{ innerException.Message} StackTrace:{innerException.StackTrace}") ? string.Empty : innerException.Message);
                innerException = innerException.InnerException;
            }
            while (innerException != null);

            return message;
        }
    };

}
