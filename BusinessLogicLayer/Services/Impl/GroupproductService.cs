using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Impl;

namespace BusinessLogicLayer.Services.Impl
{
    public class GroupproductService : IGroupproductService
    {

        private readonly GroupproductRepository groupproductRepository;
        private readonly IMapper mapper;

        public GroupproductService(GroupproductRepository groupproductRepository)
        {
            if (groupproductRepository == null)
            {
                throw new ArgumentNullException(nameof(groupproductRepository));
            }
            this.groupproductRepository = groupproductRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Groupproduct, GroupproductDTO>();
                cfg.CreateMap<GroupproductDTO, Groupproduct>();
            });

            this.mapper = config.CreateMapper();
        }

        public GroupproductService()
        {
            this.groupproductRepository = new GroupproductRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Groupproduct, GroupproductDTO>();
                cfg.CreateMap<GroupproductDTO, Groupproduct>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<GroupproductDTO> GetAll()
        {
            var groupproduct = groupproductRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<Groupproduct, GroupproductDTO>())
                    .CreateMapper();

            var Dtos = mapper.Map<IEnumerable<Groupproduct>, List<GroupproductDTO>>(groupproduct);

            return Dtos;
        }

        public GroupproductDTO Get(int id)
        {
            var groupproduct = groupproductRepository.Get(id);
            var Dto = mapper.Map<Groupproduct, GroupproductDTO>(groupproduct);
            return Dto;
        }

        public IEnumerable<GroupproductDTO> Find(Func<GroupproductDTO, bool> predicate)
        {
            var all = groupproductRepository.GetAll();
            var filtered = all.Select(groupproduct => mapper.Map<Groupproduct, GroupproductDTO>(groupproduct))
                .Where(predicate);
            return filtered;
        }

        public void Create(GroupproductDTO item)
        {
            var groupproduct = mapper.Map<GroupproductDTO, Groupproduct>(item);
            groupproductRepository.Create(groupproduct);
        }

        public void Update(GroupproductDTO item)
        {
            var groupproduct = mapper.Map<GroupproductDTO, Groupproduct>(item);
            groupproductRepository.Update(groupproduct);
        }

        public void Delete(int id)
        {
            groupproductRepository.Delete(id);
        }

        public void SaveChanges()
        {
            groupproductRepository.SaveChanges();
        }
    }
}