using System.Text.Json;
using API.RequestHelpers;

namespace API.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response, MetaData metaData)
    {
        var paginationHeader = new MetaData
        {
            CurrentPage = metaData.CurrentPage,
            TotalPages = metaData.TotalPages,
            PageSize = metaData.PageSize,
            TotalCount = metaData.TotalCount
        };
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        
        response.Headers.Add("Pagination",JsonSerializer.Serialize(paginationHeader, options));
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
    }
}