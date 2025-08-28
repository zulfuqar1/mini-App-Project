using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles
{
    internal abstract class IEntity
    {
        static int count = 0;
        int id;


        protected IEntity()
        {
             count++;
            id = count;
        }
    }
}
