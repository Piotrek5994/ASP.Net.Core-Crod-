using Microsoft.AspNetCore.Mvc;
using siwon.Models;


namespace siwon.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _db; // prywatna referencja do bazy danych co by za każdym razem nie pisać Program.Database.

        public BookController() =>   // przypisujemy statyczne pole Database do prywatnej referencji _db. 
            _db = Program.Database!; // Dodajemy ! żeby pokazać kompilatorowi że na tym etapie to nie może być już null

        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);

            if (book == null)
                return RedirectToAction("Index");

            _db.Books.Remove(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult BookForm()
        {
            return View("BookForm"); // wiem, że tego "BookForm" tutaj nie trzeba ale lepiej być bardziej precyzyjnym a) nie ufaj komputerom b) łatwiej się czyta
        }

        [HttpPost]
        public IActionResult BookForm(Book? newBook) // METODA DODANIA I UPDATU
        {
            if (newBook == null)
                return RedirectToAction("Index");

            var book = _db.Books.Find(newBook.Id); // pobierz z bazy danych książkę o Id edytowanego

            if (book == null) // jeżeli null to nie istnieje dodaj nową
            {
                _db.Books.Add(newBook);
            }
            else // jeżeli nie null zedytuj dane na nowe
            {
                book.Title = newBook.Title;
                book.Author = newBook.Author;
                book.CreateDate = newBook.CreateDate;

                _db.Books.Update(book); // zaktualizuj book w bazie danych
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        public IActionResult Edit(int id)
        {
            var book = _db.Books.Find(id);
            return View(book);
        }
    }
}





//public class BookController : Controller
//{
//    public static int counter = 4;

//    private static List<Book> books = new()
//    {
//        new() { Id = 1, Title = "W pustyni i w puszczy", Author = "Henryk Sienkiewicz", CreateDate = DateTime.Now },
//        new() { Id = 2, Title = "Pan Tadeusz", Author = "Adam Mickiewicz", CreateDate = DateTime.Now },
//        new() { Id = 3, Title = "Dziady", Author = "Adam Mickiewicz", CreateDate = DateTime.Now },
//        new() { Id = 4, Title = "Lalka", Author = "Bolesław Prus", CreateDate = DateTime.Now },
//    };

//    public IActionResult Index() => View("Index", books);

//    public IActionResult Delete([FromRoute] int id)
//    {
//        Book? b = books.FirstOrDefault(book => book.Id == id);
//        if (b is not null)
//            books.Remove(b);
//        return View("Index", books);
//    }

//    public IActionResult BookForm() => View("BookForm");

//    [HttpPost]
//    public IActionResult BookForm([FromForm] Book book)
//    {
//        if (!ModelState.IsValid) return View();

//        Book? b = books.FirstOrDefault(x => x.Id == book.Id);
//        if (b is null)
//        {
//            book.Id = ++counter;
//            books.Add(book);
//        }
//        else
//        {
//            b.Title = book.Title;
//            b.Author = book.Author;
//            b.CreateDate = book.CreateDate;
//        }

//        return View("Index", books);
//    }

//    public IActionResult Edit([FromRoute] int id)
//    {
//        Book? b = books.FirstOrDefault(x => x.Id == id);

//        return b is null ? View("Index", books) : View("BookForm", b);
//    }
//}
//}