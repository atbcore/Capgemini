//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Capgemini.Client.Annotations;
using Capgemini.Client.Models;

using Capgemini.Client.CustomerServiceReference;

namespace Capgemini.Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private CustomerModel selectedCustomer;

        private ChannelFactory<CustomerServiceChannel> customerChannelFactory;

        #endregion // Private Fields

        #region Constructors

        public MainViewModel()
        {
            BasicHttpBinding customerBasicBinding = new BasicHttpBinding("BasicHttpBinding_CustomerService");
            EndpointAddress customerEndpointAddress = new EndpointAddress("http://localhost:4321/Capgemini/CustomerService");
            this.customerChannelFactory = new ChannelFactory<CustomerServiceChannel>(customerBasicBinding, customerEndpointAddress);

            var customerChannel = this.customerChannelFactory.CreateChannel();
            customerChannel.Open();
            var response = customerChannel.GetCustomer(new GetCustomerRequest() {CustomerId = 4});
            customerChannel.Close();
        }

        #endregion // Constructors

        #region Public Properties

        /// <summary>
        /// Gets customer data
        /// </summary>
        public ObservableCollection<CustomerModel> Customers { get; private set; }

        /// <summary>
        /// Gets selected customer
        /// </summary>
        public CustomerModel SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }

            set
            {
                this.selectedCustomer = value;
                this.OnPropertyChanged("SelectedCustomer");
            }
        }

        /// <summary>
        /// Gets generate data command for ViewModel
        /// </summary>
        public ICommand GenerateCustomerDataCommand { get; private set; }

        /// <summary>
        /// Gets command for update customer city card for ViewModel
        /// </summary>
        public ICommand UpdateCustomerCityCardCommand { get; private set; }

        /// <summary>
        /// Gets value indicating wheather customer data can be generated
        /// </summary>
        public bool CanGenerateCustomerData
        {
            get { return this.SelectedCustomer != null ? true : false; }
        }

        /// <summary>
        /// Gets value indicating wheather customer city card data could be updated
        /// </summary>
        public bool CanUpdateCustomerCityCard
        {
            get { return this.SelectedCustomer != null ? true : false; }
        }

        #endregion // Public Properties

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
