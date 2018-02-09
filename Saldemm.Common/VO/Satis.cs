using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saldemm.VO
{
	public partial class Satis:BaseEntity
	{
		[Key]
		public int SatisId { get; set; }

		[ForeignKey("Yemek")]
		public int? YemekId { get; set; }

		public int? SatisAdet { get; set; }

		public DateTime? SatisTarih { get; set; }

		[StringLength(50)]
		public string SatisTutar { get; set; }

		public bool? SatisAktif { get; set; }

		public virtual Yemek Yemek { get; set; }

		public Satis()
		{
		}
	}
}
