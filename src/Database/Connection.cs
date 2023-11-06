/* Copyright (c) 2023-2025
 * This file is part of sep3cs.
 *
 * sep3cs is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * sep3cs is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with sep3cs. If not, see <http://www.gnu.org/licenses/>.
 */
using Microsoft.EntityFrameworkCore;

namespace DataClash.Data
{
  public class Connection : DbContext
    {
      public static Connection? defaultConnection {get; private set; }
      public string dbPath { get; private set; }

      public DbSet<Administrator> Administrators { get; set; }
      public DbSet<Player> Players { get; set; }

      protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlite ($"Data Source={dbPath}");
        }

      public Connection ()
        {
          var folder = Environment.SpecialFolder.LocalApplicationData;
          var path = Environment.GetFolderPath (folder);

          defaultConnection = this;
          dbPath = System.IO.Path.Join (path, "dataclash.db");
        }
    }
}
