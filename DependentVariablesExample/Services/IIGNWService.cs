using System.Reactive.Subjects;
using DependentVariablesExample.Models.IGNW;

namespace DependentVariablesExample.IGNW
{
    public interface IIGNWService
    {
        public BehaviorSubject<OrderDto?> SelectedOrder { get; set; }
        public BehaviorSubject<CustomerDto?> SelectedCustomer { get; }

        Task<List<CustomerDto>> GetCustomerDtoList();
        Task<List<OrderDto>> GetOrderDtoList(string id);
        Task<List<OrderDetailDto>> GetOrderDetailDtoList(string id);
    }
}
