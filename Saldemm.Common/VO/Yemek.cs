using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saldemm.VO
{
	public partial class Yemek:BaseEntity
	{
		[Key]
		public int YemekId { get; set; }

		[StringLength(50)]
		public string YemekAd { get; set; }

		[ForeignKey("Cesitler")]
		public int? CesitId { get; set; }

		public bool? Aktif { get; set; }

		public virtual Cesitler Cesitler { get; set; }

        public Yemek()
        {
        }
    }
}
