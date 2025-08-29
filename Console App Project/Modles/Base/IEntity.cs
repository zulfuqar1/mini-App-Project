using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles.Base
{
    internal abstract class IEntity
    {
        public string id { get; set; }

        protected IEntity()
        {
            id= Guid.NewGuid().ToString();
        }


    }
}
