using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinMenu.Models;

namespace XamarinMenu.Data
{
    public class MenuItemsDatabase
    {
        private readonly SQLiteAsyncConnection connection; // przechowywanie połączenia z bazą danych

        public MenuItemsDatabase(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath); // utworzenie połączenia do bazy
            connection.CreateTableAsync<MenuItem>().Wait(); // utworzenie tabelki z elementami menu w bazie jeśli nie istnieje
            connection.CreateTableAsync<Order>().Wait(); 
            connection.CreateTableAsync<OrderWithFoodItem>().Wait();
        }

        /* POZYCJE Z MENU - MENUITEMS */
        public Task<List<MenuItem>> getMenuItemsAsync() // zwrócenie zadania pobrania wszystkich elementów menu asynchronicznie
        {
            return connection.Table<MenuItem>().ToListAsync(); 
        }

        public Task<int> addOrUpdateMenuItemAsync(MenuItem item)
        {
            if (item.MenuItemID == 0)
                return connection.InsertAsync(item);
            else
                return connection.UpdateAsync(item);
        }

        public Task<int> deleteMenuItemAsync(MenuItem item)
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
