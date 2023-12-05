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
    public class StoreService : IStoreService
    {
        private readonly StoreRepository storeRepository;
        private readonly IMapper mapper;

        public StoreService(StoreRepository storeRepository)
        {
            if (storeRepository == null)
            {
                throw new ArgumentNullException(nameof(storeRepository));
            }
            this.storeRepository = storeRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Store, StoreDTO>();
                cfg.CreateMap<StoreDTO, Store>();
            });

            this.mapper = config.CreateMapper();
        }

        public StoreService()
        {
            this.storeRepository = new StoreRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Store, StoreDTO>();
                cfg.CreateMap<StoreDTO, Store>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<StoreDTO> GetAll()
        {
            var store = storeRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Store, StoreDTO>())
                    .CreateMapper();

            var Dtos = mapper.Map<IEnumerable<Store>, List<StoreDTO>>(store);

            return Dtos;
        }

        public StoreDTO Get(int id)
        {
            var store = storeRepository.Get(id);
            var Dto = mapper.Map<Store, StoreDTO>(store);
            return Dto;
        }

        public IEnumerable<StoreDTO> Find(Func<StoreDTO, bool> predicate)
        {
            var all = storeRepository.GetAll();
            var filtered = all.Select(store => mapper.Map<Store, StoreDTO>(store))
                .Where(predicate);
            return filtered;
        }

        public void Create(StoreDTO item)
        {
            var store = mapper.Map<StoreDTO, Store>(item);
            storeRepository.Create(store);
        }

        public void Update(StoreDTO item)
        {
            var store = mapper.Map<StoreDTO, Store>(item);
            storeRepository.Update(store);
        }

        public void Update(StoreDTO item, string propertyName, object editedValue)
        {
            var store = mapper.Map<StoreDTO, Store>(item);
            storeRepository.Update(store, propertyName, editedValue);
        }

        public void Delete(int id)
        {
            storeRepository.Delete(id);
        }

        public void SaveChanges()
        {
            storeRepository.SaveChanges();
        }
    }
}
