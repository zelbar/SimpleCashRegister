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
            var rv = _receiptRepository.GetAll();
            return rv;
        }

        public void AddNewReceipt(Receipt receipt)
        {
            try
            {
                receipt.DateTimeIssued = DateTime.Now;
                _receiptRepository.Add(receipt);
                Console.WriteLine("Ok");
            }
            catch(EntityAlreadyExistsException)
            {
                Console.Error.WriteLine("Receipt with specified id already exists.");
            }
        }

        public void EditReceipt(Receipt receipt)
        {
            try
            {
                _receiptRepository.Edit(receipt);
                Console.WriteLine("Ok");
            }
            catch (EntryPointNotFoundException)
            {
                Console.Error.WriteLine("Receipt not found.");
            }
        }

        public void DeleteArticle(Guid receiptId)
        {
            try
            {
                _receiptRepository.Delete(receiptId);
                Console.WriteLine("Ok");
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine("Receipt not found.");
            }
        }
    }
}
