using System.Linq.Expressions;

namespace Finance.Expensia.Shared.Helpers
{
    public static class FilterHelper
    {
        /// <summary>
        /// Where contains nullable enum for query data
        /// </summary>
        public static Expression<Func<TEntity, bool>> ContainsNullableEnum<TEntity, TNullableEnum>(
            IEnumerable<TNullableEnum> values,
            Func<TNullableEnum, Expression<Func<TEntity, bool>>> filterCreator)
        {
            Expression<Func<TEntity, bool>> combinedFilter = null!;

            foreach (var value in values)
            {
                var filter = filterCreator(value);

                if (combinedFilter == null)
                {
                    combinedFilter = filter;
                }
                else
                {
                    var parameter = Expression.Parameter(typeof(TEntity));
                    var body = Expression.OrElse(Expression.Invoke(combinedFilter, parameter), Expression.Invoke(filter, parameter));
                    combinedFilter = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
                }
            }

            return combinedFilter;
        }
    }
}
