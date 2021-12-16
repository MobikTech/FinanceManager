using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class BaseException : Exception
    {
        private readonly Type _entityType;
        protected readonly string EntityName;
        protected BaseException(Type entityType)
        {
            _entityType = entityType;
            EntityName = entityType.Name;
        }

        private const string DefaultMessage = "An exception was thrown while running app. ";
        public override string Message => DefaultMessage;
    }
}