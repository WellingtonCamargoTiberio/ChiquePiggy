using Bingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.Controllers
{
    public class BingoController : Controller
    {
        public ActionResult Index()
        {
            var bingoModel = new BingoModel
            {
                Titulo = "BINGO",
                Colunas = new List<BingoColuna>
                {
                new BingoColuna { Letra = 'B', Numeros = GerarNumeros(1, 15) },
                new BingoColuna { Letra = 'I', Numeros = GerarNumeros(16, 30) },
                new BingoColuna { Letra = 'N', Numeros = GerarNumeros(31, 45) },
                new BingoColuna { Letra = 'G', Numeros = GerarNumeros(46, 60) },
                new BingoColuna { Letra = 'O', Numeros = GerarNumeros(61, 75) }
            }
            };

            return View(bingoModel);
        }

        private List<int> GerarNumeros(int inicio, int fim)
        {
            var numeros = new List<int>();
            for (int i = inicio; i <= fim; i++)
            {
                numeros.Add(i);
            }
            return numeros;
        }
    }
}
