using System;

namespace FinanceManager.BLL.ExceptionModels
{
    public class CreationException : BaseException
    {

        public CreationException(Type entityName) : base(entityName) { }

        public override string Message => base.Message + $"Couldn't create '{EntityName}'";
    }
}