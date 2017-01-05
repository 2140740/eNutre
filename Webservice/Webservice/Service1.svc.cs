using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    { //chave : username 
        //valor: objecto user propriamente dito
        private Dictionary<string, User> users;

        //chave: uid
        //valor: objecto token
        private Dictionary<string, Token> tokens;

        private static string FILEPATHExerc;
        private static string FILEPATHrest;
        private static string FILEPATHveg;

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

        public Service1()
        {
            this.users = new Dictionary<string, User>();
            this.tokens = new Dictionary<string, Token>();
            // default administrator

            //cria um primeiro utilizador de administracao
            users.Add("admin", new User("admin", "admin", true));

            //define a filepath do ficheiro bookstore.xml
            FILEPATHExerc = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "json.xml");
            FILEPATHrest = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "restaurantes.xml");
            FILEPATHveg = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "vegetais.xml");
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

        //-----------------------------------------------------EXERCICIOS-------------------------------------------------------------------

        public List<Exercicios> GetExercicio(string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHExerc);
            List<Exercicios> exercicio = new List<Exercicios>();
            XmlNodeList exercicioNodes = doc.SelectNodes("/exercicios/exercicio");
            foreach (XmlNode exercicioNode in exercicioNodes)
            {
                XmlNode exercicioNomeNode = exercicioNode.SelectSingleNode("nome");
                XmlNode exercicioCaloriasNode = exercicioNode.SelectSingleNode("calorias");
                XmlNode exercicioMetNode = exercicioNode.SelectSingleNode("met");
                Exercicios exercicios = new Exercicios(
                exercicioNomeNode.InnerText,
                exercicioCaloriasNode.InnerText,
                exercicioMetNode.InnerText);
                exercicio.Add(exercicios);
            }
            return exercicio;
        }

        public Exercicios AddExercicio(Exercicios exercicios, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHExerc);
            XmlNode exercicioNode = doc.SelectSingleNode("/exercicios");
            XmlElement exercicio_Node = doc.CreateElement("exercicio");

            XmlElement exercicioNomeNode = doc.CreateElement("nome");
            exercicioNomeNode.InnerText = exercicios.Nome;
            exercicio_Node.AppendChild(exercicioNomeNode);

            XmlElement exercicioCaloriasNode = doc.CreateElement("calorias");
            exercicioCaloriasNode.InnerText = exercicios.Calorias;
            exercicio_Node.AppendChild(exercicioCaloriasNode);

            XmlElement exerciciometNode = doc.CreateElement("met");
            exerciciometNode.InnerText = exercicios.Met;
            exercicio_Node.AppendChild(exerciciometNode);

            exercicioNode.AppendChild(exercicio_Node);
            doc.Save(FILEPATHExerc);

            return exercicios;
        }

        public void DeleteExercicio(string exercicio, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHExerc);
            XmlNode exercicioNode = doc.SelectSingleNode("/exercicios");
            XmlNode exerciciosNode = doc.SelectSingleNode("/exercicios/exercicio[nome='" + exercicio + "']");
            if (exerciciosNode != null)
            {
                exercicioNode.RemoveChild(exerciciosNode);
                doc.Save(FILEPATHExerc);
            }
        }

        public Exercicios GetExerciciosByName(string nome, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHExerc);
            XmlNode nomeNode = doc.SelectSingleNode("/exercicios/exercicio[nome='" + nome + "']/nome");
            if (nomeNode == null)
            {
                return null;
            }
            XmlNode caloriasNode = doc.SelectSingleNode("/exercicios/exercicio[nome='" + nome + "']/calorias");
            XmlNode metNode = doc.SelectSingleNode("/exercicios/exercicio[nome='" + nome + "']/met");

            Exercicios exercicio = new Exercicios(
            nomeNode.InnerText,
            caloriasNode.InnerText,
            metNode.InnerText);

            return exercicio;
        }

        //-----------------------------------------RESTAURANTES-----------------------------------------------------------------

        public List<Restaurantes> GetRestaurantes(string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHrest);
            List<Restaurantes> restaurante = new List<Restaurantes>();
            XmlNodeList restaurantesNodes = doc.SelectNodes("/restaurantes/restaurante");
            foreach (XmlNode restauranteNode in restaurantesNodes)
            {
                XmlNode restaurante_Node1 = restauranteNode.SelectSingleNode("nome");
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

        public Restaurantes AddRestaurante(Restaurantes restaurante, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHrest);
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
            doc.Save(FILEPATHrest);

            return restaurante;
        }

        public void DeleteRestaurante(string item, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHrest);
            XmlNode restauranteNode = doc.SelectSingleNode("/restaurantes");
            XmlNode restaurantesNode = doc.SelectSingleNode("/restaurantes/restaurante[item='" + item + "']");
            if (restaurantesNode != null)
            {
                restauranteNode.RemoveChild(restaurantesNode);
                doc.Save(FILEPATHrest);
            }
        }
        
        public Restaurantes GetRestaurantesByName(string item, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHrest);
            XmlNode nomeNode = doc.SelectSingleNode("/restaurantes/restaurante[item='" + item + "']/nome");
            if (nomeNode == null)
            {
                return null;
            }
            XmlNode itemNode = doc.SelectSingleNode("/restaurantes/restaurante[item='" + item + "']/item");
            XmlNode quantidadeNode = doc.SelectSingleNode("/restaurantes/restaurante[item='" + item + "']/quantidade");
            XmlNode caloriasNode = doc.SelectSingleNode("/restaurantes/restaurante[item='" + item + "']/calorias");

            Restaurantes restaurante = new Restaurantes(
            nomeNode.InnerText,
            itemNode.InnerText,
            quantidadeNode.InnerText,
            caloriasNode.InnerText);
            
            return restaurante;
        }
        

        //---------------------------------------VEGETAIS--------------------------------------------------------

        public List<Vegetais> GetVegetais(string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHveg);
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

        public Vegetais AddVegetal(Vegetais vegetais, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHveg);
            XmlNode vegetalNode = doc.SelectSingleNode("/vegetais");
            XmlElement vegetal_Node = doc.CreateElement("vegetal");

            XmlElement vegetalCaloriasNode = doc.CreateElement("calorias");
            vegetalCaloriasNode.InnerText = vegetais.Calorias;
            vegetal_Node.AppendChild(vegetalCaloriasNode);

            XmlElement vegetalNomeNode = doc.CreateElement("nome");
            vegetalNomeNode.InnerText = vegetais.Nome;
            vegetal_Node.AppendChild(vegetalNomeNode);

            XmlElement vegetalquantidadeNode = doc.CreateElement("quantidade");
            vegetalquantidadeNode.InnerText = vegetais.Quantidade;
            vegetal_Node.AppendChild(vegetalquantidadeNode);

            vegetalNode.AppendChild(vegetal_Node);
            doc.Save(FILEPATHveg);

            return vegetais;
        }

        public void DeleteVegetal(string vegetal, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHveg);
            XmlNode restauranteNode = doc.SelectSingleNode("/vegetais");
            XmlNode restaurantesNode = doc.SelectSingleNode("/vegetais/vegetal[nome='" + vegetal + "']");
            if (restaurantesNode != null)
            {
                restauranteNode.RemoveChild(restaurantesNode);
                doc.Save(FILEPATHveg);
            }

        }

        public Vegetais GetVegetaisByName(string nome, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATHveg);
            XmlNode nomeNode = doc.SelectSingleNode("/vegetais/vegetal[nome='" + nome + "']/calorias");
            if (nomeNode == null)
            {
                return null;
            }
            XmlNode caloriasNode = doc.SelectSingleNode("/vegetais/vegetal[nome='" + nome + "']/nome");
            XmlNode quantidadeNode = doc.SelectSingleNode("/vegetais/vegetal[nome='" + nome + "']/quantidade");

            Vegetais vegetal = new Vegetais(
            nomeNode.InnerText,
            caloriasNode.InnerText,
            quantidadeNode.InnerText);

            return vegetal;
        }

    }
}

