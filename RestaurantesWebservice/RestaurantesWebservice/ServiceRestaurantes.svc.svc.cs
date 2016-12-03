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
    public class ServiceRestaurantes : IServiceRestaurantes
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

        public ServiceRestaurantes()
        {
            this.users = new Dictionary<string, User>();
            this.tokens = new Dictionary<string, Token>();
            // default administrator

            //cria um primeiro utilizador de administracao
            users.Add("admin", new User("admin", "admin", true));

            //define a filepath do ficheiro bookstore.xml
            FILEPATH = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "restaurantes.xml");
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

        public List<Restaurantes> GetRestaurantes(string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            List<Restaurantes> restaurante = new List<Restaurantes>();
            XmlNodeList restaurantesNodes = doc.SelectNodes("/restaurantes/restaurante");
            foreach (XmlNode restauranteNode in restaurantesNodes)
            {
                XmlNode restaurante_Node1 = restauranteNode.SelectSingleNode("restaurante");
                XmlNode itemNode = restauranteNode.SelectSingleNode("item");
                XmlNode quantidadeNode = restauranteNode.SelectSingleNode("quantidade");
                XmlNode caloriasNode = restauranteNode.SelectSingleNode("calorias");
                Restaurantes restaurantes = new Restaurantes(
                restaurante_Node1.InnerText,
                itemNode.InnerText,
                quantidadeNode.InnerText,
                caloriasNode.InnerText);
                restaurante.Add(restaurantes);
            }
            return restaurante;
        }

        public void AddRestaurante(Restaurantes restaurante, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode restauranteNode = doc.SelectSingleNode("/restaurantes");
            XmlElement restaurante_Node = doc.CreateElement("restaurante");

            XmlElement restaurante_Node1 = doc.CreateElement("restaurante");
            restaurante_Node1.InnerText = restaurante.Restaurante;
            restaurante_Node.AppendChild(restaurante_Node1);

            XmlElement itemNode = doc.CreateElement("item");
            itemNode.InnerText = restaurante.Item;
            restaurante_Node.AppendChild(itemNode);

            XmlElement quantidadeNode = doc.CreateElement("quantidade");
            quantidadeNode.InnerText = restaurante.Quantidade;
            restaurante_Node.AppendChild(quantidadeNode);

            XmlElement caloriasNode = doc.CreateElement("calorias");
            caloriasNode.InnerText = restaurante.Calorias;
            restaurante_Node.AppendChild(caloriasNode);

            restauranteNode.AppendChild(restaurante_Node);
            doc.Save(FILEPATH);
        }

        public void DeleteRestaurante(string restaurante, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode restauranteNode = doc.SelectSingleNode("/restaurantes");
            XmlNode restaurantesNode = doc.SelectSingleNode("/restaurantes/restaurante[restaurante='" + restaurante + "']");
            if (restaurantesNode != null)
            {
                restauranteNode.RemoveChild(restaurantesNode);
                doc.Save(FILEPATH);
            }
        }

    }

}