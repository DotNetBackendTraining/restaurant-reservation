using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public IAsyncEnumerable<Reservation> GetAllReservationsByCustomerAsync(int customerId)
    {
        return _context.Reservations
            .Where(r => r.CustomerId == customerId)
            .AsAsyncEnumerable();
    }

    public async Task<ReservationDetail?> GetReservationDetailAsync(int reservationId)
    {
        return await _context.ReservationDetails.FindAsync(reservationId);
    }

    public IAsyncEnumerable<Customer> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        return _context.Customers
            .FromSqlInterpolated($"EXEC FindCustomersWithPartySizeGreaterThan @PartySize = {partySize}")
            .AsAsyncEnumerable();
    }
}