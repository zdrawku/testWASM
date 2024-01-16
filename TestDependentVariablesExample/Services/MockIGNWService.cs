using System.Reactive.Subjects;
using DependentVariablesExample.Models.IGNW;

namespace DependentVariablesExample.IGNW
{
    public class MockIGNWService : IIGNWService
    {
        public BehaviorSubject<OrderDto?> SelectedOrder { get; set; } = new(default);
        public BehaviorSubject<CustomerDto?> SelectedCustomer { get; } = new(null);

        public Task<List<CustomerDto>> GetCustomerDtoList()
        {
            return Task.FromResult<List<CustomerDto>>(new());
        }

        public Task<List<OrderDto>> GetOrderDtoList(string id)
        {
            return Task.FromResult<List<OrderDto>>(new());
        }

        public Task<List<OrderDetailDto>> GetOrderDetailDtoList(string id)
        {
            return Task.FromResult<List<OrderDetailDto>>(new());
        }
    }
}
