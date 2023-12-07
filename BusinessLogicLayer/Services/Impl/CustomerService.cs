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
    internal class CustomerService : ICustomerService
    {
        private readonly CustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(CustomerRepository customerRepository)
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException(nameof(customerRepository));
            }
            this.customerRepository = customerRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });

            this.mapper = config.CreateMapper();
        }

        public CustomerService()
        {
            this.customerRepository = new CustomerRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });

            this.mapper = config.CreateMapper();
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customer = customerRepository.GetAll();

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            })
            .CreateMapper();

            var deliveryDtos = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(customer);

            return deliveryDtos;
        }

        public CustomerDTO Get(int id)
        {
            var customer = customerRepository.Get(id);
            var customerDto = mapper.Map<Customer, CustomerDTO>(customer);
            return customerDto;
        }

        public IEnumerable<CustomerDTO> Find(Func<CustomerDTO, bool> predicate)
        {
            var allDeliveries = customerRepository.GetAll();
            var filteredDeliveries = allDeliveries.Select(customer => mapper.Map<Customer, CustomerDTO>(customer))
                                                 .Where(predicate);
            return filteredDeliveries;
        }

        public void Create(CustomerDTO item)
        {
            var customer = mapper.Map<CustomerDTO, Customer>(item);
            customerRepository.Create(customer);
        }

        public void Update(CustomerDTO item)
        {
            var customer = mapper.Map<CustomerDTO, Customer>(item);
            customerRepository.Update(customer);
        }

        public void Update(CustomerDTO item, string propertyName, object editedValue)
        {
            var customer = mapper.Map<CustomerDTO, Customer>(item);
            customerRepository.Update(customer, propertyName, editedValue);
        }

        public void Delete(int id)
        {
            customerRepository.Delete(id);
        }

        public void SaveChanges()
        {
            customerRepository.SaveChanges();
        }
    }
}