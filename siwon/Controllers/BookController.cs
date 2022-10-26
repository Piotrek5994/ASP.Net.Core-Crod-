using Microsoft.AspNetCore.Mvc;
using siwon.Models;

namespace siwon.Controllers
{
    public class BookController : Controller
    {
        public static int counter = 4;

        private static List<Book> books = new List<Book>()
        {
            new Book() {Id=1, Title="W pustyni i w puszczy", Author="Henryk Sienkiewicz", CreateDate=DateTime.Now},
            new Book() {Id=2, Title="Pan Tadeusz", Author="Adam Mickiewicz", CreateDate=DateTime.Now},
            new Book() {Id=3, Title="Dziady", Author="Adam Mickiewicz", CreateDate=DateTime.Now},
            new Book() {Id=4, Title="Lalka", Author="Bolesław Prus", CreateDate=DateTime.Now},
        };

        public IActionResult Index() => View("Index", books);

        public IActionResult Delete([FromRoute] int id)
        {
            Book? b = books.FirstOrDefault(book => book.Id == id);
            if (b is not null)
                books.Remove(b);
            return View("Index", books);
        }

        public IActionResult BookForm() => View("BookForm");

        [HttpPost]
        public IActionResult BookForm([FromForm] Book book)
        {
            if (!ModelState.IsValid) return View();

            Book? b = books.FirstOrDefault(x => x.Id == book.Id);
            if (b is null)
            {
                book.Id = ++counter;
                books.Add(book);
            }
            else
            {
                b.Title = book.Title;
                b.Author = book.Author;
                b.CreateDate = book.CreateDate;
            }
            return View("Index", books);
        }

        public IActionResult Edit([FromRoute] int id)
        {
            Book? b = books.FirstOrDefault(x => x.Id == id);

            if (b is null)
                return View("Index", books);

            return View("BookForm", b);
        }
    }
}
