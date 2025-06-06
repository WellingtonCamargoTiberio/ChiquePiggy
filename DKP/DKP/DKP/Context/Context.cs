﻿using DKP.Models;
using Microsoft.EntityFrameworkCore;

namespace DKP.Context
{
    public class Context : DbContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Agendamento> Agendamentos { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProjetoDKP"));
        }
    }
}
