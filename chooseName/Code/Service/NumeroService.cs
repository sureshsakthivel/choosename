using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chooseName.Code.Model;
using chooseName.Code.DAL;
namespace chooseName.Code.Service
{
    public class NumeroService
    {
        NumeroDAL numeroDAL = null;

        public void Save(Numero numero)
        {
            try
            {
                if (numero == null)
                    throw new ArgumentException("numero is empty");

                if (String.IsNullOrEmpty(numero.Name))
                    throw new ArgumentException("numero name is empty");


                if (numero.UserId<=0)
                    throw new ArgumentException("user id is empty");

                if (String.IsNullOrEmpty(numero.NumeroPattern))
                    throw new ArgumentException("NumeroPattern is empty");

                numeroDAL = new NumeroDAL();
                numeroDAL.Insert(numero);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Numero GetNumero(int id)
        {
            if (id <= 0)
                throw new ArgumentException("id is empty");

            numeroDAL = new NumeroDAL();
            return numeroDAL.Fetch(id);

        }
        public List<Numero> GetNumeros(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("user id is empty");
            numeroDAL = new NumeroDAL();
            return numeroDAL.Search(userId);

        }
    }
}