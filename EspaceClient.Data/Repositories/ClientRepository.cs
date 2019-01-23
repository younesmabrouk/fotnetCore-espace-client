using EspaceClient.Data.Context;
using EspaceClient.Entities;
using EspaceClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EspaceClient.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly EspaceClientContext appContext;

        public ClientRepository(EspaceClientContext appContext)
        {
            this.appContext = appContext;
        }

        public List<Client> GetAll()
        {
            return appContext.Clients.ToList();
        }

        public List<ClientVMs> GetByName(string name)
        {

            var clients = appContext.ClientVMs.FromSql(
                    @"select c.Name, c.Adress AS AdressName
                    from  Clients  c 
                    ").ToList();
            return clients;
        }

        public Client GetById(int id)
        {
            return appContext.Clients.Find(id);
        }

        public int Insert(Client client)
        {
            appContext.Clients.Add(client);
            appContext.SaveChanges();
            return client.Id;
        }

        public int Update(Client client)
        {
            appContext.Clients.Attach(client);
            appContext.Entry(client).Property("Adress").IsModified = true;
            int rows = appContext.SaveChanges();
            return rows;
        }

        public int Delete(int id)
        {
            var client = new Client();
            client.Id = id;
            appContext.Clients.Attach(client);
            appContext.Clients.Remove(client);
            int rows = appContext.SaveChanges();
            return rows;
        }
    }
    public interface IClientRepository
    {
        List<Client> GetAll();
        List<ClientVMs> GetByName(string name);
        Client GetById(int id);
        int Insert(Client client);
        int Update(Client client);
        int Delete(int id);
    }
}
