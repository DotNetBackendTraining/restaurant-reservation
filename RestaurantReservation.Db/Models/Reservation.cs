namespace RestaurantReservation.Db.Models;

public class Reservation
{
    public int ReservationId { get; set; }

    public required int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public required DateTime ReservationDate { get; set; }

    public required int PartySize { get; set; }
}