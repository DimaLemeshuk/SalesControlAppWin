using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BusinessLogicLayer.Services.Impl
{
    public class DeliveryService : IDeliveryService
    {
        private readonly DeliveryRepository deliveryRepository;
        private readonly IMapper mapper;

        public DeliveryService(DeliveryRepository deliveryRepository)
        {
            if (deliveryRepository == null)
            {
                throw new ArgumentNullException(nameof(deliveryRepository));
            }
            this.deliveryRepository = deliveryRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Delivery, DeliveryDTO>();
                cfg.CreateMap<DeliveryDTO, Delivery>();
            });

            this.mapper = config.CreateMapper();
        }

        public DeliveryService()
        {
            this.deliveryRepository = new DeliveryRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Delivery, DeliveryDTO>();
                cfg.CreateMap<DeliveryDTO, Delivery>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<DeliveryDTO> GetAll()
        {
            var deliveries = deliveryRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Delivery, DeliveryDTO>())
                    .CreateMapper();

            var deliveryDtos = mapper.Map<IEnumerable<Delivery>, List<DeliveryDTO>>(deliveries);

            return deliveryDtos;
        }

        public DeliveryDTO Get(int id)
        {
            var delivery = deliveryRepository.Get(id);
            var deliveryDto = mapper.Map<Delivery, DeliveryDTO>(delivery);
            return deliveryDto;
        }

        public IEnumerable<DeliveryDTO> Find(Func<DeliveryDTO, bool> predicate)
        {
            var allDeliveries = deliveryRepository.GetAll();
            var filteredDeliveries = allDeliveries.Select(delivery => mapper.Map<Delivery, DeliveryDTO>(delivery))
                                                 .Where(predicate);
            return filteredDeliveries;
        }

        public void Create(DeliveryDTO item)
        {
            var delivery = mapper.Map<DeliveryDTO, Delivery>(item);
            deliveryRepository.Create(delivery);
        }

        public void Update(DeliveryDTO item)
        {
            var delivery = mapper.Map<DeliveryDTO, Delivery>(item);
            deliveryRepository.Update(delivery);
        }

        public void Delete(int id)
        {
            deliveryRepository.Delete(id);
        }

        public void SaveChange()
        {
            deliveryRepository.SaveChange();
        }
    }
}
