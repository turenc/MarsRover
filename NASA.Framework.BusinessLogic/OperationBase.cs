using System;
using NASA.Framework.Logger;

namespace NASA.Framework.BusinessLogic {
    
    public abstract class OperationBase {
        protected ILogger logger = new ConsoleLog();
        
    }
}
