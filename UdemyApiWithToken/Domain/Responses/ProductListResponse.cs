using System.Collections.Generic;

namespace UdemyApiWithToken.Domain.Responses
{
    public class ProductListResponse : BaseResponse
    {
        public IEnumerable<Product> productList { get; set; }

        public ProductListResponse(bool success, string message, IEnumerable<Product> productList) : base(success, message)
        {
            this.productList = productList;
        }

        public ProductListResponse(IEnumerable<Product> productList) : this(true, string.Empty, productList)
        {
        }

        public ProductListResponse(string message) : this(false, message, null)
        {
        }
    }
}