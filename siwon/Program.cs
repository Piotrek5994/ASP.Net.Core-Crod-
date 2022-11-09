using siwon.Models;

namespace siwon
{
    public class Program
    {
        public static AppDbContext? Database { get; private set; } // statyczna instancja bazy danych

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var db = new AppDbContext(); // tworzymy now� instancj�
            db.Database.EnsureCreated(); // upewniamy si� �e baza danych istnieje
            Database = db; // przypisujemy lokaln� zmienn� do publicznej statycznej
            // mo�na by to zrobi� �adniej u�ywaj�c dependency injection ale nie wiem czy mieli�cie

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "book",
                pattern: "{controller=Book}/{action=Index}/{id?}");

            // wyszukanie strony
            app.Run();
        }
    }
}