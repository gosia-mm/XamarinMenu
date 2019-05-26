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
            connection.CreateTableAsync<MenuItem>().Wait(); // utworzenie tabelki w bazie jeśli nie istnieje
        }

        public Task<List<MenuItem>> getMenuItemsAsync() // zwrócenie zadania - asynchronicznie
        {
            return connection.Table<MenuItem>().ToListAsync(); // zwrócenie zadania zwracającego listę ToDo
        }

        public Task<int> addOrUpdateMenuItemAsync(MenuItem item)
        {
            if (item.ID == 0)
                return connection.InsertAsync(item);
            else
                return connection.UpdateAsync(item);
        }

        public Task<int> deleteMenuItemAsync(MenuItem item)
        {
            return connection.DeleteAsync(item);
        }
    }
}
