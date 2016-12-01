using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassTXT
{
    public class Classtxtfile
    {

        public static List<string> Calorias = new List<string>();
        public static List<string> Produtos = new List<string>();
        public static List<string> Quantidades = new List<string>();
        public static string varerror;

        public static void Readfile(string path)
        {
            System.IO.TextReader readFile = new StreamReader(path);

            try
            {
                string text = "";
                string calorias = @"\s+\d{1,3}";
                string produto = @"\s+em\s+\D*";
                string quantidade = @"\(\d{1,4}.*\)";
                // Instantiate the regular expression object.
                Regex q = new Regex(calorias, RegexOptions.IgnoreCase);
                Regex p = new Regex(produto, RegexOptions.IgnoreCase);
                Regex r = new Regex(quantidade, RegexOptions.IgnoreCase);
                // Match the regular expression pattern against a text string.


                do
                {
                    text = readFile.ReadLine();
                    if (text != null)
                    {
                        Match m = r.Match(text);
                        string resultm = Convert.ToString(m);
                        Match pr = p.Match(text);
                        Match cl = q.Match(text);
                        string resultpr = Convert.ToString(pr);

                        string prf = Regex.Replace(resultpr, "[()]", "");
                        string produ = prf.Remove(0, 3).Trim(' ');

                        Produtos.Add(produ.Trim(' '));
                        //--------------------------------------------

                        if (text != null)
                        {
                            Quantidades.Add(resultm.Trim(new Char[] { ')', '(' }));
                            Calorias.Add(Convert.ToString(cl).Trim(' '));

                        }
                    }
                } while (text != null);

                readFile.Close();
                readFile = null;
            }
            catch (IOException ex)
            {
                varerror = (ex.ToString());
            }
        }
    }
}
