using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saldemm.VO
{
	public partial class Kullanici:BaseEntity
	{
		[Key]
		public int id { get; set; }

		[Required]
		[StringLength(50)]
		public string EMail { get; set; }

		[Required]
		[StringLength(50)]
		public string Sifre { get; set; }

		public bool? Aktif { get; set; }

		public Kullanici()
		{
		}
	}
}
