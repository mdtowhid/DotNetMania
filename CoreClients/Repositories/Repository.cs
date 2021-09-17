using Dapper;
using DBConnection;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repositories
{
    public class Repository<T>  : IRepository<T> where T : class
    {   
        private readonly string connectionString = @"data source=desktop-8kas1u3;initial catalog=DotNetMania;persist security info=True;Integrated Security=true;";
        private List<T> entities;
        private T entity;

        public IEnumerable<T> GetAll(string query)
        {
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                dbConnection.Open();
                entities = dbConnection.Query<T>(query).AsList();
                dbConnection.Close();
            }
            return entities;
        }

        public T GetById(string query, int id)
        {
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                dbConnection.Open();
                entity = dbConnection.Query<T>(query, new { Id = id }).FirstOrDefault();
                dbConnection.Close();
            }
            return entity;
        }

        public T RemoveById(string query, int id)
        {
            entity = GetById(query, id);
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Query(query, new { Id = id }).FirstOrDefault();
                dbConnection.Close();
            }
            return entity;
        }

        public dynamic Save(string query, T entity)
        {
            dynamic status;
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                dbConnection.Open();
                status = dbConnection.QueryFirstOrDefault<int>(query, entity);
                dbConnection.Close();
            }
            return status;
        }

        public T Update(string query, T model)
        {
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                dbConnection.Open();
                entity = dbConnection.Query<T>(query, model).FirstOrDefault();
                dbConnection.Close();
            }
            return entity;
        }
    }
}
