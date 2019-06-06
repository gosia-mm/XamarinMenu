using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinMenu.Models;

namespace XamarinMenu.Data
{
    public class FoodItemsDatabase
    {
        private readonly SQLiteAsyncConnection connection; // przechowywanie połączenia z bazą danych

        public FoodItemsDatabase(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath); // utworzenie połączenia do bazy
            connection.CreateTableAsync<FoodItem>().Wait(); // utworzenie tabelki z elementami menu w bazie jeśli nie istnieje
            connection.CreateTableAsync<Order>().Wait();
            connection.CreateTableAsync<OrderWithFoodItem>().Wait();
        }

        /* POZYCJE Z MENU - FOODITEMS */
        public Task<List<FoodItem>> getFoodItemsAsync() // zwrócenie zadania pobrania wszystkich elementów menu asynchronicznie
        {
            return connection.Table<FoodItem>().ToListAsync();
        }

        public Task<int> addOrUpdateFoodItemAsync(FoodItem item)
        {
            if (item.FoodItemID == 0)
                return connection.InsertAsync(item);
            else
                return connection.UpdateAsync(item);
        }

        public Task<int> deleteFoodItemAsync(FoodItem item)
        {
            return connection.DeleteAsync(item);
        }



        /* ZAMÓWIENIA - ORDERS */
        public Task<List<Order>> getOrdersAsync() // zwrócenie zadania pobrania wszystkich zamówień asynchronicznie
        {
            return connection.Table<Order>().ToListAsync();
        }

        public Task<int> addOrUpdateOrderAsync(Order order)
        {
            if (order.OrderID == 0)
                return connection.InsertAsync(order);
            else
                return connection.UpdateAsync(order);
        }

        public Task<int> deleteOrderAsync(Order order)
        {
            return connection.DeleteAsync(order);
        }

    }
}
