using Microsoft.EntityFrameworkCore;

namespace DesafioPratico.AutoGlass.Domain.Paginacao.Helper
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>
            (IQueryable<T> query, PagedBaseRequest request)
            where TResponse : PagedBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Abs((double)count / request.PageSize);

            response.TotalRegisters = count;

            if(string.IsNullOrEmpty(request.OrderProperty))
                response.Data = await query.ToListAsync();
            else
                response.Data = query.OrderByDynamic(request.OrderProperty)
                                .Skip((request.Page -1) * request.PageSize).Take(request.PageSize)
                                .ToList();
            return response;
        }

        private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }
}
