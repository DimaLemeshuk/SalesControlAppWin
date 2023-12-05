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

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Sale, SaleDTO>())
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
            var all = salesRepository.GetAll();
            var filtered = all.Select(sale => mapper.Map<Sale, SaleDTO>(sale))
                .Where(predicate);
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