//-----------------------------------------------------------------------
// <copyright file="CustomerRepositoryTest.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using Capgemini.Domain;
using Capgemini.Domain.Repository;
using NUnit;
using NUnit.Framework;

namespace Capgemini.Repository.Test
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        #region Private Fields

        private ICustomerRepository customerRepository;

        #endregion // Private Fields

        [SetUp]
        public void SetUp()
        {
            this.customerRepository = new CustomerRepository();
        }

        [Test]
        [TestCase("Tomasz", "Bednarski", "608353707", "Polska")]
        [TestCase("Wieńczysław", "Nieszczególny", "600111222", "Polska")]
        [TestCase("Adam", "Mickiewicz", "555777555", "Polska")]
        [TestCase("Jimi", "Hendrix", "999888777", "UK")]
        public void AddCustomerTest(string name, string surname, string telephoneNumber, string address)
        {
            var customer = new Customer()
            {
                Name = name,
                Surname = surname,
                TelephoneNumber = telephoneNumber,
                Address = address
            };

            var newCustomer = this.customerRepository.Add(customer);

            Assert.NotZero(customer.Id, "Customer Id cannot be zero!");
        }

        [Test]
        [TestCase(3, "Wolfgang")]
        [TestCase(4, "Wolfgang")]
        public void UpdateCustomerTest(int id, string name)
        {
            var oldCustomer = this.customerRepository.GetById(id);
            Assert.NotNull(oldCustomer);

            oldCustomer.Name = name;
            this.customerRepository.Update(oldCustomer);
            var newCustomer = this.customerRepository.GetById(id);

            Assert.AreEqual(newCustomer.Name, "Wolfgang", "Id cannot be zero!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void DeleteCustomerTest(int id)
        {
            var customer = this.customerRepository.GetById(id);
            if (customer != null)
            {
                this.customerRepository.Delete(customer);
                var testCustomer = this.customerRepository.GetById(id);
                Assert.IsNull(testCustomer);
            }
        }
    }
}
