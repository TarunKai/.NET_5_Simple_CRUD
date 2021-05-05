using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
	public class expenseCategory
	{
		[Key]
		public int Id { get; set; }
		[DisplayName("Expense Category")]
		[Required]
		public string Category { get; set; }
	}
}
