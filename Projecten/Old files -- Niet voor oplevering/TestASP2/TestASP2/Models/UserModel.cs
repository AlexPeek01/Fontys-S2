using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASP2.Models
{
    public class UserModel
    {
        public int userId { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public DateTime geboortedatum { get; set; }
        public string eMail { get; set; }
        public string telefoonNummer { get; set; }
        public string profielFoto { get; set; }
        public string userName { get; set; }
        public string password { get; set; }


        public UserModel(int _userId, string _voornaam, string _achternaam, DateTime _geboortedatum, string _eMail, string _telefoonNummer, string _profielFoto, string _userName, string _password)
        {
            userId = _userId;
            voornaam = _voornaam;
            achternaam = _achternaam;
            geboortedatum = _geboortedatum;
            eMail = _eMail;
            telefoonNummer = _telefoonNummer;
            profielFoto = _profielFoto;
            userName = _userName;
            password = _password;
        }
    }
}
