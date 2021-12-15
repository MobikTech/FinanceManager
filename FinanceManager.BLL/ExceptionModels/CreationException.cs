using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class CreationException : BaseException
    {

        public CreationException(Type entityType) : base(entityType) { }

        public override string Message => base.Message + $"Couldn't create entity '{EntityType}'";
    }
}