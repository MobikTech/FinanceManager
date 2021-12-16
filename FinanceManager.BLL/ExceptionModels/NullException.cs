using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class NullException : BaseException
    {
        private readonly string _nullField;
        public NullException(Type entityName, string nullField) : base(entityName)
        {
            _nullField = nullField;
        }
        public override string Message => $"{_nullField} in '{EntityName}' cannot be a null";
    }
}