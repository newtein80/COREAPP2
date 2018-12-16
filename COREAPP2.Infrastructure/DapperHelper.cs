using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace COREAPP2.Infrastructure
{
    public class DapperHelper : IDapperHelper
    {
        #region+ Reference
        //https://www.learnmvc.in/crud-operation-with-dotnetcore-dapper.php
        //https://techbrij.com/asp-net-core-postgresql-dapper-crud
        //https://dotnetcorecentral.com/blog/asp-net-core-web-api-application-with-dapper-part-1/
        //https://dotnetcorecentral.com/blog/asp-net-core-web-api-application-with-dapper-part-2/
        //https://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-2-razor-page-with-dapper-and-repository-pattern/
        //http://www.mukeshkumar.net/articles/aspnetcore/asp-net-core-web-api-with-oracle-database-and-dapper
        //google : asp.net core dapper interface
        //https://stackoverflow.com/questions/50507382/store-retrieve-connectionstring-from-appsettings-json-in-asp-net-core-2-mvc-ap
        //https://stackoverflow.com/questions/46940710/getting-value-from-appsettings-json-in-net-core
        //https://www.codeproject.com/Articles/889668/SQL-Server-Dapper
        //https://stackoverflow.com/questions/47420522/read-appsettings-json-from-a-class-in-net-core-2
        //https://andrewlock.net/sharing-appsettings-json-configuration-files-between-projects-in-asp-net-core/
        //http://www.nullskull.com/a/10399923/sqlmapperhelper--a-helper-class-for-dapperdotnet.aspx
        //https://exceptionnotfound.net/using-dapper-asynchronously-in-asp-net-core-2-1/
        //https://stackoverflow.com/questions/35015066/passing-applications-connection-string-down-to-a-repository-class-library-in-as
        //https://stackoverflow.com/questions/9218847/how-do-i-handle-database-connections-with-dapper-in-net
        //google : dapper helper connection string, dapper connection string site:stackoverflow.com, asp.net core dapperhelper connection string, asp net core connection string manage
        #endregion

        //private readonly string connectionString = "Data Source=PARKJS\\SQLEXPRESS;Initial Catalog=COREAPP;User ID=sa;Password=#skdlf12;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //public DapperHelper(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}
        IConfiguration configuration;

        public DapperHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connection = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }

        #region+ http://www.nullskull.com/a/10399923/sqlmapperhelper--a-helper-class-for-dapperdotnet.aspx
        /// <summary>
        /// Gets the open connection.
        /// </summary>
        /// <param name="name">The name of the connection string (optional).</param>
        /// <returns></returns>
        public SqlConnection GetOpenConnection(string name = null)
        {
            string connString = "";

            name = "Data Source=127.0.0.1;Initial Catalog=PJSWORK;User ID=sa;Password=#skdlf12;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connString = name;

            //connString = name == null ? connString = ConfigurationManager.ConnectionStrings[0].ConnectionString : connString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            //connString = name == null ? connString = Configuration.GetConnectionString("DefaultConnection") : connString = Configuration.GetConnectionString("DefaultConnection");
            var connection = new SqlConnection(GetConnectionString()); //new SqlConnection(connString);
            connection.Open();
            return connection;
        }

        public int InsertMultiple<T>(string sql, IEnumerable<T> entities, string connectionName = null) where T : class, new()
        {
            using (SqlConnection cnn = GetOpenConnection(connectionName))
            {
                int records = 0;

                foreach (T entity in entities)
                {
                    records += cnn.Execute(sql, entity);
                }
                return records;
            }
        }

        public DataTable ToDataTable<T>(IList<T> list)// this IList<T> list
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                table.Rows.Add(values);
            }
            return table;
        }

        public DynamicParameters GetParametersFromObject(object obj, string[] propertyNamesToIgnore)
        {
            if (propertyNamesToIgnore == null) propertyNamesToIgnore = new string[] { String.Empty };
            DynamicParameters p = new DynamicParameters();
            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in properties)
            {
                if (!propertyNamesToIgnore.Contains(prop.Name))
                    p.Add("@" + prop.Name, prop.GetValue(obj, null));
            }
            return p;
        }

        public void SetIdentity<T>(IDbConnection connection, Action<T> setId)
        {
            dynamic identity = connection.Query("SELECT @@IDENTITY AS Id").Single();
            T newId = (T)identity.Id;
            setId(newId);
        }

        public object GetPropertyValue(object target, string propertyName)
        {
            PropertyInfo[] properties = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            object theValue = null;
            foreach (PropertyInfo prop in properties)
            {
                if (string.Compare(prop.Name, propertyName, true) == 0)
                {
                    theValue = prop.GetValue(target, null);
                }
            }
            return theValue;
        }

        public void SetPropertyValue(object p, string propName, object value)
        {
            Type t = p.GetType();
            PropertyInfo info = t.GetProperty(propName);
            if (info == null)
                return;
            if (!info.CanWrite)
                return;
            info.SetValue(p, value, null);
        }

        /// <summary>
        /// Stored proc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procname">The procname.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public List<T> StoredProcWithParams<T>(string procname, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Query<T>(procname, (object)parms, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        /// <summary>
        /// Stored proc with params returning dynamic.
        /// </summary>
        /// <param name="procname">The procname.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public List<dynamic> StoredProcWithParamsDynamic(string procname, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Query(procname, (object)parms, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Stored proc insert with ID.
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <typeparam name="U">The Type of the ID</typeparam>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parms">instance of DynamicParameters class. This should include a defined output parameter</param>
        /// <returns>U - the @@Identity value from output parameter</returns>
        public U StoredProcInsertWithID<T, U>(string procName, DynamicParameters parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                var x = connection.Execute(procName, (object)parms, commandType: CommandType.StoredProcedure);
                return parms.Get<U>("@ID");
            }
        }

        /// <summary>
        /// SQL with params.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public List<T> SqlWithParams<T>(string sql, dynamic parms, string connectionnName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionnName))
            {
                return connection.Query<T>(sql, (object)parms).ToList();
            }
        }

        /// <summary>
        /// Insert update or delete SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public int InsertUpdateOrDeleteSql(string sql, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Execute(sql, (object)parms);
            }
        }

        /// <summary>
        /// Insert update or delete stored proc.
        /// </summary>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public int InsertUpdateOrDeleteStoredProc(string procName, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Execute(procName, (object)parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// SQLs the with params single.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public T SqlWithParamsSingle<T>(string sql, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Query<T>(sql, (object)parms).FirstOrDefault();
            }
        }

        /// <summary>
        ///  proc with params single returning Dynamic object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public System.Dynamic.DynamicObject DynamicProcWithParamsSingle<T>(string sql, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Query(sql, (object)parms, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        /// <summary>
        /// proc with params returning Dynamic.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public IEnumerable<dynamic> DynamicProcWithParams<T>(string sql, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Query(sql, (object)parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Stored proc with params returning single.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procname">The procname.</param>
        /// <param name="parms">The parms.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public T StoredProcWithParamsSingle<T>(string procname, dynamic parms, string connectionName = null)
        {
            using (SqlConnection connection = GetOpenConnection(connectionName))
            {
                return connection.Query<T>(procname, (object)parms, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
        #endregion

        #region+ https://m.blog.naver.com/PostView.nhn?blogId=wolfre&logNo=220597602977&proxyReferer=https%3A%2F%2Fwww.google.co.kr%2F
        // Select List
        public IEnumerable<T> GetList<T>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where T : class
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var output = connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
                //connection.Close();
                return output;
            }
        }

        // Multiple Select 1: N...
        public Dictionary<Tmain, List<Tsub>> MultiPleGetList<Tmain, Tsub>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where Tmain : class
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                Dictionary<Tmain, List<Tsub>> listTable = new Dictionary<Tmain, List<Tsub>>();

                using (var output = connection.QueryMultiple(storedProcedure, param, commandType: CommandType.StoredProcedure))
                {
                    var main = output.Read<Tmain>().SingleOrDefault();
                    var sub = output.Read<Tsub>().ToList();

                    if (main != null && sub != null)
                    {
                        listTable.Add((Tmain)main, sub);
                    }

                    return listTable;
                }
            }
        }

        // Top 1
        public T Top1<T>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where T : class
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var output = connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                //connection.Close();
                return output;
            }
        }

        // Insert, Update, Delete
        public void Process<T>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where T : class
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                connection.Execute(storedProcedure, param, commandType: CommandType.StoredProcedure);
                //connection.Close();
            }
        }

        // 메인 서브 트랜잭션
        //public int DeleteProduct(Product product)
        //{
        //    using (IDbConnection connection = OpenConnection())
        //    {
        //        const string deleteImageQuery = "DELETE FROM Production.ProductProductPhoto " +
        //                                        "WHERE ProductID = @ProductID";
        //        const string deleteProductQuery = "DELETE FROM Production.Product " +
        //                                          "WHERE ProductID = @ProductID";
        //        IDbTransaction transaction = connection.BeginTransaction();
        //        int rowsAffected = connection.Execute(deleteImageQuery,new { ProductID = product.ProductID }, transaction);
        //        rowsAffected += connection.Execute(deleteProductQuery,new { ProductID = product.ProductID }, transaction);
        //        transaction.Commit();
        //        return rowsAffected;
        //    }
        //}



        //// Select List
        //public static IEnumerable<T> GetList<T>(string targetDB, string storedProcedure, DynamicParameters param = null) where T : class
        //{
        //    using (SqlConnection connection = new SqlConnection(targetDB))
        //    {
        //        connection.Open();
        //        var output = connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
        //        connection.Close();
        //        return output;
        //    }
        //}

        //// Multiple Select 1: N...
        //public static Dictionary<Tmain, List<Tsub>> MultiPleGetList<Tmain, Tsub>(string targetDB, string storedProcedure, DynamicParameters param = null) where Tmain : class
        //{
        //    using (SqlConnection connection = new SqlConnection(targetDB))
        //    {
        //        connection.Open();

        //        Dictionary<Tmain, List<Tsub>> listTable = new Dictionary<Tmain, List<Tsub>>();

        //        using (var output = connection.QueryMultiple(storedProcedure, param, commandType: CommandType.StoredProcedure))
        //        {
        //            var main = output.Read<Tmain>().SingleOrDefault();
        //            var sub = output.Read<Tsub>().ToList();

        //            if (main != null && sub != null)
        //            {
        //                listTable.Add((Tmain)main, sub);
        //            }

        //            return listTable;
        //        }
        //    }
        //}

        //// Top 1
        //public static T Top1<T>(string targetDB, string storedProcedure, DynamicParameters param = null) where T : class
        //{
        //    using (SqlConnection connection = new SqlConnection(targetDB))
        //    {
        //        connection.Open();
        //        var output = connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //        connection.Close();
        //        return output;
        //    }
        //}

        //// Insert, Update, Delete
        //public static void Process<T>(string targetDB, string storedProcedure, DynamicParameters param = null) where T : class
        //{
        //    using (SqlConnection connection = new SqlConnection(targetDB))
        //    {
        //        connection.Open();
        //        connection.Execute(storedProcedure, param, commandType: CommandType.StoredProcedure);
        //        connection.Close();
        //    }
        //}

        //// 메인 서브 트랜잭션
        ////public int DeleteProduct(Product product)
        ////{
        ////    using (IDbConnection connection = OpenConnection())
        ////    {
        ////        const string deleteImageQuery = "DELETE FROM Production.ProductProductPhoto " +
        ////                                        "WHERE ProductID = @ProductID";
        ////        const string deleteProductQuery = "DELETE FROM Production.Product " +
        ////                                          "WHERE ProductID = @ProductID";
        ////        IDbTransaction transaction = connection.BeginTransaction();
        ////        int rowsAffected = connection.Execute(deleteImageQuery,new { ProductID = product.ProductID }, transaction);
        ////        rowsAffected += connection.Execute(deleteProductQuery,new { ProductID = product.ProductID }, transaction);
        ////        transaction.Commit();
        ////        return rowsAffected;
        ////    }
        ////}
        #endregion
    }
}
