
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Company.ProductCatalog
{
    public class GetProductCatalog
    {
        private readonly ProductCatalogContext _dbContext;

         public GetProductCatalog(ProductCatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetProductCatalog")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing request for product catalog.");

            var products = await _dbContext.Products.ToListAsync();

            return new OkObjectResult(products);
        }
    }
}
