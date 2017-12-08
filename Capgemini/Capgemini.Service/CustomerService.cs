//-----------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Capgemini.Domain;
using Capgemini.Domain.Repository;
using Capgemini.Repository;
using Capgemini.Service.ContractType;
using Capgemini.Service.Mapper;
using Capgemini.Service.Message;

namespace Capgemini.Service
{
    public class CustomerService : ICustomerService
    {
        #region Private Fields

        private ICustomerRepository customerRepository;

        #endregion // Private Fields

        #region Constructors

        public CustomerService()
        {
            this.customerRepository = new CustomerRepository();
            AutoMapper.Mapper.Initialize(x => x.AddProfile<CapgeminiProfile>());
        }

        public CustomerService(ICustomerRepository repository)
        {
            this.customerRepository = repository;
        }

        #endregion // Constructors

        #region Public Methods

        /// <summary>
        /// Adds the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        public AddCustomerResponse AddCustomer(AddCustomerRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var customerToAdd = AutoMapper.Mapper.Map<Customer>(request.CustomerDto);
            var addedCustomer = this.customerRepository.Add(customerToAdd);

            return new AddCustomerResponse() {CustomerDto = AutoMapper.Mapper.Map<CustomerDto>(addedCustomer)};
        }

        /// <summary>
        /// Update the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        public UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var customer = AutoMapper.Mapper.Map<Customer>(request.CustomerDto);
            this.customerRepository.Update(customer);

            return new UpdateCustomerResponse() {IsUpdated = true};
        }

        /// <summary>
        /// Remove the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        public RemoveCustomerResponse RemoveCustomer(RemoveCustomerRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var customer = AutoMapper.Mapper.Map<Customer>(request.CustomerDto);
            this.customerRepository.Delete(customer);

            return new RemoveCustomerResponse() {IsRemoved = true};
        }

        /// <summary>
        /// Gets the all customers
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        public GetAllCustomersResponse GetAllCustomers(GetAllCustomersRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var customers = this.customerRepository.GetAll();
            
            return new GetAllCustomersResponse()
            {
                Customers = AutoMapper.Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers)
            };
        }

        /// <summary>
        /// Gets the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var customer = this.customerRepository.GetById(request.CustomerId);

            return new GetCustomerResponse()
            {
                CustomerDto = AutoMapper.Mapper.Map<Customer, CustomerDto>(customer)
            };
        }

        #endregion // Public Methods
    }
}
