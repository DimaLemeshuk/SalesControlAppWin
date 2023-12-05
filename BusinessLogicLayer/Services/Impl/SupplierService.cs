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
    public class SupplierService : ISupplierService
    {
        private readonly SupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(SupplierRepository supplierRepository)
        {
            if (supplierRepository == null)
            {
                throw new ArgumentNullException(nameof(supplierRepository));
            }
            this.supplierRepository = supplierRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>();
                cfg.CreateMap<SupplierDTO, Supplier>();
            });

            this.mapper = config.CreateMapper();
        }

        public SupplierService()
        {
            this.supplierRepository = new SupplierRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>();
                cfg.CreateMap<SupplierDTO, Supplier>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            var supplier = supplierRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Supplier, SupplierDTO>())
                    .CreateMapper();

            var Dtos = mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(supplier);

            return Dtos;
        }

        public SupplierDTO Get(int id)
        {
            var store = supplierRepository.Get(id);
            var Dto = mapper.Map<Supplier, SupplierDTO>(store);
            return Dto;
        }

        public IEnumerable<SupplierDTO> Find(Func<SupplierDTO, bool> predicate)
        {
            var all = supplierRepository.GetAll();
            var filtered = all.Select(store => mapper.Map<Supplier, SupplierDTO>(store))
                .Where(predicate);
            return filtered;
        }

        public void Create(SupplierDTO item)
        {
            var store = mapper.Map<SupplierDTO, Supplier>(item);
            supplierRepository.Create(store);
        }

        public void Update(SupplierDTO item)
        {
            var store = mapper.Map<SupplierDTO, Supplier>(item);
            supplierRepository.Update(store);
        }

        public void Delete(int id)
        {
            supplierRepository.Delete(id);
        }

        public void SaveChanges()
        {
            supplierRepository.SaveChanges();
        }
    }
}
