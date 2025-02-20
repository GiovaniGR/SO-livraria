namespace Livraria.Communication.Requests;

public class UpdateBooks
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public double Price { get; set; }
    public int QtdEstq { get; set; }
}
