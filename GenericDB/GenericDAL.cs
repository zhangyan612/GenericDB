using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace GenericDB
{
    public class GenericDAL
    {
        public static DataTable ReadTable(string query, params object[] args)
        {
            var dataTable = new DataTable();

            using (AdoHelper db = new AdoHelper("14a_Op_Intel", true))
            using (SqlDataReader rdr = db.ExecDataReader(query, args))
            {
                dataTable.Load(rdr);
            }
            return dataTable;
        }


        public static DataTable ReadStoredProc(string query, params object[] args)
        {
            var dataTable = new DataTable();

            using (AdoHelper db = new AdoHelper("14a_Op_Intel", true))
            using (SqlDataReader dr = db.ExecDataReaderProc(query, args))
            {
                dataTable.Load(dr);
            }
            return dataTable;
        }

        public static DataTable ReadStoredProcFromList(string query, List<string> args)
        {
            var dataTable = new DataTable();

            using (AdoHelper db = new AdoHelper("14a_Op_Intel", true))
            using (SqlDataReader dr = db.ExecDataReaderProcGeneric(query, args))
            {
                dataTable.Load(dr);
            }
            return dataTable;
        }


    }
}
