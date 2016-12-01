using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Jsoncode
{

    public class Json
    {

        public static List<string> CaloriasList = new List<string>();
        public static List<string> NomeList = new List<string>();
        public static List<string> MetList = new List<string>();

        public string Nome { get; set; }
        public int Calorias { get; set; }
        public double Met { get; set; }

        public Json(string nome, int calorias, double met)
        {
            Nome = nome;
            Calorias = calorias;
            Met = met;
        }

        public override string ToString()
        {
            return Nome + ", " + Calorias + ", " + Met + ", ";
        }

        public static void ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);


            string result = null;

            foreach (string line in lines)
            {
                //listBox1.Items.Add(line);
                result += line;
            }

            List<Json> ex = JsonConvert.DeserializeObject<List<Json>>(result);

            string json2 = JsonConvert.SerializeObject(ex);

            string[] lista = Regex.Split(json2, @"\{");


            foreach (string match in lista)
            {
                if (match == "[" || match == "]")
                {

                }
                else
                {

                    string patnome = @"\:\W.*\W\,\W";
                    Regex rnome = new Regex(patnome, RegexOptions.IgnoreCase);
                    Match nome = rnome.Match(match);
                    string pnome = Convert.ToString(nome);

                    char[] MyChar = { ':', '"', '"', ',' };
                    string Remnome = pnome.Trim(MyChar);
                    string rsnome = Remnome.TrimEnd(MyChar);
                    NomeList.Add(rsnome);

                    string patcal = @"\W\:\d{2,4}";
                    Regex rcal = new Regex(patcal, RegexOptions.IgnoreCase);
                    Match cal = rcal.Match(match);
                    string scal = Convert.ToString(cal);
                    string pcal = scal.Remove(0, 2);
                    CaloriasList.Add(pcal);

                    string patmet = @"\d*\.\d";
                    Regex rmet = new Regex(patmet, RegexOptions.IgnoreCase);
                    Match met = rmet.Match(match);
                    MetList.Add(Convert.ToString(met));
                }
            }
        }
    }
}
