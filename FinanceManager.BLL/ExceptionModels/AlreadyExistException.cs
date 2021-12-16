using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class AlreadyExistException : BaseException
    {
        public AlreadyExistException(Type entityName) : base(entityName) { }

        public override string Message => base.Message + $"Already exists the same '{EntityName}'";
    }
}