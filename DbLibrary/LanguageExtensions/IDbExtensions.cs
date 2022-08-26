using System;
using System.Data;
using System.Linq;
using System.Text;

namespace DbLibrary.LanguageExtensions
{
    /// <summary>
    /// This extension is good for viewing a SQL statement (SELECT, DELETE, UPDATE, INSERT) that
    /// use managed data provider parameters to actually see values that will be passed to the
    /// database. Has been tested with SQL-Server using @ as a parameter marker, Oracle with : as
    /// the parameter marker and MS-Access using @ as a parameter marker.
    /// 
    /// In regards to MS-Access, parameters are ordinal position so if parameters are named they
    /// must be in the same order as in the SQL statement. 
    /// 
    /// With Oracle, the command property BindByName must be set to true else the Oracle managed
    /// data provider will treat parameters as ordinal positioned.
    /// </summary>
    /// <remarks>Karen Payne</remarks>
    public static class IDbExtensions
    {
        /// <summary> 
        /// Used to show an SQL statement with actual values for debugging or logging to a file. 
        /// </summary> 
        /// <param name="pCommand">Command object</param>
        /// <param name="pProvider"></param>
        /// <param name="pQualifier">Defaults to SQL-Server</param>
        /// <returns>Command object command text with parameter values</returns> 
        public static string ActualCommandText(this IDbCommand pCommand, CommandProvider pProvider = CommandProvider.SqlServer, string pQualifier = "@")
        {
            var sb = new StringBuilder(pCommand.CommandText);

            if (pProvider != CommandProvider.Oracle)
            {
                // test for at least one parameter without a name, if found stop here.
                var emptyParameterNames =
                    (
                        from T in pCommand.Parameters.Cast<IDataParameter>()
                        where string.IsNullOrWhiteSpace(T.ParameterName)
                        select T
                    ).FirstOrDefault();

                if (emptyParameterNames != null)
                {
                    return pCommand.CommandText;
                }
            }
            else if (pProvider == CommandProvider.Oracle)
            {
                pQualifier = ":";
            }

            foreach (IDataParameter p in pCommand.Parameters)
            {

                if ((p.DbType == DbType.AnsiString) || (p.DbType == DbType.AnsiStringFixedLength) || (p.DbType == DbType.Date) || (p.DbType == DbType.DateTime) || (p.DbType == DbType.DateTime2) || (p.DbType == DbType.Guid) || (p.DbType == DbType.String) || (p.DbType == DbType.StringFixedLength) || (p.DbType == DbType.Time) || (p.DbType == DbType.Xml))
                {
                    if (p.ParameterName[..1] == pQualifier)
                    {
                        if (p.Value == null)
                        {
                            throw new Exception($"no value given for parameter '{p.ParameterName}'");
                        }

                        sb = sb.Replace(p.ParameterName, $"'{p.Value.ToString().Replace("'", "''")}'");

                    }
                    else
                    {
                        sb = sb.Replace(string.Concat(pQualifier, p.ParameterName), $"'{p.Value.ToString().Replace("'", "''")}'");
                    }
                }
                else
                {
                    /*
                     * Dummy up a INSERT Oracle statement where the RETURNING has no
                     * value for that parameter so return the parameter name instead
                     * rather than a value.
                     */
                    sb = pProvider == CommandProvider.Oracle ? sb.Replace(p.ParameterName, p.Value?.ToString() ?? p.ParameterName) :
                        sb.Replace(p.ParameterName, p.Value.ToString());
                }
            }

            return sb.ToString();

        }
    }
}