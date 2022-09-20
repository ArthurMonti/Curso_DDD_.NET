using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {

        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar os Migrations
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=br894005";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
            return new MyContext(optionsBuilder.Options);

        }
    }
}