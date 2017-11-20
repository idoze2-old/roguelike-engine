using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Component
{
    public class User:Component
    {
        public int PlayerID;
        public User(int PlayerID):base(PlayerID)
        {

        }
    }
}
