using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;

namespace COREAPP2.Infrastructure
{
    public interface IDapperHelper
    {
        IEnumerable<dynamic> DynamicProcWithParams<T>(string sql, dynamic parms, string connectionName = null);
        DynamicObject DynamicProcWithParamsSingle<T>(string sql, dynamic parms, string connectionName = null);
        IEnumerable<T> GetList<T>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where T : class;
        SqlConnection GetOpenConnection(string name = null);
        DynamicParameters GetParametersFromObject(object obj, string[] propertyNamesToIgnore);
        object GetPropertyValue(object target, string propertyName);
        int InsertMultiple<T>(string sql, IEnumerable<T> entities, string connectionName = null) where T : class, new();
        int InsertUpdateOrDeleteSql(string sql, dynamic parms, string connectionName = null);
        int InsertUpdateOrDeleteStoredProc(string procName, dynamic parms, string connectionName = null);
        Dictionary<Tmain, List<Tsub>> MultiPleGetList<Tmain, Tsub>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where Tmain : class;
        void Process<T>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where T : class;
        void SetIdentity<T>(IDbConnection connection, Action<T> setId);
        void SetPropertyValue(object p, string propName, object value);
        List<T> SqlWithParams<T>(string sql, dynamic parms, string connectionnName = null);
        T SqlWithParamsSingle<T>(string sql, dynamic parms, string connectionName = null);
        U StoredProcInsertWithID<T, U>(string procName, DynamicParameters parms, string connectionName = null);
        List<T> StoredProcWithParams<T>(string procname, dynamic parms, string connectionName = null);
        List<dynamic> StoredProcWithParamsDynamic(string procname, dynamic parms, string connectionName = null);
        T StoredProcWithParamsSingle<T>(string procname, dynamic parms, string connectionName = null);
        DataTable ToDataTable<T>(IList<T> list);
        T Top1<T>(string storedProcedure, DynamicParameters param = null, string connectionName = null) where T : class;
    }
}
