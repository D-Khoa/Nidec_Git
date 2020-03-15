using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PQMDataViewer.Class
{
    class PostgresDatabase
    {
        public class PGDatabaseResult
        {
            public bool Success;
            public string Result;
            public List<object> Data;
        }

        public Task<PGDatabaseResult> ExecuteReaderAsync(string sConnectionString, string sSQL, params NpgsqlParameter[] parameters)
        {
            return Task.Run(() =>
            {
                try
                {
                    List<object> sData = new List<object>();
                    using (var newConnection = new NpgsqlConnection(sConnectionString))
                    using (var newCommand = new NpgsqlCommand(sSQL, newConnection))
                    {
                        newCommand.CommandType = CommandType.Text;
                        if (parameters != null) newCommand.Parameters.AddRange(parameters);
                        newConnection.Open();
                        NpgsqlDataReader reader = newCommand.ExecuteReader();
                        while(reader.Read())
                        {
                            object oData = new object();
                            foreach(var pro in oData.GetType().GetProperties())
                            {
                                for(int i = 0; i < reader.FieldCount; i++)
                                {
                                    if(pro.Name == reader.GetName(i))
                                    {
                                        pro.SetValue(oData, reader[i]);
                                    }
                                }
                            }
                            sData.Add(oData);
                        }
                        newConnection.Close();
                    }
                    PGDatabaseResult result = new PGDatabaseResult()
                    {
                        Data = sData,
                        Success = true
                    };
                    return result;
                }
                catch(Exception ex)
                {
                    PGDatabaseResult result = new PGDatabaseResult()
                    {
                        Result = "Error: " + ex.Message,
                        Success = false
                    };
                    return result;
                }
            });
        }

        public Task<int> ExecuteAsync(string sConnectionString, string sSQL, params NpgsqlParameter[] parameters)
        {
            return Task.Run(() =>
            {
                using (var newConnection = new NpgsqlConnection(sConnectionString))
                using (var newCommand = new NpgsqlCommand(sSQL, newConnection))
                {
                    newCommand.CommandType = CommandType.Text;
                    if (parameters != null) newCommand.Parameters.AddRange(parameters);
                    newConnection.Open();
                    return newCommand.ExecuteNonQuery();
                }
            });
        }

        public Task<DataSet> GetDatasetAsync(string sConnectionString, string sSQL, params NpgsqlParameter[] parameters)
        {
            return Task.Run(() =>
            {
                using (var newConnection = new NpgsqlConnection(sConnectionString))
                using (var newAdapter = new NpgsqlDataAdapter(sSQL, newConnection))
                {
                    newAdapter.SelectCommand.CommandType = CommandType.Text;
                    if (parameters != null) newAdapter.SelectCommand.Parameters.AddRange(parameters);
                    DataSet myDataset = new DataSet();
                    newAdapter.Fill(myDataset);
                    return myDataset;
                }
            });
        }
    }
}
