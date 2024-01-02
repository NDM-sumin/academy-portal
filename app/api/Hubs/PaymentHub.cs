using Microsoft.AspNetCore.SignalR;
using repository.contract.IAppRepositories;

namespace api.Hubs
{
    public class PaymentHub : Hub
    {
        readonly IPaymentTransactionRepository paymentTransactionRepository;
        public PaymentHub(IPaymentTransactionRepository paymentTransactionRepository)
        {
            this.paymentTransactionRepository = paymentTransactionRepository;
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task ConfirmPaid(string connectionId, string message)
        {
            await this.Clients.Client(connectionId).SendAsync("ReceivePaidStatus", message);
        }
        public async Task RegisterPayment(string connectionId, string txnRef)
        {
            var paymentTransaction = await this.paymentTransactionRepository.FindByTxnRef(txnRef);
            paymentTransaction.ConnectionId = connectionId;
            await this.paymentTransactionRepository.Update(paymentTransaction);
            await this.paymentTransactionRepository.SaveChange();
        }
    }
}
