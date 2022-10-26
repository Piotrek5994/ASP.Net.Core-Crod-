using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace siwon.Models;

public class Book
{
    [HiddenInput]//Ukrywa wartości inne niż wyświetlone
    public int Id { get; set; }
    [Required]//Musi być powtarzany przez wszystkie konstruktory
    public string? Title { get; set; }
    [DataType(DataType.Date)] // tworzenie daty
    [Display(Name = "Data Wydania")]
    public DateTime CreateDate { get; set; }
    [MinLength(length: 5, ErrorMessage = "Autor musi zajmować conajmneij 5 znaków")] // ograniczenie minimalnej długości
    public string? Author { get; set; }
}
