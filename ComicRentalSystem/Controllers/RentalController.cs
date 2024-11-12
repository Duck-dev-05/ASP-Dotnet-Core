public async Task<IActionResult> Report(DateTime startDate, DateTime endDate)
{
    var rentals = await _context.Rentals
        .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
        .Include(r => r.Customer)
        .Include(r => r.RentalDetails)
        .ThenInclude(d => d.ComicBook)
        .ToListAsync();

    return View(rentals);
}
