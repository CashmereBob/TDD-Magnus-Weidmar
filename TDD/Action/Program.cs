using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order()
            {
                Name = "Widget A",
                Price = 3.14m,
                Quantity = 100,
                Paid = false
            };

            List<Action<Order>> actions = new List<Action<Order>>();

            actions.Add((Order inp) => inp.Name += " -in Stock");
            actions.Add(new Action<Order>((Order inp) => {
                inp.Price = decimal.Multiply(inp.Price, 1.25m);
            }));
            actions.Add(new Action<Order>((Order inp) => {
                inp.Quantity -= 10;
                inp.Name += " -Paid";
                inp.Paid = true;
            }));

            ProcesOrder(order, actions);
            Console.ReadLine();  
        }

        public static void ProcesOrder(Order order, List<Action<Order>> list)
        {
            list.ForEach(o => o(order));

            Console.WriteLine(order.Name);
            Console.WriteLine(order.Price);
            Console.WriteLine(order.Quantity);
        }


    }
    
}
