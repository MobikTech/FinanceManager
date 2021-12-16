using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(Type entityName) : base(entityName) { }

        public override string Message => base.Message + $"Cannot found that '{EntityName}'";
    }
}