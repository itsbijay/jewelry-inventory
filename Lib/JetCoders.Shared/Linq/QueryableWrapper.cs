using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data.Linq;
using System.Linq.Expressions;

namespace JetCoders.Shared
{
	/// <summary>
	/// Represents an IQueryable that properly disposes of DataContext 
	/// for proper garbage collection.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class QueryableWrapper<T> : IDisposable, IQueryable<T> where T : class
	{
		private readonly IQueryable<T> _queryable;
		private readonly IDisposable _disposable;

	    /// <summary>
	    /// Creates a new instance of IQueryableWrapper.
	    /// </summary>
	    /// <param name="queryable">The IQueryable to encompass.</param>
	    /// <param name="disposable">Specify the params can be dsposed.</param>
	    public QueryableWrapper(IQueryable<T> queryable, IDisposable disposable)
		{
			_disposable = disposable;
			_queryable = queryable;
		}

		public DataContext DataContext()
		{
			return _disposable as DataContext;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _queryable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _queryable.GetEnumerator();
		}

		public Type ElementType
		{
			get { return _queryable.ElementType; }
		}

		public Expression Expression
		{
			get { return _queryable.Expression; }
		}

		public IQueryProvider Provider
		{
			get { return _queryable.Provider; }
		}

		#region IDisposable Members

		private bool _isDisposed;
		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (_isDisposed) return;

			_isDisposed = true;

			if (disposing)
			{
				_disposable.Dispose();
			}

			GC.SuppressFinalize(this);
		}

		~QueryableWrapper()
		{
			Dispose(false);
		}

		#endregion
	}
}
