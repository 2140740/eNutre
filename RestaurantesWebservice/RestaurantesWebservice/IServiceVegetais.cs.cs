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
    public interface IServiceVegetais
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
        // GET VEGETAIS
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/vegetal?token={token}")]
        List<Vegetais> GetVegetais(string token);

        // admin only
        // ADD VEGETAIS
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/vegetal?token={token}")]
        void AddVegetal(Vegetais vegetais, string token);

        // admin only
        // DELETE VEGETAIS
        [OperationContract(Name = "DeleteVegetaisByTitle")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/vegetal/{vegetal}?token={token}")]
        void DeleteVegetal(string vegetal, string token); // admin only

    }

    [DataContract]
    public class Vegetais
    {
        private string calorias;
        private string nome;
        private string quantidade;

        public Vegetais(string calorias, string nome, string quantidade)
        {
            this.calorias = calorias;
            this.nome = nome;
            this.quantidade = quantidade;
        }

        [DataMember]
        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }

        }

        [DataMember]
        public string Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public override string ToString()
        {
            string res = String.Empty;
            res += "Calorias: " + Calorias + Environment.NewLine;
            res += "Nome: " + Nome + Environment.NewLine;
            res += "Quantidade: " + Quantidade + Environment.NewLine;
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

