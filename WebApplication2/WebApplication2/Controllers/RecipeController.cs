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
    public class RecipeController : ApiController
    {
        RecipeDB db = new RecipeDB();
        // GET api/values
        //public IHttpActionResult Get()
        //{
        //    List<Recipes> recipes = db.Recipes.ToList();
        //    List<RecipesDTO> recipesDtos = new List<RecipesDTO>();
        //    try
        //    {
        //        foreach (Recipes rec in recipes)
        //        {
        //            RecipesDTO recD = new RecipesDTO();
        //            recD.id = Convert.ToInt32(rec.id);
        //            recD.name = rec.name;
        //            recD.imageurl = rec.image;
        //            recD.cookingmethod = rec.cookingMethod;
        //            recD.ingerdients = new List<IngrdDTO>();
        //            recD.Time = Convert.ToInt32(rec.time);
        //            foreach (Ingredients i in rec.Ingredients)
        //            {
        //                IngrdDTO ingDrec = new IngrdDTO();
        //                ingDrec.id = Convert.ToInt32(i.id);
        //                ingDrec.name = i.name;
        //                ingDrec.calories = Convert.ToInt32(i.calories);
        //                ingDrec.imageurl = i.image;
        //                recD.ingerdients.Add(ingDrec);
        //            }
        //            recipesDtos.Add(recD);
        //        }
        //        return Ok(recipesDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        public List<RecipesDTO> Get()
        {
            RecipeDB db = new RecipeDB();
            var ing = db.Recipes.Select(x => new RecipesDTO
            {
                id = x.id,
                name = x.name,
                imageurl = x.image,
                cookingmethod = x.cookingMethod
            }).ToList();
            return ing;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] RecipesDTO value)
        {
            try
            {
                RecipeDB db = new RecipeDB();
                int counter = db.Recipes.Count();
                RecipesDTO i = value;
                Recipes x = new Recipes();
                x.id = ++counter;
                x.name = i.name;
                x.image = i.imageurl;
                x.time = i.Time;
                x.cookingMethod = i.cookingmethod;
                List<Ingredients> ing = new List<Ingredients>();
                foreach (IngrdDTO item in i.ingerdients)
                {
                    ing.Add(db.Ingredients.FirstOrDefault(y => y.id == item.id));
                }
                x.Ingredients = ing;
                db.Recipes.Add(x);
                db.SaveChanges();
                return Ok();
                // return Created(new Uri(Request.RequestUri.AbsoluteUri + i.recipeId), i);
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
