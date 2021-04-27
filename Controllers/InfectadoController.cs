using System.Threading.Tasks;
using ApiMongo.Data.Collections;
using ApiMongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.Id, dto.Nome, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso!");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        // GET: api/Infectado
        [HttpGet("{id}")]
        public async Task<ActionResult<Infectado>> GetInfectado(int id)
        {
          
            var filter = Builders<Infectado>.Filter.Eq(x => x.Id, id);

            var infectado = await _infectadosCollection.Find(filter).SingleAsync();

            if (infectado == null)
            {
                return NotFound();
            }

            return infectado;
        }

        // DELETE: api/Infectado
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteInfectado(int id)
        {

            var filter = Builders<Infectado>.Filter.Eq(x => x.Id, id);

            var infectado = await _infectadosCollection.Find(filter).SingleAsync();

            if (infectado == null)
            {
                return NotFound();
            }

            _infectadosCollection.DeleteOne(filter);
          
            return StatusCode(201, "Infectado exluido com sucesso!");
        }
    }
}