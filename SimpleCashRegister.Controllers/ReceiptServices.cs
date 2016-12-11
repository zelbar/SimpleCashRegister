using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer;
using SimpleCashRegister.DataAccessLayer.Repositories;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.Services
{
    public class ReceiptServices
    {
        public ReceiptServices(ArticleRepository articleRepository, ReceiptRepository receiptRepository)
        {
            _articleRepository = articleRepository;
            _receiptRepository = receiptRepository;
        }

        private readonly ArticleRepository _articleRepository;
        private readonly ReceiptRepository _receiptRepository;

        public List<Receipt> GetAllReceipts()
        {
            return _receiptRepository.GetAll();
        }

        public Receipt GetById(Guid id)
        {
            return _receiptRepository.GetById(id);
        }

        public void IssueReceipt(Receipt receipt)
        {
            receipt.DateTimeIssued = DateTime.Now;
            if (receipt.Items.Count == 0)
            {
                throw new EnptyReceiptIssuingException();
            }
            _receiptRepository.Add(receipt);
        }

        public void EditReceipt(Receipt receipt)
        {
            _receiptRepository.Edit(receipt);
        }

        public void DeleteReceipt(Guid receiptId)
        {
            _receiptRepository.Delete(receiptId);
        }
    }
}
