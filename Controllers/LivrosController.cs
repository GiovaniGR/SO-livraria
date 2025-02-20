using Microsoft.AspNetCore.Mvc;
using Livraria.Class;
using Microsoft.AspNetCore.WebUtilities;
using Livraria.Communication.Requests;

namespace Livraria.Controllers;
[Route("api/[controller]")]
[ApiController]

public class LivrosController : ControllerBase
{

    private static List<Livro> books = new List<Livro>();

    [HttpPost] //método para publicar novos livros
    public IActionResult AddLivro([FromBody] Livro novoLivro) {

        if (novoLivro == null || string.IsNullOrWhiteSpace(novoLivro.Titulo))
        {
            return BadRequest("Todos os campos são orbigatórios");
        };
        

        Livro l = new Livro
        {
            Titulo = novoLivro.Titulo,
            Autor = novoLivro.Autor,
            Genero = novoLivro.Genero,
            Price = novoLivro.Price,
            QtdEstq = novoLivro.QtdEstq

        };

        novoLivro.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1; //método que adiciona o id manualmente no livro

        books.Add(novoLivro);

        return Created();
    }

    [HttpGet] //Método para listar livros

    public IActionResult GetLivros() {

        if (books == null) {
            return NotFound("Lista não encontrada ou vazia");
        }
        return Ok(books);
    }

    [HttpPut("{id}")]//método para atualizar livros
    public IActionResult AlterandoLivros(int id, [FromBody]Livro livroAtt) {

        if (livroAtt == null) {
            return BadRequest("O livro tem que ser válido");
        }

        var buscarLivro = books.FirstOrDefault(l => l.Id == id); // expressão => usada para capturar o id

        if (buscarLivro == null) {
            return NotFound("Livro não encontrado");
        }

        buscarLivro.Titulo = livroAtt.Titulo;
        buscarLivro.Autor = livroAtt.Autor;
        buscarLivro.Genero = livroAtt.Genero;
        buscarLivro.Price = livroAtt.Price;
        buscarLivro.QtdEstq = livroAtt.QtdEstq;

        return Ok("");
    }

    [HttpDelete("{titulo}")]// metodo para deletar livros
    public IActionResult DeleteLivros(string titulo) 
    {
        var deletarLivros = books.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (deletarLivros == null) {
            return BadRequest("Livro não encontrado");
        }

        books.Remove(deletarLivros);
        return Ok($"Livro {titulo} deletado");
    }
    
}
