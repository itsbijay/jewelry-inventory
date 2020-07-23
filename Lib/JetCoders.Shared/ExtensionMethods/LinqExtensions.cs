using System;
using System.Collections.Generic;
using System.Linq;

namespace JetCoders.Shared
{
	public static class LinqExtensions
	{
		#region Shuffle

		private static readonly Random Random = new Random();

		/// <summary>
		/// Randomizes the IEnumberable collection. Note: Calls ToArray() on the source.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			var array = source.ToArray();
			return ShuffleInternal(array, array.Length);
		}

		#endregion

		#region TakeRandom

		/// <summary>
		/// Randomizes the IEnumerable collection and takes a random T item from it. Note: Calls ToArray() on the source.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
		{
			var array = source.ToArray();
			return ShuffleInternal(array, Math.Min(count, array.Length)).Take(count);
		}

	    /// <summary>
	    /// Randomizes the IEnumerable collection and takes a random T item from it. Note: Calls ToArray() on the source.
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <param name="source"></param>
	    /// <returns></returns>
	    public static T TakeRandom<T>(this IEnumerable<T> source)
		{
			return TakeRandom(source, 1).FirstOrDefault();
		}

		#endregion

		#region ShuffleInternal

		private static IEnumerable<T> ShuffleInternal<T>(T[] array, int count)
		{
			// Durstenfeld implementation of the Fisher-Yates algorithm for an O(n) unbiased shuffle
			// starts from the beginning rather than the end so we can just shuffle the first count
			for (var n = 0; n < count; n++)
			{
				var k = Random.Next(n, array.Length);
				var temp = array[n];
				array[n] = array[k];
				array[k] = temp;
			}

			return array;
		}

		#endregion

	}
}
