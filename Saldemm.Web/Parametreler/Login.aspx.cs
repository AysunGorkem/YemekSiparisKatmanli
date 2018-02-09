using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Saldemm.Web;
using Saldemm.BLL;
using Saldemm.VO;
using System.Linq.Expressions;


namespace yemek
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblHata.Visible = false;
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e) //Giris
        {

            try
            {
             
                string mail = txtEMail.Text;
                string sifre = txtSifre.Text;

                List<Kullanici> kullanici = KullaniciBLL.Select(new Expression<Func<Kullanici, bool>>[] { p => p.Aktif == true, p => p.EMail == mail }).ToList();

                if (kullanici.Count == 0)
                {
                    lblHata.Visible = true;
                    lblHata.Text = "Hatalı Email Lütfen Tekrar Deneyin..";
                    return;
                }
                else

               //Bu şekildedemyapılabilir şifre kontrolü

               //if (sifre != kullanici[0].Sifre)
               //{
               //    lblHata.Visible = true;
               //    lblHata.Text = "Hatalı Şifre Lütfen Tekrar Deneyin..";
               //    return;
               //}

                if (!txtSifre.Text.Equals(kullanici[0].Sifre))
                {
                    lblHata.Visible = true;
                    lblHata.Text = "Hatalı Şifre Lütfen Tekrar Deneyin..";
                    return;
                }

                Response.Redirect("yemekcesitleri.aspx");
            }
            catch (Exception ex)
            {
                lblHata.Visible = true;
                lblHata.Text = "Bir Sorun Oluştu Daha Sonra Tekrar Deneyin..";
                return;
            }   
        }
    }
    }
