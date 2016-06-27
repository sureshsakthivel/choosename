using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace chooseName.Code.Model
{
    public class NumerologyPattern
    {
        public string Alphabet { get; set; }
        public int Value { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string ActivationCode { get; set; }

        public User(int id,string name, string emailId, string password, bool status, string activationCode)
        {
            Id = id;
            Name = name;
            EmailId = emailId;
            Password = password;
            Status = status;
            ActivationCode = activationCode;
        }
    }

    public class Numero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumeroPattern { get; set; }
        public int UserId { get; set; }
        public List<NumerologyPattern> numeroPatterns { get; set; }
        public Numero(int id, int userid, string name, string numeroPattern)
        {
            Id = id;
            Name = name;
            NumeroPattern = numeroPattern;
            UserId = userid;
            numeroPatterns = XmlUtility.FromXML<List<NumerologyPattern>>(numeroPattern);
        }
    }
    public class UserNumeroMapping
    {
        public int UserId { get; set; }
        public int NumeroId { get; set; }
        public int UnId { get; set; }
        public UserNumeroMapping(int unId, int userId, int numeroId)
        {
            UnId = unId;
            UserId = userId;
            NumeroId = numeroId;
        }
    }
    public class ChosenName
    {
        public int Id { get; set; }
        public int UnId { get; set; }
        public string Name { get; set; }
        public int NumerlogyNumber { get; set; }

        public ChosenName(int id, int uid, string name, int numerlogyNumber)
        {
            Id = id;
            UnId = uid;
            Name = name;
            NumerlogyNumber = numerlogyNumber;
        }
    }

    public static class XmlUtility
    {
        public static T FromXML<T>(string xml)
        {
            using (StringReader stringReader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }

        public static string ToXML<T>(this T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
}