namespace SqlServerColumnDescriptions.Classes;

internal class SqlStatements
{
    public static string GetDatabaseNames 
        => "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb') ORDER BY name";

    public static string GetTableNames(string name)
        => $"SELECT TABLE_SCHEMA + '.' + TABLE_NAME FROM {name}.INFORMATION_SCHEMA.TABLES " + 
           "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> 'sysdiagrams' ORDER BY TABLE_NAME";

    public static string Descriptions()
        => @$"SELECT C.COLUMN_NAME AS ColumnName, C.ORDINAL_POSITION AS ColumnId, P.value AS Description
FROM INFORMATION_SCHEMA.TABLES AS T
     INNER JOIN INFORMATION_SCHEMA.COLUMNS AS C ON C.TABLE_NAME = T.TABLE_NAME
     INNER JOIN sys.columns AS SC1 ON SC1.object_id = OBJECT_ID(T.TABLE_SCHEMA + '.' + T.TABLE_NAME)
                                      AND SC1.name = C.COLUMN_NAME
     LEFT OUTER JOIN sys.extended_properties AS P ON P.major_id = SC1.object_id
                                                     AND P.minor_id = SC1.column_id
                                                     AND P.name = 'MS_Description'
WHERE T.TABLE_NAME = @TableName AND P.value IS NOT NULL ORDER BY ColumnId;
";
}