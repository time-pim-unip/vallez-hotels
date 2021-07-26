using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Common
{
    public static class DbParameterExtension
    {
        public static void AddParameter(this IDbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);

        }

        public static void AddParameter(this IDbCommand command, string parameterName, object parameterValue, DbType dbType)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            parameter.DbType = dbType;
            command.Parameters.Add(parameter);

        }
    }
}
