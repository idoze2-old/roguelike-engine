using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Component
{
    public class Component
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public Component(int id)
        {
            this.id = id;
        }

    }
    public class SaveFile : Component
    {
        public SaveFile(int id):base(id)
        {

        }
    }
    
}
