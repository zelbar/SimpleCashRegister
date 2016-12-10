using SimpleCashRegister.Model;

namespace SimpleCashRegister.DAL.Persisters
{
    public class ReceiptPersister : XmlPersister<Receipt>
    {
        public ReceiptPersister(string filename) : base(filename)
        {
        }
    }
}
