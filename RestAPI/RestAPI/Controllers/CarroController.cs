using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("Carros")]
    public class CarroController : ControllerBase
    {
        private static List<Carro> carros = new List<Carro>();

        #region Get

        [HttpGet]
        public ActionResult<List<Carro>> GetAll()
        {
            return carros;
        }

        [HttpGet("marca/{marca}")]
        public ActionResult<List<Carro>> GetByBrand(string marca)
        {
            var carroMarca = carros.Where(c => c.Marca == marca).ToList();
            if (carroMarca.Count == 0)
            {
                return NotFound();
            }
            return Ok(carroMarca);
        }
        
        [HttpGet("modelo/{modelo}")]
        public ActionResult<Carro> GetByName(string modelo)
        {
            var carroModelo = carros.FirstOrDefault(c => c.Modelo == modelo);
            if (carroModelo == null)
            {
                return NotFound();
            }
            return Ok(carroModelo);
        }

        [HttpGet("ano/{ano}")]
        public ActionResult<List<Carro>> GetByYear(int ano)
        {
            var carroAno = carros.Where(c => c.Ano == ano).ToList();
            if (carroAno.Count == 0)
            {
                return NotFound();
            }

            return Ok(carroAno);
        }

        #endregion

        
        #region Post

        [HttpPost]
        public ActionResult<List<Carro>> Post(Carro carro)
        {
            if (carro == null)
            {
                return BadRequest("Dados Invalidos!");
            }
            
            carro.Id = Guid.NewGuid();
            carros.Add(carro);

            return Ok();
        }

        #endregion
        
        
        #region Update

        [HttpPut("{id}")]
        public ActionResult<List<Carro>> UpdateById(Guid id, Carro carroNovo)
        {
            var carroExistente = carros.FirstOrDefault(c => c.Id == id);
            if (carroExistente == null)
            {
                return NotFound();
            }

            carroExistente.Marca = carroNovo.Marca;
            carroExistente.Modelo = carroNovo.Modelo;
            carroExistente.Ano = carroNovo.Ano;
            carroExistente.Preco = carroNovo.Preco;

            return Ok(carroNovo);
        }

        #endregion
        
        
        #region Delete
        
        [HttpDelete("{id}")]
        public ActionResult<List<Carro>> DeleteById(Guid id)
        {
            var carroId = carros.Find(c => c.Id == id);
            if (carroId == null)
            {
                return NotFound();
            }
            
            carros.Remove(carroId);

            return Ok(carroId);
        }

        #endregion
    }
}