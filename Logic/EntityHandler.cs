using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class EntityHandler
    {
        public void CreateNewCategory(string name)
        {
            try
            {

            } catch (Exception ex)
            {
                throw new Exception(ex + "Kunde ej skapa kategori");
            }
        }
    }
}
