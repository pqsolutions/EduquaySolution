using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public class UtilityDL
    {
        private const int CommandTimeout = 600;
        private static DbConnect _dbConnect;
        public UtilityDL()
        {
            _dbConnect = new DbConnect();
        }

        public static List<T> FillData<T>(string query) where T : IFill, new()
        {
            return FillData<T>(query, CommandTimeout);
        }
        public static List<T> FillData<T>(string query, int commandTimeOut) where T : IFill, new()
        {
            List<T> entityList = new List<T>();
            SqlConnection connection = GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(query, connection) {CommandTimeout = commandTimeOut};
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T entity = new T();
                    entity.Fill(reader);
                    entityList.Add(entity);
                }

                reader.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            }
            catch (SqlException eq)
            {
                throw new ApplicationException(eq.Message);
            }
            finally
            {
                connection.Close();
            }
            return entityList;
        }

        public static List<T> FillData<T>(string procedureName, List<SqlParameter> parameters) where T : IFill, new()
        {
            List<T> entityList = new List<T>();

            SqlConnection connection = GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T entity = new T();
                    entity.Fill(reader);
                    entityList.Add(entity);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (InvalidOperationException ioex)
            {
                throw new ApplicationException(ioex.Message);
            }
            finally
            {
                connection.Close();
            }
            return entityList;
        }

        public static T FillEntity<T>(string procedureName, List<SqlParameter> parameters) where T : IFill, new()
        {
            T entity = new T();

            SqlConnection connection = GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    entity.Fill(reader);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (InvalidOperationException ioex)
            {
                throw new ApplicationException(ioex.Message);
            }
            finally
            {
                connection.Close();
            }
            return entity;
        }

        public static List<T> FillData<T>(string procedureName, List<SqlParameter> parameters, bool output, out object scopeOutput) where T : IFill, new()
        {
            List<T> entityList = new List<T>();

            SqlConnection connection = GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                        if (parameter.Direction.ToString().ToLower() == "output")
                            command.Parameters["@SCOPE_OUTPUT"].Direction = ParameterDirection.Output;
                    }
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T entity = new T();
                    entity.Fill(reader);
                    entityList.Add(entity);
                }
                scopeOutput = command.Parameters["@SCOPE_OUTPUT"].Value;
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (InvalidOperationException ioex)
            {
                throw new ApplicationException(ioex.Message); ;
            }
            finally
            {
                connection.Close();
            }
            return entityList;
        }

        #region Execute Non Query

        public static void ExecuteNonQuery(string query)
        {
            ExecuteNonQuery(query, CommandTimeout);
        }

        public static void ExecuteNonQuery(string query, int commandTimeOut)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection) {CommandTimeout = commandTimeOut};

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void ExecuteNonQuery(string procedureName, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                }
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static object ExecuteNonQuery(string procedureName, List<SqlParameter> parameters, bool output)
        {
            object scope_output;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                        if (parameter.Direction.ToString().ToLower() == "output")
                            command.Parameters["@SCOPE_OUTPUT"].Direction = ParameterDirection.Output;
                    }

                }
                connection.Open();

                command.ExecuteNonQuery();
                scope_output = command.Parameters["@SCOPE_OUTPUT"].Value;
                connection.Close();
            }
            return scope_output;
        }



        #endregion Execute Non Query

        #region Read Scalar

        public static object ReadScalar(string query)
        {
            return ReadScalar(query, CommandTimeout);
        }

        public static object ReadScalar(string query, int commandTimeOut)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection) {CommandTimeout = commandTimeOut};
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                    return reader[0];

                reader.Close();
            }

            return null;
        }

        public static object ReadScalar(string procedureName, List<SqlParameter> parameters)
        {
            return ReadScalar(procedureName, parameters, CommandTimeout);
        }

        public static object ReadScalar(string procedureName, List<SqlParameter> parameters, int commandTimeOut)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure, CommandTimeout = commandTimeOut
                };
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                    return reader[0];

                reader.Close();
            }

            return null;
        }

        #endregion Read Scalar

        private static SqlConnection GetConnection()
        {
            _dbConnect = new DbConnect();
            return _dbConnect.GetConnection();
        }
    }
}
