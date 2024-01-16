using System.Net.Http.Json;
using System.Reactive.Subjects;
using DependentVariablesExample.Models.IGNW;

namespace DependentVariablesExample.IGNW
{
    public class IGNWService: IIGNWService
    {
        private readonly HttpClient _http;

        public IGNWService(HttpClient http)
        {
            _http = http;
        }

        public BehaviorSubject<OrderDto?> SelectedOrder { get; set; } = new(default);
        private BehaviorSubject<CustomerDto?> selectedCustomer;
        public BehaviorSubject<CustomerDto?> SelectedCustomer
        {
            get
            {
                if (selectedCustomer == null)
                {
                    selectedCustomer = new(null);
                    selectedCustomer.Subscribe(async _ => SelectedOrder.OnNext(null));
                }
                return selectedCustomer;
            }
        }

        public async Task<List<CustomerDto>> GetCustomerDtoList()
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://data-northwind.indigo.design/Customers", UriKind.RelativeOrAbsolute));
            request.Headers.Add("Authorization", "Bearer <auth_value>");
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CustomerDto>>().ConfigureAwait(false);
            }

            return new List<CustomerDto>();
        }

        public async Task<List<OrderDto>> GetOrderDtoList(string id)
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://data-northwind.indigo.design/Customers/{id}/Orders", UriKind.RelativeOrAbsolute));
            request.Headers.Add("Authorization", "Bearer <auth_value>");
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<OrderDto>>().ConfigureAwait(false);
            }

            return new List<OrderDto>();
        }

        public async Task<List<OrderDetailDto>> GetOrderDetailDtoList(string id)
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://data-northwind.indigo.design/Orders/{id}/Details", UriKind.RelativeOrAbsolute));
            request.Headers.Add("Authorization", "Bearer <auth_value>");
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<OrderDetailDto>>().ConfigureAwait(false);
            }

            return new List<OrderDetailDto>();
        }
    }
}
