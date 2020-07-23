using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Data.Linq;

namespace JetCoders.Shared
{
	/// <summary>
	/// Represents extensions to Linq's Table types.
	/// </summary>
	public static class LinqTableExtensions
	{
		// Originally sourced from Omar @ http://weblogs.asp.net/omarzabir/archive/2008/10/30/linq-to-sql-delete-an-entity-using-primary-key-only.aspx
		// Modified by Eric Duncan to be an extension.

		/// <summary>
		/// Deletes an entity from the TSource table via the TKeyType primary key.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TPk"></typeparam>
		/// <param name="table"></param>
		/// <param name="pk"></param>
		/// <param name="dc"></param>
		public static void DeleteByPk<TSource, TPk>(this Table<TSource> table, TPk pk, DataContext dc)
			where TSource : class
		{
			//Table<TSource> table = dc.GetTable<TSource>();
			TableDef tableDef = GetTableDef<TSource>();

			dc.ExecuteCommand("DELETE FROM [" + tableDef.TableName + "] WHERE [" + tableDef.PkFieldName + "] = {0}", pk);
		}

	    #region supporting members

		private static readonly Dictionary<Type, TableDef> TableDefCache = new Dictionary<Type, TableDef>();

		private static TableDef GetTableDef<TEntity>() where TEntity : class
		{
			var entityType = typeof(TEntity);
			if (!TableDefCache.ContainsKey(entityType))
			{
				lock (TableDefCache)
				{
				    if (!TableDefCache.ContainsKey(entityType))
					{
						var attributes = entityType.GetCustomAttributes(typeof(TableAttribute), true);
					    var tableAttribute = attributes[0] as TableAttribute;
					    if (tableAttribute == null) return TableDefCache[entityType];
					    var tableName = tableAttribute.Name;
					    if (tableName.StartsWith("dbo."))
					        tableName = tableName.Substring("dbo.".Length);
					    var pkFieldName = "ID";

					    bool[] found = {false};
					    // Find the property which is the primary key so that we can find the 
					    // primary key field name in database
					    foreach (var columnAttributes in entityType.GetProperties().TakeWhile(prop => !found[0]).Select(prop => prop.GetCustomAttributes(typeof(ColumnAttribute), true)).Where(columnAttributes => columnAttributes.Length > 0))
					    {
					        foreach (ColumnAttribute columnAtt in from ColumnAttribute columnAtt in columnAttributes where columnAtt.IsPrimaryKey where false == String.IsNullOrEmpty(columnAtt.Storage) select columnAtt)
					        {
					            pkFieldName = columnAtt.Name.IsEmpty() ? columnAtt.Storage.TrimStart('_') : columnAtt.Name;

					            found[0] = true;
					            break;
					        }
					    }

					    var tableDef = new TableDef { TableName = tableName, PkFieldName = pkFieldName };
					    TableDefCache.Add(entityType, tableDef);
					    return tableDef;
					}
				    return TableDefCache[entityType];
				}
			}
		    return TableDefCache[entityType];
		}

		private class TableDef
		{
			public string TableName;
			public string PkFieldName;
		}

		#endregion
	}
}
