using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestaurantesWebservice
{
    [ServiceContract]
    public interface IServiceExercicios
    {
        // AUTHENTICATION
        [WebInvoke(Method = "POST", UriTemplate = "/signup?token={token}")]
        [OperationContract]
        void SignUp(User user, string token); // admin only

        [WebInvoke(Method = "POST", UriTemplate = "/login?username={username}&password={password}")]
        [OperationContract]
        string LogIn(string username, string password);

        [WebInvoke(Method = "POST", UriTemplate = "/logout")]
        [OperationContract]
        void LogOut(string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/isadmin?token={token}")]
        bool IsAdmin(string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/isloggedin?token={token}")]
        bool IsLoggedIn(string token);

        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        // GET EXERCICIOS
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/exercicio?token={token}")]
        List<Exercicios> GetExercicio(string token);

        // admin only
        // ADD EXERCICIOS
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/exercicio?token={token}")]
        void AddExercicio(Exercicios exercicios, string token);

        // admin only
        // DELETE EXERCICIOS
        [OperationContract(Name = "DeleteExercicioisByTitle")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/exercicio/{exercicio}?token={token}")]
        void DeleteExercicio(string exercicio, string token); // admin only

    }

    [DataContract]
    public class Exercicios
    {
        private string nome;
        private string calorias;
        private string met;

        public Exercicios(string nome, string calorias, string met)
        {
            this.nome = nome;
            this.calorias = calorias;
            this.met = met;
        }

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [DataMember]
        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }

        }

        [DataMember]
        public string Met
        {
            get { return met; }
            set { met = value; }
        }

        public override string ToString()
        {
            string res = String.Empty;
            res += "Nome: " + Nome + Environment.NewLine;
            res += "Calorias: " + Calorias + Environment.NewLine;
            res += "Met: " + Met + Environment.NewLine;
            return res;
        }
    }

    [DataContract]
    public class User
    {
        private string username;
        private string password;
        private bool admin;

        public User(string username, string password, bool admin)
        {
            this.admin = admin;
            this.username = username;
            this.password = password;
        }

        [DataMember]
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }

        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}

