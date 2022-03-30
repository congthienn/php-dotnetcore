using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using BookStoreApi.RepositoryPattern;
namespace BookStoreApi.Services
{
    public class BillDetailService : IBillDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BillDetailService()
        {
            this._unitOfWork = GetUnitOfWork.UnitOfWork();
        }
        public async Task AddBill(BillDetail billDetail) => await this._unitOfWork.BillDetailRepository.Insert(billDetail);
    }
}