using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles.Base
{
    internal abstract class BaseEntity
    {
        public string Id { get; set; }

        protected BaseEntity()
        {
            Id= Guid.NewGuid().ToString();
        }


    }
}
