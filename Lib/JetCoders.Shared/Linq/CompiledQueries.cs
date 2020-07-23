using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Linq;

namespace JetCoders.Shared
{
	/// <summary>
	/// Represents a list of Compiled Linq Queries
	/// </summary>
	public class CompiledQueries
	{
		private readonly Dictionary<string, Delegate> _compiledQueries =
			new Dictionary<string, Delegate>();

		/// <summary>
		/// Creates a statically compiled Linq query and returns the delegate to invoke.
		/// </summary>
		/// <typeparam name="TArg0">The DataContext to query.</typeparam>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <param name="key">The key that identifies this specific compiled query.</param>
		/// <param name="query">The IQueryable to invoke.</param>
		/// <returns></returns>
		public Func<TArg0, TResult> Get<TArg0, TResult>(string key, Expression<Func<TArg0, TResult>> query) where TArg0 : DataContext
		{
			return (Func<TArg0, TResult>)InternalGet(key, () => CompiledQuery.Compile(query));
		}
		/// <summary>
		/// Creates a statically compiled Linq query and returns the delegate to invoke.
		/// </summary>
		/// <typeparam name="TArg0">The DataContext to query.</typeparam>
		/// <typeparam name="TArg1">A parameter type to pass into the anonymous type for the IQueryable.</typeparam>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <param name="key">The key that identifies this specific compiled query.</param>
		/// <param name="query">The IQueryable to invoke.</param>
		/// <returns></returns>
		public Func<TArg0, TArg1, TResult> Get<TArg0, TArg1, TResult>(string key, Expression<Func<TArg0, TArg1, TResult>> query) where TArg0 : DataContext
		{
			return (Func<TArg0, TArg1, TResult>)InternalGet(key, () => CompiledQuery.Compile(query));
		}
		/// <summary>
		/// Creates a statically compiled Linq query and returns the delegate to invoke.
		/// </summary>
		/// <typeparam name="TArg0">The DataContext to query.</typeparam>
		/// <typeparam name="TArg1">A parameter type to pass into the anonymous type for the IQueryable.</typeparam>
		/// <typeparam name="TArg2">A parameter type to pass into the anonymous type for the IQueryable.</typeparam>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <param name="key">The key that identifies this specific compiled query.</param>
		/// <param name="query">The IQueryable to invoke.</param>
		/// <returns></returns>
		public Func<TArg0, TArg1, TArg2, TResult> Get<TArg0, TArg1, TArg2, TResult>(string key, Expression<Func<TArg0, TArg1, TArg2, TResult>> query) where TArg0 : DataContext
		{
			return (Func<TArg0, TArg1, TArg2, TResult>)InternalGet(key, () => CompiledQuery.Compile(query));
		}
		/// <summary>
		/// Creates a statically compiled Linq query and returns the delegate to invoke.
		/// </summary>
		/// <typeparam name="TArg0">The DataContext to query.</typeparam>
		/// <typeparam name="TArg1">A parameter type to pass into the anonymous type for the IQueryable.</typeparam>
		/// <typeparam name="TArg2">A parameter type to pass into the anonymous type for the IQueryable.</typeparam>
		/// <typeparam name="TArg3">A parameter type to pass into the anonymous type for the IQueryable.</typeparam>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <param name="key">The key that identifies this specific compiled query.</param>
		/// <param name="query">The IQueryable to invoke.</param>
		/// <returns></returns>
		public Func<TArg0, TArg1, TArg2, TArg3, TResult> Get<TArg0, TArg1, TArg2, TArg3, TResult>(string key, Expression<Func<TArg0, TArg1, TArg2, TArg3, TResult>> query) where TArg0 : DataContext
		{
			return (Func<TArg0, TArg1, TArg2, TArg3, TResult>)InternalGet(key, () => CompiledQuery.Compile(query));
		}

		#region supporting method

		private Delegate InternalGet(string key, Func<Delegate> queryProvider)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			lock (_compiledQueries)
			{
				Delegate d;
				if (_compiledQueries.TryGetValue(key, out d))
					return d;
			    var result = queryProvider();
			    _compiledQueries.Add(key, result);
			    return result;
			}
		}

		#endregion

	}

}
