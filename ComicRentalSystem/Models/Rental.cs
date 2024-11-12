public class Rental {
    public int RentalId {get;set;}
    public int CustomerId {get;set;}
    public DateTime RentalTime {get;set;}
    public DateTime ReturnDate {get;set;}
    public Customer Customer {get;set;}
}