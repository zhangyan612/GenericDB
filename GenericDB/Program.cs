using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadStoredProcExample();
            ReadStoredProcWebRequestExample();

            Console.ReadKey();
        }

        public static List<string> ConstructArgs(NameValueCollection myCol)
        {
            List<string> args = new List<string>();

            foreach (string k in myCol.AllKeys) // skip 1 if first one is stored proc name
            {
                var key = "@" + k;
                var value = myCol[k];
                args.Add(key);
                args.Add(value);
            }
            return args;
        }


        public static void ReadStoredProcWebRequestExample()
        {
            string name = "GetUserByName";

            // simulating QueryString in web request  var parameters = Request.QueryString;
            NameValueCollection myCol = new NameValueCollection();
            myCol.Add("FirstName", "Yan");
            myCol.Add("LastName", "Zhang");
            myCol.Add("Theme", "1");

            var args = ConstructArgs(myCol);

            var data = GenericDAL.ReadStoredProcFromList(name, args);

            string json = JsonConvert.SerializeObject(data);

            Console.WriteLine(json);
        }

        public static void ReadStoredProcExample()
        {
            string name = "GetUserByName";

            var data = GenericDAL.ReadStoredProc(name, "@FirstName", "Yan", "@LastName", "Zhang", "@Theme", "1");

            string json = JsonConvert.SerializeObject(data);

            Console.WriteLine(json);
        }

        public static void ReadTableExample()
        {
            string qry = "Select * FROM [Op_Intel].[pnr].[WebUsers] where [FirstName] =@FirstName and [LastName] = @LastName ";

            var data = GenericDAL.ReadTable(qry, "@FirstName", "Yan", "@LastName", "Zhang");

            string json = JsonConvert.SerializeObject(data);

            Console.WriteLine(json);
        }
    }
}
