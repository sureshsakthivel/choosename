using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chooseName.Code.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int ActivationCode { get; set; }
    }

    public class Numero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumeroPattern { get; set; }
    }
    public class UserNumeroMapping
    {
        public int userId { get; set; }
        public int NumeroId { get; set; }
        public int unId { get; set; }
    }
    public class ChosenName
    {
        public int Id { get; set; }
        public int unId { get; set; }
        public string Name { get; set; }
        public int NumerlogyNumber { get; set; }
    }
}