namespace Livraria.Class;

public class Livro
{
    public int Id { get; set; }
    public String Titulo { get; set; } = String.Empty;
    public String  Autor { get; set; } = String.Empty;
    public String Genero { get; set; } = String.Empty;
    public double Price { get; set; }
    public int QtdEstq { get; set;}
}
