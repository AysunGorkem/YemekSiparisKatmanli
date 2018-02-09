using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Saldemm.Web;
using Saldemm.BLL;
using Saldemm.VO;
using System.Linq.Expressions;

namespace yemek
{
    public partial class yemekcesitleri : BasePage
    {
        public int guid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                GridDoldur();
                SatisddlDoldur();
                YemekddlDoldur();
            }
        }

        private void bagla(long guid, object sender, EventArgs e)
        {
            try
            {
                Satis Satis = SatisBLL.SelectWithId(guid);

                if (Satis != null)
                {
                    if (ddlYemekId != null)
                        ddlYemekId.SelectedValue = ddlYemekId.ToString();
                    else ddlYemekId.SelectedValue = "";

                    if (Satis.SatisAdet != null)
                    {
                        string gecici = Satis.SatisAdet.ToString();
                        txtSatisAdet.Text = gecici.ToString();
                    }
                    else txtSatisAdet.Text = "";

                    if (Satis.SatisTarih != null)
                        txtSatisTarih.Text = Satis.SatisTarih.Value.ToShortDateString();
                    else txtSatisTarih.Text = "";

                    if (!string.IsNullOrEmpty(Satis.SatisTutar))
                        txtSatisTutar.Text = Satis.SatisTutar;
                    else txtSatisTutar.Text = "";
                }
            }
            catch (Exception ex)
            {

            }


        }

        List<Expression<Func<Satis, bool>>> predicates = new List<Expression<Func<Satis, bool>>>();


        protected void GridDoldur()
        {
            gvSatis.Visible = true;
            try
            {
                //if (ddlYemekEkle.SelectedValue != "0")
                //{
                //    int gecici = Convert.ToInt32(ddlYemekId.SelectedValue);
                //    Expression<Func<Satis, bool>> pr1 = p => p.YemekId == gecici;
                //}

                //if (ddlYemekId.SelectedValue != "0")
                //{
                //    int vergi = Convert.ToInt32(ddlYemekId.SelectedValue);
                //    Expression<Func<Satis, bool>> pr1 = p => p.YemekId == vergi;
                //    predicates.Add(pr1);
                //}

                //if (!string.IsNullOrEmpty(txtSatisAdet.Text))
                //{
                //    int kayit = Convert.ToInt32(txtSatisAdet.Text);
                //    Expression<Func<Satis, bool>> pr1 = p => p.SatisAdet == kayit;
                //    predicates.Add(pr1);
                //}

                //if (!string.IsNullOrEmpty(txtSatisTarih.Text))
                //{
                //    DateTime tarih = Convert.ToDateTime(txtSatisTarih.Text);
                //    Expression<Func<Satis, bool>> pr1 = p => p.SatisTarih == tarih;
                //    predicates.Add(pr1);
                //}

                //if (!string.IsNullOrEmpty(txtSatisTutar.Text))
                //{
                //    string temp = txtSatisTutar.Text;
                //    Expression<Func<Satis, bool>> pr1 = p => p.SatisTutar == temp; // == yap
                //    predicates.Add(pr1);
                //}


                Expression<Func<Satis, bool>> pr3 = p => p.SatisAktif == true;
                predicates.Add(pr3);
                List<Satis> SatisList = SatisBLL.SelectOrderedPaged(predicates, new Expression<Func<Satis, string>>[] { p => p.SatisTarih.ToString() }, false).ToList();
                gvSatis.DataSource = SatisList;
                gvSatis.DataBind();

            }
            catch (Exception ex)
            { }
        }

        private void YemekddlDoldur()
        {
            ddlYemekEkle.Items.Clear();
            ListItem item = new ListItem("-seciniz-", "0");
            ddlYemekEkle.Items.Add(item);
            ModelContext mc = new ModelContext();
            var list1 = from c in mc.Yemeks
                        orderby c.YemekId ascending
                        where c.Aktif == true
                        select new { c.YemekId, c.YemekAd };
            var list = list1.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ListItem items = new ListItem();
                items.Text = list[i].YemekAd.ToString();
                items.Value = list[i].YemekId.ToString();
                ddlYemekEkle.Items.Add(items);
            }

        }

        private void SatisddlDoldur()
        {
            ddlYemekId.Items.Clear();
            ListItem item = new ListItem("-Seciniz-", "0");
            ddlYemekId.Items.Add(item);
            ModelContext mc = new ModelContext();
            var list1 = from c in mc.Yemeks
                        orderby c.YemekId ascending
                        where c.Aktif == true
                        select new { c.YemekId, c.YemekAd };
            var list = list1.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ListItem items = new ListItem();
                items.Text = list[i].YemekAd.ToString();
                items.Value = list[i].YemekId.ToString();
                ddlYemekId.Items.Add(items);
            }
        }

        protected void btnPopupYemekEkle_Click(object sender, EventArgs e)
        {



        }

        protected void btnPopupCesit_Click(object sender, EventArgs e)
        {

        }

        protected void btnPopupSatis_Click(object sender, EventArgs e)
        {

        }


        #region Satis
        protected void gvSatis_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Duzenle")
            {
                guid = Convert.ToInt32(e.CommandArgument);
                lblId.Text = guid.ToString();
                Satis.Text = "Guncelle";


                //?
                if (guid != 0)
                    bagla(guid, sender, e);
                ModalSatis.Show();
            }
            else if (e.CommandName == "Sil")
            {
                try
                {
                    long YemeklerId = Convert.ToInt64(e.CommandArgument);
                    Satis Satis = SatisBLL.SelectWithId(YemeklerId);
                    if (Satis != null)
                    {
                        Satis.SatisAktif = false;
                        SatisBLL.Update(YemeklerId, Satis);
                    }
                    GridDoldur();
                }
                catch (Exception ex)
                {

                }
            }
        }


        protected void gvSatis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Satis Satis = e.Row.DataItem as Satis;  //Yesil?
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                Image img = (Image)e.Row.FindControl("img");
                LinkButton lblDuzenle = (LinkButton)e.Row.FindControl("lblDuzenle");
                Image imgDuzenle = (Image)e.Row.FindControl("imgDuzenle");
            }


        }

        DataTable dt1 = new DataTable();
        protected void gvSatisDoldur()
        {

        }

        #endregion

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                guid = 0;
                if (!string.IsNullOrEmpty(lblId.Text))
                    guid = Convert.ToInt32(lblId.Text);

                if (guid == 0)
                {
                    Yemek Yemek = new Yemek();

                    Yemek.Aktif = true;
                    Yemek.YemekAd = txtYemekAd.Text;
                    Yemek.CesitId = Convert.ToInt32(ddlYemekEkle.SelectedValue);

                    if (!string.IsNullOrEmpty(txtYemekAd.Text))
                        Yemek.YemekAd = txtYemekAd.Text;
                    else Yemek.YemekAd = null;


                    if (string.IsNullOrEmpty(ddlYemekEkle.SelectedValue))
                        Yemek.CesitId = Convert.ToInt32(ddlYemekEkle.Text);
                    else Yemek.CesitId = null;

                    // int kid = YemekBLL.Insert.(Yemek).CesitId;
                    YemekBLL.Insert(Yemek);

                }
                else
                {
                    Yemek Yemek = YemekBLL.SelectWithId(guid);
                    if (Yemek != null)
                    {
                        Yemek.Aktif = true;
                        Yemek.YemekAd = txtYemekAd.Text;
                        Yemek.CesitId = Convert.ToInt32(ddlYemekEkle.SelectedValue);
                        if (!string.IsNullOrEmpty(txtYemekAd.Text))
                            Yemek.YemekAd = txtYemekAd.Text;
                        else Yemek.YemekAd = null;

                        if (!string.IsNullOrEmpty(ddlYemekEkle.Text))
                            Yemek.CesitId = Convert.ToInt32(ddlYemekEkle.Text);
                        else Yemek.CesitId = null;

                        Yemek.YemekId = guid;

                        YemekBLL.Update(Yemek.YemekId, Yemek);
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("hata");
            }
        }

        protected void Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                guid = 0;
                if (!string.IsNullOrEmpty(lblId.Text)) 
                guid = Convert.ToInt32(lblId.Text);

                if (guid == 0)
                {
                    Cesitler Cesitler = new Cesitler();
                    Cesitler.Aktif = true;
                    Cesitler.Ad = txtPopupCesit.Text;

                    if (!string.IsNullOrEmpty(txtPopupCesit.Text))
                        Cesitler.Ad = txtPopupCesit.Text;
                    else Cesitler.Ad = null;

                    CesitlerBLL.Insert(Cesitler);
                }
                else
                {
                    Cesitler Cesitler = CesitlerBLL.SelectWithId(guid);
                    if (Cesitler != null)
                    {
                        Cesitler.Aktif = true;
                        Cesitler.Ad = txtPopupCesit.Text;
                        if (!string.IsNullOrEmpty(txtPopupCesit.Text))
                            Cesitler.Ad = txtPopupCesit.Text;
                        else Cesitler.Ad = null;

                        Cesitler.Ad = guid.ToString();

                        CesitlerBLL.Update(Cesitler.Ad, Cesitler);
                    }
                }


            }
            catch (Exception ex)
            { }
        }

        protected void Satis_Click(object sender, EventArgs e)
        {
            try
            {

                guid = 0;
                if (!string.IsNullOrEmpty(lblId.Text))  //?
                  guid = Convert.ToInt32(lblId.Text);

                if (guid == 0)
                {
                    Satis Satis = new Satis();

                    Satis.SatisAktif = true;
                    Satis.YemekId = Convert.ToInt32(ddlYemekId.SelectedValue);
                    Satis.SatisAdet = Convert.ToInt32(txtSatisAdet.Text);
                    Satis.SatisTarih = Convert.ToDateTime(txtSatisTarih.Text);
                    Satis.SatisTutar = txtSatisTutar.Text;


                    if (!string.IsNullOrEmpty(txtSatisAdet.Text))
                        Satis.SatisAdet = Convert.ToInt32(txtSatisAdet.Text);
                    else Satis.SatisAdet = null;

                    if (!string.IsNullOrEmpty(txtSatisTarih.Text))
                        Satis.SatisTarih = Convert.ToDateTime(txtSatisTarih.Text);
                    else Satis.SatisTarih = null;

                    if (!string.IsNullOrEmpty(txtSatisTutar.Text))
                        Satis.SatisTutar = txtSatisTutar.Text;
                    else Satis.SatisTutar = null;

                    SatisBLL.Insert(Satis);
                    GridDoldur();
                    //        }
                    //        else
                    //        {
                    //            Satis Satis = SatisBLL.SelectWithId(guid);
                    //            if(Satis != null)
                    //            {
                    //                Satis.SatisAktif = true;
                    //            Satis.YemekId = Convert.ToInt32(ddlYemekId.SelectedValue);
                    //            Satis.SatisAdet = Convert.ToInt32(txtSatisAdet.Text);
                    //            Satis.SatisTarih = Convert.ToDateTime(txtSatisTarih.Text);
                    //            Satis.SatisTutar = txtSatisTutar.Text;

                    //            if(string.IsNullOrEmpty(ddlYemekId.SelectedValue))
                    //                Satis.YemekId = Convert.ToInt32(ddlYemekId.Text);
                    //            else Satis.YemekId = null;

                    //            if(!string.IsNullOrEmpty(txtSatisAdet.Text))
                    //                Satis.SatisAdet = Convert.ToInt32(ddlYemekId.Text);
                    //            else Satis.SatisAdet = null;

                    //            if(!string.IsNullOrEmpty(txtSatisTarih.Text))
                    //                Satis.SatisTarih = Convert.ToDateTime(txtSatisTarih.Text);
                    //            else Satis.SatisTarih = null;

                    //            if(!string.IsNullOrEmpty(txtSatisTutar.Text))
                    //                Satis.SatisTutar = txtSatisTutar.Text;
                    //            else Satis.SatisTutar = null;

                    //            Satis.SatisId = guid;

                    //            SatisBLL.Update(Satis.SatisId, Satis);
                    //            }
                    //        }
                    //    }
                    //    catch(Exception ex)
                    //    {}
                    //    GridDoldur();
                    //}


                }
            }
            catch (Exception ex)
            { }

        }

        
        protected void gvSatis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSatis.PageIndex = e.NewPageIndex;
            GridDoldur();

        }
          
    }
}
