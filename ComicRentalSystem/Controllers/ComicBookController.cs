using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

public class ComicBooksController : Controller
{
    private readonly ComicSystemContext _context;

    public ComicBooksController(ComicSystemContext context)
    {
        _context = context;
    }

    // GET: ComicBooks
    public async Task<IActionResult> Index()
    {
        return View(await _context.ComicBooks.ToListAsync());
    }

    // GET: ComicBooks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ComicBooks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Author,PricePerDay")] ComicBook comicBook)
    {
        if (ModelState.IsValid)
        {
            _context.Add(comicBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    // GET: ComicBooks/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook == null) return NotFound();
        return View(comicBook);
    }

    // POST: ComicBooks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ComicBookId,Title,Author,PricePerDay")] ComicBook comicBook)
    {
        if (id != comicBook.ComicBookId) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(comicBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    // GET: ComicBooks/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook == null) return NotFound();
        return View(comicBook);
    }

    // POST: ComicBooks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var comicBook = await _context.ComicBooks.FindAsync(id);
        _context.ComicBooks.Remove(comicBook);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
