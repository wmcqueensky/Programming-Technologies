using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Events
    {

        void sellProducts(Product[] products)
        {
            // Check if products are available in the catalog
            foreach (var product in products)
            {
                if (!State.CurrentCatalog.Contains(product))
                {
                    throw new InvalidOperationException($"Product '{product.Name}' is not available in the catalog.");
                }
            }

            // Calculate total price of sold products
            float totalPrice = 0;
            foreach (var product in products)
            {
                totalPrice += product.GetPrice();
            }

            // Deduct sold products from inventory or update sales records
            // For simplicity, let's assume we are deducting from inventory directly
            foreach (var product in products)
            {
                State.CurrentCatalog.Remove(product);
            }

            // Update current balance
            State.CurrentBalance += totalPrice;
        }

        void takeDelivery(Product[] products)
        {
            foreach (var product in products)
            {
                State.CurrentCatalog.Add(product);
            }
        }

        void payEmployee(Employee employee)
        {
            if (!State.CurrentUsers.Contains(employee))
            {
                throw new InvalidOperationException($"Employee '{employee.GetName()}' is not found in current users.");
            }

            // Deduct employee's salary from current balance
            State.CurrentBalance -= employee.GetSalary();
        }

        void payTaxes(float taxAmount)
        {
            State.CurrentBalance -= taxAmount;
        }

    }
}
