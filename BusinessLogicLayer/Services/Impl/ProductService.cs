using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(ProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }
            this.productRepository = productRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });

            this.mapper = config.CreateMapper();
        }

        public ProductService()
        {

            this.productRepository = new ProductRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });

            this.mapper = config.CreateMapper();
        }

        public void Create(ProductDTO item)
        {
            var product = mapper.Map<ProductDTO, Product>(item);
            productRepository.Create(product);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public IEnumerable<ProductDTO> Find(Func<ProductDTO, bool> predicate)
        {
            var all = productRepository.GetAll();
            var filtere = all.Select(product => mapper.Map<Product, ProductDTO>(product))
                .Where(predicate);
            return filtere;
        }

        public ProductDTO Get(int id)
        {
            var product = productRepository.Get(id);
            var Dto = mapper.Map<Product, ProductDTO>(product);
            return Dto;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = productRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Product, ProductDTO>())
                    .CreateMapper();

            var productDtos = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);

            return productDtos;
        }

        public void Update(ProductDTO item)
        {
            var products = mapper.Map<ProductDTO, Product>(item);
            productRepository.Update(products);
        }

        public void SaveChange()
        {
            productRepository.SaveChange();
        }

        //public static void PrintToDataGrid(DataGrid dataGrid)
        //{ }

    }
}
