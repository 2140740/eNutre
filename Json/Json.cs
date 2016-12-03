using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using Formatting = System.Xml.Formatting;
using System.Windows.Forms;

namespace Jsoncode
{

    public class Json
    {

        public static List<string> CaloriasList = new List<string>();
        public static List<string> NomeList = new List<string>();
        public static List<string> MetList = new List<string>();
        public static String path_textboxjson;

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

        public static void writetoXMLJSON(XmlTextWriter writer, int i)
        {
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("exercicios");

            for (i = 0; i <= NomeList.Count - 1; i++)
            {
                createNodeJ(NomeList[i], CaloriasList[i], MetList[i], writer);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static void createNodeJ(string nome, string calorias, string met, XmlTextWriter writer)
        {
            writer.WriteStartElement("exercicios");
            writer.WriteStartElement("nome");
            writer.WriteString(nome);
            writer.WriteEndElement();
            writer.WriteStartElement("calorias");
            writer.WriteString(calorias);
            writer.WriteEndElement();
            writer.WriteStartElement("met");
            writer.WriteString(met);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    
        public static void ValidateJson()
        {
        Boolean isValid = true;

        try
        {

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, Environment.CurrentDirectory + "\\XSD\\XMLSchemaExercicios.xsd");
            settings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create(path_textboxjson, settings);
            XmlDocument document = new XmlDocument();
            document.Load(reader);

        }
        catch (Exception ex)
        {
            isValid = false;
            MessageBox.Show("Erro na validação do XML", "Erro de Validação", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        }
        finally
        {
            if (isValid != false)
            {
                MessageBox.Show("Sucesso na validação do XML", "Validação", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

    }
}
}
