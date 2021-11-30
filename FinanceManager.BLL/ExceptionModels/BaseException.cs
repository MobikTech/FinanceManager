using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class BaseException : Exception
    {
        private const string DefaultMessage = "An exception was thrown while running app.";
        protected BaseException(string message) : base(message)
        {
            
        }
        public BaseException() : base(DefaultMessage)
        {
            
        }
    }
}