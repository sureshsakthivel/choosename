using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chooseName.Code.Model;
using chooseName.Code.DAL;
namespace chooseName.Code.Service
{
    public class ChosenNameService
    {
        ChosenNameDAL ChosenNameDAL = null;

        public void Save(ChosenName ChosenName)
        {
            try
            {
                if (ChosenName == null)
                    throw new ArgumentException("ChosenName is empty");

                if (String.IsNullOrEmpty(ChosenName.Name))
                    throw new ArgumentException("ChosenName name is empty");


                if (ChosenName.UnId <= 0)
                    throw new ArgumentException("user id is empty");

                if (ChosenName.NumerlogyNumber <= 0)
                    throw new ArgumentException("NumerlogyNumber is empty");

                ChosenNameDAL = new ChosenNameDAL();
                ChosenNameDAL.Insert(ChosenName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ChosenName> GetChosenName(int id)
        {
            if (id <= 0)
                throw new ArgumentException("id is empty");

            ChosenNameDAL = new ChosenNameDAL();
            return ChosenNameDAL.Search(id);
        }
     
    }
}