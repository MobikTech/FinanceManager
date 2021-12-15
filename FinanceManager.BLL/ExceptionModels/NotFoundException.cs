using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(Type entityType) : base(entityType) { }

        public override string Message => base.Message + $"Cannot found an entity '{EntityType.Name}'";
    }
}