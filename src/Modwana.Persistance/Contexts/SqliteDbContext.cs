﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modwana.Persistance
{
    public class SqliteDbContext : ModwanaDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            if (string.IsNullOrWhiteSpace(Settings.SqliteFilePath))
                throw new ArgumentNullException($"The value of ({nameof(Settings.SqliteFilePath)}) in app settings cannot be null when use Sqlite");

            optionsBuilder.UseSqlite($"Filename={Settings.SqliteFilePath}");
        }
    }
}
