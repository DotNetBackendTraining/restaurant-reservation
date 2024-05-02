using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IQueryRepository<Employee> _queryRepository;

    public EmployeeService(IQueryRepository<Employee> queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public IAsyncEnumerable<Employee> GetAllManagersAsync()
    {
        return _queryRepository.GetAll()
            .Where(e => e.Position == "Manager")
            .AsAsyncEnumerable();
    }

    public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await _queryRepository.GetAll()
            .Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.Orders)
            .AverageAsync(o => o.TotalAmount);
    }
}