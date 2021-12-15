using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class NullException : BaseException
    {
        private readonly string _nullField;
        public NullException(Type entityType, string nullField) : base(entityType)
        {
            _nullField = nullField;
        }
        public override string Message => $"{_nullField} in '{EntityType.Name}' cannot be a null";
    }
}