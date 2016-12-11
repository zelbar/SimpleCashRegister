using SimpleCashRegister.Model;

namespace SimpleCashRegister.DataAccessLayer.Persisters
{
    public class ReceiptPersister : XmlPersister<Receipt>
    {
        public ReceiptPersister(string filename) : base(filename)
        {
        }
    }
}
