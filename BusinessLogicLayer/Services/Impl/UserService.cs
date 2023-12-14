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
    public class UserService : IUserService
    {
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;
        private static UserDTO CurrentUser = null;

        public UserService(UserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }
            this.userRepository = userRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });

            this.mapper = config.CreateMapper();
        }

        public UserService()
        {
            this.userRepository = new UserRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var user = userRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<User, UserDTO>())
                    .CreateMapper();

            var Dtos = mapper.Map<IEnumerable<User>, List<UserDTO>>(user);

            return Dtos;
        }

        public UserDTO Get(int id)
        {
            var delivery = userRepository.Get(id);
            var deliveryDto = mapper.Map<User, UserDTO>(delivery);
            return deliveryDto;
        }

        public IEnumerable<UserDTO> Find(Func<UserDTO, bool> predicate)
        {
            var all = userRepository.GetAll();
            var filtere = all.Select(product => mapper.Map<User, UserDTO>(product))
                .Where(predicate);
            return filtere;
        }

        public void Create(UserDTO item)
        {
            var delivery = mapper.Map<UserDTO, User>(item);
            userRepository.Create(delivery);
        }

        public void Update(UserDTO item)
        {
            var delivery = mapper.Map<UserDTO, User>(item);
            userRepository.Update(delivery);
        }

        public bool Update(UserDTO item, string propertyName, object editedValue)
        {
            var supplier = mapper.Map<UserDTO, User>(item);
            return userRepository.Update(supplier, propertyName, editedValue);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public void SaveChanges()
        {
            userRepository.SaveChanges();
        }

        public void login( UserDTO user)
        {
            CurrentUser = user;
        }

        public UserDTO GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}
