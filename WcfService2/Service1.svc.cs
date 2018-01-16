using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public int GetHighScore(int UserID)
        {
            try
            {
                DataTable Data = DAL.oledbhelper.GetTable("SELECT u.UName, s.Score FROM ((Users u INNER JOIN UserToSaveFile uts ON u.UserID = uts.UserID AND u.UserID = " + UserID + ") INNER JOIN SaveFile s ON uts.SaveFileID = s.SaveFileID) ORDER BY s.Score DESC");
                DataRow DataR = Data.Rows[0];
                return int.Parse(DataR["s.Score"].ToString());
            }
            catch
            {
                throw;
                return 0;
            }
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
