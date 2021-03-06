using InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op):base(op)
		{

		}

		public DbSet<Item> Items { get; set; }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<expenseCategory> expenseCategories { get; set; }


	}
}
