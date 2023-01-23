using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary2;
using ClassLibrary2.DTO;

namespace WebApplication2.Controllers
{
    public class IngrdController : ApiController
    {
        // GET: api/Recipes
            RecipeDB db = new RecipeDB();
        public IHttpActionResult Get()
        {
            List <Ingredients> ingredients = db.Ingredients.ToList();
            List<IngrdDTO> ingredientsDto = new List<IngrdDTO>();
            try
            {
                foreach (Ingredients i in ingredients)
                {
                    IngrdDTO ingD = new IngrdDTO();
                    ingD.id = i.id;
                    ingD.name = i.name;
                    ingD.calories = (int)i.calories;
                    ingD.image = i.image;
                    ingredientsDto.Add(ingD);
                }
                return Ok(ingredientsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Recipes/5
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/Recipes
        public IHttpActionResult Post([FromBody] Ingredients value)
        {
            try
            {
                Ingredients ing = value;
                db.Ingredients.Add(ing);
                db.SaveChanges();
                // returns response with a location uri
                return Created(new Uri(Request.RequestUri.AbsoluteUri + ing.id), ing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // PUT: api/Recipes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recipes/5
        public void Delete(int id)
        {
        }
    }
}
