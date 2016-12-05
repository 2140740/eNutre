using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.IO;
using System.Xml;
using System.Globalization;

namespace RestaurantesWebservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceVegetais : IServiceVegetais
    {
        //chave : username 
        //valor: objecto user propriamente dito
        private Dictionary<string, User> users;

        //chave: uid
        //valor: objecto token
        private Dictionary<string, Token> tokens;

        private static string FILEPATH;


        private class Token
        {
            private string value;
            private long timeout;// qnd é que o token deixa de ser valido
            private User user;

            public Token(User user) : this(user, 240000)
            {
            }
            // token válido por 4 minutos { }

            public Token(User user, long timeout)
            {
                this.value = Guid.NewGuid().ToString();
                this.timeout = Environment.TickCount + timeout;
                this.user = user;
            }

            public string Value { get { return value; } }
            public long Timeout { get { return timeout; } }
            public User User { get { return user; } }
            public string Username

            {
                get
                {
                    return user.Username;
                }
            }
            public void UpdateTimeout()
            {
                UpdateTimeout(240000); // token renovado por 4 minutos
            }

            public void UpdateTimeout(long timeout)
            {
                this.timeout = Environment.TickCount + timeout;
            }
            public Boolean isTimeoutExpired()
            {
                return Environment.TickCount > timeout;
            }
        }

        public ServiceVegetais()
        {
            this.users = new Dictionary<string, User>();
            this.tokens = new Dictionary<string, Token>();
            // default administrator

            //cria um primeiro utilizador de administracao
            users.Add("admin", new User("admin", "admin", true));

            //define a filepath do ficheiro bookstore.xml
            FILEPATH = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "vegetais.xml");
        }

        public void SignUp(User user, string token)
        {
            checkAuthentication(token, true);

            //ver se o username ja existe
            if (users.Keys.Contains(user.Username))
            {
                throw new ArgumentException("ERROR: username already exists: " + user.Username);
            }
            //acrescenta o user recebido ao dicionario utilizando
            //o username como chave
            users.Add(user.Username, user);
        }
        public string LogIn(string username, string password)
        {
            cleanUpTokens();
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password) &&
            password.Equals(users[username].Password))
            {
                Token tokenObject = new Token(users[username]);
                tokens.Add(tokenObject.Value, tokenObject);
                return tokenObject.Value;
            }
            else
            {
                throw new ArgumentException("ERROR: invalid username/password combination.");
            }
        }
        public void LogOut(string token)
        {

            tokens.Remove(token);
            cleanUpTokens();
        }
        public bool IsAdmin(string token)
        {
            return tokens[token].User.Admin;
        }
        public bool IsLoggedIn(string token)
        {
            bool res = true;
            try
            {
                checkAuthentication(token, false);
            }
            catch (ArgumentException)
            {
                res = false;
            }
            return res;
        }
        private void cleanUpTokens()
        {
            foreach (Token tokenObject in tokens.Values)
            {
                if (tokenObject.isTimeoutExpired())
                {
                    tokens.Remove(tokenObject.Username);
                }
            }
        }
        private Token checkAuthentication(string token, bool mustBeAdmin)
        {
            Token tokenObject;
            if (String.IsNullOrEmpty(token))
            {
                throw new ArgumentException("ERROR: invalid token value.");
            }
            try
            {
                tokenObject = tokens[token];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("ERROR: user is not logged in (expired session?).");
            }
            if (tokenObject.isTimeoutExpired())
            {
                tokens.Remove(tokenObject.Username);
                // se chegou aqui é porque:
                //      -o uid passado por parametro nao e vazio nem nulo
                //      -o uid existe o dicionario de tokens e foi possivel obter o objecto token correto?
                //      -o token tem um timeout que ainda nao expirou
                //caso contrario teria sido lancada uma exeception ocm o erro


                // aqui cai se verificar se caso o parametro mustBeAdmin esteja true o user
                //ao qual foi dado o token é admin
                throw new ArgumentException("ERROR: the session has expired. Please log in again.");
            }
            if (mustBeAdmin && !tokens[token].User.Admin)
            {
                throw new ArgumentException("ERROR: only admins are allowed to perform this operation.");
            }

            //qando se chega aqui é porque o tken e valido e renovamo-lo (por ainda mas 4 mins)
            tokenObject.UpdateTimeout();

            // e devolvemos o ojbecto token(que tem o uid passado por parametro e nao so)
            return tokenObject;
        }

        //------------------------------------------------------------------------------------------------------------------------------

        public List<Vegetais> GetVegetais(string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            List<Vegetais> vegetal = new List<Vegetais>();
            XmlNodeList vegetaisNodes = doc.SelectNodes("/vegetais/vegetal");
            foreach (XmlNode vegetalNode in vegetaisNodes)
            {
                XmlNode vegetalCaloriasNode = vegetalNode.SelectSingleNode("calorias");
                XmlNode vegetalNomeNode = vegetalNode.SelectSingleNode("nome");
                XmlNode vegetalquantidadeNode = vegetalNode.SelectSingleNode("quantidade");
                Vegetais vegetais = new Vegetais(
                vegetalCaloriasNode.InnerText,
                vegetalNomeNode.InnerText,
                vegetalquantidadeNode.InnerText);
                vegetal.Add(vegetais);
            }
            return vegetal;
        }

        public void AddVegetal(Vegetais vegetal, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode vegetalNode = doc.SelectSingleNode("/vegetais");
            XmlElement vegetal_Node = doc.CreateElement("vegetal");

            XmlElement vegetalCaloriasNode = doc.CreateElement("calorias");
            vegetalCaloriasNode.InnerText = vegetal.Calorias;
            vegetal_Node.AppendChild(vegetalCaloriasNode);

            XmlElement vegetalNomeNode = doc.CreateElement("nome");
            vegetalNomeNode.InnerText = vegetal.Nome;
            vegetal_Node.AppendChild(vegetalNomeNode);

            XmlElement vegetalquantidadeNode = doc.CreateElement("quantidade");
            vegetalquantidadeNode.InnerText = vegetal.Quantidade;
            vegetal_Node.AppendChild(vegetalquantidadeNode);

            vegetalNode.AppendChild(vegetal_Node);
            doc.Save(FILEPATH);
        }

        public void DeleteVegetal(string vegetal, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode restauranteNode = doc.SelectSingleNode("/vegetais");
            XmlNode restaurantesNode = doc.SelectSingleNode("/vegetais/vegetal[nome='" + vegetal + "']");
            if (restaurantesNode != null)
            {
                restauranteNode.RemoveChild(restaurantesNode);
                doc.Save(FILEPATH);
            }
        }
    }
}