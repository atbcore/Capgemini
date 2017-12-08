//-----------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="TB Enterprises">
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
using Capgemini.Service.Message;

namespace Capgemini.Service
{
    [ServiceContract(Name = "CustomerService", Namespace="www.capgemini.pl")]
    public interface ICustomerService
    {
        /// <summary>
        /// Adds the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        [OperationContract]
        AddCustomerResponse AddCustomer(AddCustomerRequest request);

        /// <summary>
        /// Update the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        [OperationContract]
        UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request);

        /// <summary>
        /// Remove the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        [OperationContract]
        RemoveCustomerResponse RemoveCustomer(RemoveCustomerRequest request);

        /// <summary>
        /// Gets the all customers
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        [OperationContract]
        GetAllCustomersResponse GetAllCustomers(GetAllCustomersRequest request);

        /// <summary>
        /// Gets the customer
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Response object</returns>
        [OperationContract]
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
    }
}
