using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace XamarinMenu.Services
{
    public class MenuRestService
    {
        public HttpClient Client { get; set; }

        public MenuRestService()
        {
            Client = new HttpClient(); // klient REST
        }
    }
}
