using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class AlreadyExistException : BaseException
    {
        public AlreadyExistException(Type entityType) : base(entityType) { }

        public override string Message => base.Message + $"Already exists the same '{EntityType.Name}' entity";
    }
}