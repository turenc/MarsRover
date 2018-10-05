using System;
using NASA.Framework.Logger;

namespace NASA.Framework.Service {
    public abstract class ServiceBase {
        protected ILogger logger = new ConsoleLog();
    }
}
