using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Saldemm.BLL;
using Saldemm.VO;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Saldemm.Web
{
    public abstract class BasePage : Page
    {
        private ModelContext _modelContext;

        protected ModelContext ModelContext
        {
            get
            {
                return _modelContext ?? (_modelContext = new ModelContext());
            }
        }
		
				 #region FieldsCesitler1
			 private CesitlerBLL<Cesitler> _CesitlerBLL;
		 #endregion

		 #region FieldsCesitler2
		 protected CesitlerBLL<Cesitler> CesitlerBLL
		 {
			 get
			 {
				 return _CesitlerBLL = new CesitlerBLL<Cesitler>();
			 }
		 }
		 #endregion

		 #region FieldsKullanici1
			 private KullaniciBLL<Kullanici> _KullaniciBLL;
		 #endregion

		 #region FieldsKullanici2
		 protected KullaniciBLL<Kullanici> KullaniciBLL
		 {
			 get
			 {
				 return _KullaniciBLL = new KullaniciBLL<Kullanici>();
			 }
		 }
		 #endregion

		 #region FieldsSatis1
			 private SatisBLL<Satis> _SatisBLL;
		 #endregion

		 #region FieldsSatis2
		 protected SatisBLL<Satis> SatisBLL
		 {
			 get
			 {
				 return _SatisBLL = new SatisBLL<Satis>();
			 }
		 }
		 #endregion

		 #region FieldsYemek1
			 private YemekBLL<Yemek> _YemekBLL;
		 #endregion

		 #region FieldsYemek2
		 protected YemekBLL<Yemek> YemekBLL
		 {
			 get
			 {
				 return _YemekBLL = new YemekBLL<Yemek>();
			 }
		 }
		 #endregion


    }
}