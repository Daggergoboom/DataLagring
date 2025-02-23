using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class CustomerFactory
    {
        // Convert from CustomerRegistration form to CustomerEntity for database saving
        public static CustomerEntity? Create(CustomerRegistration form) => form == null ? null : new()
        {
            CustomerName = form.CustomerName
        };

        // Convert from CustomerEntity to Customer for business logic and display
        public static Customer? Create(CustomerEntity entity) => entity == null ? null : new()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName
        };

        // Convert from Customer back to CustomerEntity for updating database records
        public static CustomerEntity? Create(Customer customer) => customer == null ? null : new()
        {
            Id = customer.Id,
            CustomerName = customer.CustomerName
        };
    }
}