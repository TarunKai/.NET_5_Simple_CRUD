using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
	public class Item
	{
		[Key]
		public int Id { get; set; }
		public string Borrower { get; set; }

		/*We use data Annotation DisplayName for displaying to the 
		 * client side or else it will display ItemName without space
		 * between Item and Name.
		 */
		[DisplayName("Item Name")]
		public string ItemName { get; set; }
		public string Lender { get; set; }
	}
}
