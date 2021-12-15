using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.PL.WebApi.Models;

namespace FinanceManager.PL.WebApi.Mappers
{
    public class TransactionViewMapper : IMap<TransactionDTO, TransactionViewModel>, IMapBack<TransactionViewModel, TransactionDTO>
    {
        public TransactionViewModel Map(TransactionDTO dto)
        {
            return new TransactionViewModel()
            {
                Id = dto.Id,
                Sum = dto.Sum,
                CategoryId = dto.CategoryId,
                SourceId = dto.SourceId,
                TargetId = dto.TargetId,
            };
        }
    
        public TransactionDTO MapBack(TransactionViewModel model)
        {
            return new TransactionDTO()
            {
                // Id = model.Id,
                Sum = model.Sum,
                SourceId = model.SourceId,
                TargetId = model.TargetId,
                CategoryId = model.CategoryId
            };
        }
    }
}