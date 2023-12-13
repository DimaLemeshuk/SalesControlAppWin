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
    public class SaleService : ISaleService
    {

        private readonly SalesRepository salesRepository;
        private readonly IMapper mapper;

        public SaleService(SalesRepository salesRepository)
        {
            if (salesRepository == null)
            {
                throw new ArgumentNullException(nameof(salesRepository));
            }
            this.salesRepository = salesRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sale, SaleDTO>();
                cfg.CreateMap<SaleDTO, Sale>();
                cfg.CreateMap<Store, StoreDTO>();
                cfg.CreateMap<Product, ProductDTO>();
            });

            this.mapper = config.CreateMapper();
        }

        public SaleService()
        {
            this.salesRepository = new SalesRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sale, SaleDTO>();
                cfg.CreateMap<SaleDTO, Sale>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            var sale = salesRepository.GetAll();

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sale, SaleDTO>()
                .ForMember(dest => dest.ProductDTO, opt => opt.MapFrom(src => (new ProductService()).Get(src.ProductId)))
                .ForMember(dest => dest.StoreDTO, opt => opt.MapFrom(src => (new StoreService()).Get(src.StoreId)))
                .ForMember(dest => dest.CustomersDTO, opt => opt.MapFrom(src => (new CustomerService()).Get(src.CustomersId)));
            })
            .CreateMapper();

            var Dtos = mapper.Map<IEnumerable<Sale>, List<SaleDTO>>(sale);

            return Dtos;
        }

        public SaleDTO Get(int id)
        {
            Sale sale = salesRepository.Get(id);
            var Dto = mapper.Map<Sale, SaleDTO>(sale);
            return Dto;
        }

        public IEnumerable<SaleDTO> Find(Func<SaleDTO, bool> predicate)
        {
            //var all = salesRepository.GetAll();
            //var filtered = all.Select(sale => mapper.Map<Sale, SaleDTO>(sale))

            //    .Where(predicate);
            //return filtered;
            var all = salesRepository.GetAll();

            var productService = new ProductService();
            var storeService = new StoreService();
            var customerService = new CustomerService();

            var filtered = all.Select(sale =>
            {
                var saleDTO = mapper.Map<Sale, SaleDTO>(sale);
                saleDTO.ProductDTO = productService.Get(sale.ProductId);
                saleDTO.StoreDTO = storeService.Get(sale.StoreId);
                saleDTO.CustomersDTO = customerService.Get(sale.CustomersId);
                return saleDTO;
            }).Where(predicate);

            return filtered;
        }

        public void Create(SaleDTO item)
        {
            var sale = mapper.Map<SaleDTO, Sale>(item);
            salesRepository.Create(sale);
        }

        public void Update(SaleDTO item)
        {
            var sale = mapper.Map<SaleDTO, Sale>(item);
            salesRepository.Update(sale);
        }

        public bool Update(SaleDTO item, string propertyName, object editedValue)
        {
            var sale = mapper.Map<SaleDTO, Sale>(item);
            return salesRepository.Update(sale, propertyName, editedValue);
        }

        public void Delete(int id)
        {
            salesRepository.Delete(id);
        }

        public void SaveChanges()
        {
            salesRepository.SaveChanges();
        }
    }
}