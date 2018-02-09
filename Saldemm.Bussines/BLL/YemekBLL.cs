using System;
using System.Collections.Generic;
using Saldemm.VO;
using System.Linq;

namespace Saldemm.BLL
{
	///<summary>
	///The class that acts as a business logic layer.
	///</summary>
    public class YemekBLL<TEntity>:BaseDAL<TEntity> where TEntity : Yemek
    {

        public void Insert(Cesitler Cesitler)
        {
            throw new NotImplementedException();
        }

        public void Update(string p, Cesitler Cesitler)
        {
            throw new NotImplementedException();
        }
    }
}