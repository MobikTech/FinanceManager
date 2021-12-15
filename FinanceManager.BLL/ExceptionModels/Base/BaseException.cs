using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class BaseException : Exception
    {
        protected readonly Type EntityType;
        protected BaseException(Type entityType) => EntityType = entityType;
        
        private const string DefaultMessage = "An exception was thrown while running app. ";
        public override string Message => DefaultMessage;
    }
}