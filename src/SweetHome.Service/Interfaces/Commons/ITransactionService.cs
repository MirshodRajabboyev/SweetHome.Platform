namespace SweetHome.Service.Interfaces.Commons;

public interface ITransactionService
{
    public Task<bool> TransactionBuy(long SellerId, long ClientId, double price);

}
