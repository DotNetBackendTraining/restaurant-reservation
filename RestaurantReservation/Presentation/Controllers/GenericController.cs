using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Presentation.Controllers;

public class GenericController : IGenericController
{
    private readonly IEmployeeService _employeeService;
    private readonly IReservationService _reservationService;
    private readonly IOrderService _orderService;

    public GenericController(
        IEmployeeService employeeService,
        IReservationService reservationService,
        IOrderService orderService)
    {
        _employeeService = employeeService;
        _reservationService = reservationService;
        _orderService = orderService;
    }

    public IAsyncEnumerable<Employee> ListManagers()
    {
        return _employeeService.GetAllManagersAsync();
    }

    public IAsyncEnumerable<Reservation> GetReservationsByCustomer(int customerId)
    {
        return _reservationService.GetReservationsByCustomerAsync(customerId);
    }

    public IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItems(int reservationId)
    {
        return _orderService.ListOrdersAndMenuItemsAsync(reservationId);
    }

    public IAsyncEnumerable<MenuItem> ListOrderedMenuItems(int reservationId)
    {
        return _orderService.ListOrderedMenuItemsAsync(reservationId);
    }

    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        return await _employeeService.CalculateAverageOrderAmountAsync(employeeId);
    }
}