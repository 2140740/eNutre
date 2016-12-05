using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
/*
namespace RestaurantesWebservice
{
    
    [ServiceContract]
    public interface IServiceRestaurantes
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

    }

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
    
}
*/
