using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saldemm.VO
{
	public partial class Cesitler:BaseEntity
	{
		[Key]
		public int CesitId { get; set; }

		[StringLength(50)]
		public string Ad { get; set; }

		public bool? Aktif { get; set; }

		public Cesitler()
		{
		}
	}
}
