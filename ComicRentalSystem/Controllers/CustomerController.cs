public class CustomersController : Controller
{
    private readonly ComicSystemContext _context;

    public CustomersController(ComicSystemContext context)
    {
        _context = context;
    }

    // GET: Customers/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: Customers/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([Bind("FullName,PhoneNumber,RegisterDate")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            customer.RegisterDate = DateTime.Now;
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(customer);
    }
}
