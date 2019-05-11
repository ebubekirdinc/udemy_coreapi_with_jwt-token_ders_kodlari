using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyApiWithToken.Domain;
using UdemyApiWithToken.Domain.Repositories;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await productRepository.AddProductAsync(product);

                await unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün eklenirken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<ProductResponse> FindByIdAsync(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);

                if (product == null)
                {
                    return new ProductResponse("ürün bulunamamıştır.");
                }

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün bulunurken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();
                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {
                return new ProductListResponse($"ürün listelenirken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);

                if (product == null)
                {
                    return new ProductResponse("silmeye çalıştığınız ürün bulunamamıştır.");
                }
                else
                {
                    await productRepository.RemoveProductAsync(productId);

                    await unitOfWork.CompleteAsync();

                    return new ProductResponse(product);
                }
            }
            catch (Exception ex)
            {
                return new ProductResponse($"ürün silinmeye çalışılırken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateProduct(Product product, int productId)
        {
            try
            {
                var firstProduct = await productRepository.FindByIdAsync(productId);

                if (firstProduct == null)
                {
                    return new ProductResponse("güncellemeye çalıştığınız ürün bulunamadı.");
                }
                firstProduct.Name = product.Name;
                firstProduct.Category = product.Category;
                firstProduct.Price = product.Price;

                productRepository.UpdateProduct(firstProduct);

                await unitOfWork.CompleteAsync();

                return new ProductResponse(firstProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"ürün güncellenirken bir hata meydana geldi::{ex.Message}");
            }
        }
    }
}