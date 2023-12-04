using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Impl;

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
                cfg.CreateMap<Groupproduct, GroupproductDTO>();
                cfg.CreateMap<GroupproductDTO, Groupproduct>();
            });

            this.mapper = config.CreateMapper();
        }

        public DeliveryService()
        {
            this.deliveryRepository = new DeliveryRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Groupproduct, GroupproductDTO>();
                cfg.CreateMap<GroupproductDTO, Groupproduct>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<GroupproductDTO> GetAll()
        {
            var deliveries = deliveryRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Groupproduct, GroupproductDTO>())
                    .CreateMapper();

            var deliveryDtos = mapper.Map<IEnumerable<Groupproduct>, List<GroupproductDTO>>(deliveries);

            return deliveryDtos;
        }

        public GroupproductDTO Get(int id)
        {
            var delivery = deliveryRepository.Get(id);
            var deliveryDto = mapper.Map<Groupproduct, GroupproductDTO>(delivery);
            return deliveryDto;
        }

        public IEnumerable<GroupproductDTO> Find(Func<GroupproductDTO, bool> predicate)
        {
            var allDeliveries = deliveryRepository.GetAll();
            var filteredDeliveries = allDeliveries.Select(delivery => mapper.Map<Groupproduct, GroupproductDTO>(delivery))
                                                 .Where(predicate);
            return filteredDeliveries;
        }

        public void Create(GroupproductDTO item)
        {
            var delivery = mapper.Map<GroupproductDTO, Groupproduct>(item);
            deliveryRepository.Create(delivery);
        }

        public void Update(GroupproductDTO item)
        {
            var delivery = mapper.Map<GroupproductDTO, Groupproduct>(item);
            deliveryRepository.Update(delivery);
        }

        public void Delete(int id)
        {
            deliveryRepository.Delete(id);
        }

        public void SaveChanges()
        {
            deliveryRepository.SaveChanges();
        }
    }
}
