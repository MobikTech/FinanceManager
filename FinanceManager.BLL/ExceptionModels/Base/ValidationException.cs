using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}