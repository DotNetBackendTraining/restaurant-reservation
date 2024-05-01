using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Interfaces.Services;

namespace RestaurantReservation.Domain.Services;

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
}