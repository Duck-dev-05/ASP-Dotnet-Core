public class RentalsController : Controller
{
    private readonly ComicSystemContext _context;

    public RentalsController(ComicSystemContext context)
    {
        _context = context;
    }

    // GET: Rentals/Create
    public IActionResult Create(int customerId)
    {
        ViewBag.CustomerId = customerId;
        return View();
    }

    // POST: Rentals/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int customerId, DateTime rentalDate, DateTime returnDate, List<RentalDetail> rentalDetails)
    {
        var rental = new Rental
        {
            CustomerId = customerId,
            RentalDate = rentalDate,
            ReturnDate = returnDate,
        };

        _context.Add(rental);
        await _context.SaveChangesAsync();

        foreach (var detail in rentalDetails)
        {
            detail.RentalId = rental.RentalId;
            _context.Add(detail);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }
}
