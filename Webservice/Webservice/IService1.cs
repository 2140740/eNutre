using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
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


        //-------------------------------------------------------EXERCICIOS----------------------------------------------------------------
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

        //-------------------------------------------------------RESTAURANTES----------------------------------------------------------------
        // GET RESTAURANTES
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/restaurante?token={token}")]
        List<Restaurantes> GetRestaurantes(string token);

        // admin only
        // ADD RESTAURANTES
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/restaurante?token={token}")]
        void AddRestaurante(Restaurantes restaurante, string token);

        // admin only
        // DELETE RESTAURANTES
        [OperationContract(Name = "DeleteRestauranteByTitle")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/restaurante/{restaurante}?token={token}")]
        void DeleteRestaurante(string restaurante, string token); // admin only

        //-------------------------------------------------------VEGETAIS----------------------------------------------------------------
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

    //----------------------------------------------------------USER--------------------------------------------------------

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

    //-------------------------------------------------------------RESTAURANTES---------------------------------------------------------------

    [DataContract]
    public class Restaurantes
    {
        private string restaurante;
        private string item;
        private string quantidade;
        private string calorias;

        public Restaurantes(string restaurante, string item, string quantidade, string calorias)
        {
            this.restaurante = restaurante;
            this.item = item;
            this.quantidade = quantidade;
            this.calorias = calorias;
        }

        [DataMember]
        public string Restaurante
        {
            get { return restaurante; }
            set { restaurante = value; }
        }

        [DataMember]
        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        [DataMember]
        public string Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        [DataMember]
        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        public override string ToString()
        {
            string res = String.Empty;
            res += "Restaurante: " + Restaurante + Environment.NewLine;
            res += "Item: " + Item + Environment.NewLine;
            res += "Quantidade: " + Quantidade + Environment.NewLine;
            res += "Calorias: " + Calorias + Environment.NewLine;
            return res;
        }
    }

    //-------------------------------------------------------VEGETAIS------------------------------------------------------------------------

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
            res += "Nome: " + Nome + Environment.NewLine;
            res += "Quantidade: " + Quantidade + Environment.NewLine;
            res += "Calorias: " + Calorias + Environment.NewLine;
            return res;
        }
    }
}
