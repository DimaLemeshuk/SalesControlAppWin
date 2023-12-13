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
            var deliv = deliveryRepository.GetAll();

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Delivery, DeliveryDTO>()
                .ForMember(dest => dest.ProductDTO, opt => opt.MapFrom(src => (new ProductService()).Get(src.ProductId)));
            })
            .CreateMapper();

            var deliveryDtos = mapper.Map<IEnumerable<Delivery>, List<DeliveryDTO>>(deliv);

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
            //var allDeliveries = deliveryRepository.GetAll();
            //var filteredDeliveries = allDeliveries.Select(delivery => mapper.Map<Delivery, DeliveryDTO>(delivery))
            //                                     .Where(predicate);
            //return filteredDeliveries;
            var allDeliveries = deliveryRepository.GetAll();
            var filteredDeliveries = allDeliveries.Select(delivery => mapper.Map<Delivery, DeliveryDTO>(delivery));

            // Додайте логіку для маппінгу ProductDTO
            foreach (var deliveryDTO in filteredDeliveries)
            {
                deliveryDTO.ProductDTO = (new ProductService()).Get(deliveryDTO.ProductId);
            }

            // Застосуйте фільтр
            var result = filteredDeliveries.Where(predicate);

            return result;
        
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

        public bool Update(DeliveryDTO item, string propertyName, object editedValue)
        {
            var supplier = mapper.Map<DeliveryDTO, Delivery>(item);
            return deliveryRepository.Update(supplier, propertyName, editedValue);
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
