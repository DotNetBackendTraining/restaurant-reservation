namespace RestaurantReservation.DTOs;

public record CustomerDto(
    int CustomerId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber)
{
}