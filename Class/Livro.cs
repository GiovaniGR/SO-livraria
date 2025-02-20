namespace Livraria.Class;

public class Livro
{
    private static int contadorID = 1;

    public int Id { get; set; }
    public String Titulo { get; set; }
    public String  Autor { get; set; }
    public String Genero { get; set; }
    public double Price { get; set; }
    public int QtdEstq { get; set;}

    public Livro() {
        Id = contadorID++;
    }
    
}
