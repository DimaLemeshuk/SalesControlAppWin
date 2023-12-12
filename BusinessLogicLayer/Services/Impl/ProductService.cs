using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                cfg.CreateMap<Supplier, SupplierDTO>();
                cfg.CreateMap<Groupproduct, GroupproductDTO>();
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
                cfg.CreateMap<Supplier, SupplierDTO>();
                cfg.CreateMap<Groupproduct, GroupproductDTO>();
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

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NameProducts, opt => opt.MapFrom(src => src.NameProducts))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.SupplierDTO, opt => opt.MapFrom(src => (new SupplierService()).Get(src.SuplierId)))
                .ForMember(dest => dest.GroupproductDTO, opt => opt.MapFrom(src => (new GroupproductService()).Get(src.GroupProductsId)));
            })
            .CreateMapper();

            var productDtos = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
            //var productDtos = mapper.Map<IEnumerable<Product>>(products).Cast<ProductDTO>();

            return productDtos;

        }

        public void Update(ProductDTO item)
        {
            var products = mapper.Map<ProductDTO, Product>(item);
            productRepository.Update(products);
        }

        public bool Update(ProductDTO item, string propertyName, object editedValue)
        {
            var products = mapper.Map<ProductDTO, Product>(item);
            return productRepository.Update(products, propertyName, editedValue);
        }

        public void SaveChanges()
        {
            productRepository.SaveChanges();
        }

    }
}
