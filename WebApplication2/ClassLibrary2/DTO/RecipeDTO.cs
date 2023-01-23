using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.DTO
{
        public class RecipesDTO
        {
            public int id;
            public string name;
            public string imageurl;
            public string cookingmethod;
            public List<IngrdDTO> ingerdients = new List<IngrdDTO>();
            public int Time;
        }
}
