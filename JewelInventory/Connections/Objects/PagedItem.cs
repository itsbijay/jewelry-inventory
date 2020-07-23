using System;
using System.Linq;

namespace Connections
{
    public class PagedItem<TEntity>
    {
        public TEntity Entity { get; private set; }

        public PagedItem(IQueryable<TEntity> query, Int32 pageIndex)
        {
            Position = pageIndex > 0 ? pageIndex : 1;
            TotalRecords = query.Count();
            
            //Entity = query.Skip((Position - 1))
            //                .FirstOrDefault();
        }

        #region properties
        /// <summary>
        /// Gets the index for the current paged list.
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// Gets the total records that could have been returned.
        /// </summary>
        public int TotalRecords { get; private set; }
        #endregion

        public bool HasPreviousRecord
        {
            get
            {
                return (Position > 1);
            }
        }

        public bool HasNextRecord
        {
            get
            {
                return (TotalRecords > Position);
            }
        }
    }
}
