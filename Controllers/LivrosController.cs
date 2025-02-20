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

        books.Add(novoLivro);


        return Ok("Livro cadastrado com sucesso");
    }

    [HttpGet] //Método para listar livros

    public IActionResult GetLivros() {

        if (books == null) {
            return NotFound("Lista não encontrada ou vazia");
        }
        return Ok(books);
    }

    [HttpPut("{id}")]
    public IActionResult AlterandoLivros(int id, [FromBody]Livro livroAtt) {

        if (AlterandoLivros == null) {
            return BadRequest("O livro tem que ser válido");
        }

        var buscarLivro = books.FirstOrDefault(l => l.Id == id);

        if (buscarLivro == null) {
            return NotFound("Livro não encontrado");
        }

        buscarLivro.Titulo = livroAtt.Titulo;
        buscarLivro.Autor = livroAtt.Autor;
        buscarLivro.Genero = livroAtt.Genero;
        buscarLivro.Price = livroAtt.Price;
        buscarLivro.QtdEstq = livroAtt.QtdEstq;

        return Ok("Livro atualizado");
    }
    
}
