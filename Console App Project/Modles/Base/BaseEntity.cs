using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles.Base
{
    internal abstract class BaseEntity
    {
        public string id { get; set; }

        protected BaseEntity()
        {
            id= Guid.NewGuid().ToString();
        }


    }
}
