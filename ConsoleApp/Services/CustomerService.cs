using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AdressService _AdressService;
        private readonly RoleService _roleService;

        public CustomerService(CustomerRepository customerRepository, AdressService adressService, RoleService roleService)
        {
            _customerRepository = customerRepository;
            _AdressService = adressService;
            _roleService = roleService;
        }

        public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
        {
            var roleEntiry = _roleService.CreateRole(roleName);
            var adressEntity = _AdressService.CreateAdress(streetName, postalCode, city);

            var customerEntity = new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleEntiry.Id,
                AdressId = adressEntity.Id
            };

            customerEntity = _customerRepository.Create(customerEntity);

            return customerEntity;
        }

        public CustomerEntity GetCustomerByEmail(string email)
        {
            var customerEntity = _customerRepository.Get(x => x.Email == email);
            return customerEntity;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public CustomerEntity updateCustomer(CustomerEntity customerEntity)
        {
            var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
            return updatedCustomerEntity;
        }

        public void DeleteCustomert(int id)
        {
            _customerRepository.Delete(x => x.Id == id);
        }
    }
}
