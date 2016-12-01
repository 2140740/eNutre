using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ClassTXT;
using ExcelCode;
using Jsoncode;

namespace formMain
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private string path = null;
        private string pathrestaurante = null;
        private string pathexercicios = null;
        private string pathvegetais = null;
        public string xml = null;
        private string extension = null;

        private void button_upload_Click(object sender, EventArgs e)
        {
            /// Código Load do Ficheiro ////

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                extension = Path.GetExtension(path);
                if (!extension.Equals(".xsd"))
                {
                    try
                    {
                        textBox_path.Text = path;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro, " + ex.Message);
                    }
                }
                else
                {
                    textBox_path.Text = null;
                    path = null;
                    MessageBox.Show("Não é possível inserir um xsd neste campo", "Erro", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        }

        private void button_Excel_Click(object sender, EventArgs e)
        {
            if (path != null && extension.Equals(".xls"))
            {
                try
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    ExcelHandler.ReadExcel(path);

                    string pathfile = System.IO.Directory.GetCurrentDirectory() + "\\XLMS";

                    if (Directory.Exists(pathfile))
                    {
                        MessageBox.Show("Directoria já existe", "Directoria", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Tenta criar a directoria
                        Directory.CreateDirectory(pathfile);
                    }
                    saveFileDialog1.InitialDirectory = pathfile;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        XmlTextWriter writer =
                            new XmlTextWriter(saveFileDialog1.FileName,
                                System.Text.Encoding.UTF8);

                        pathrestaurante = saveFileDialog1.FileName;

                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("restaurantes");

                        for (int i = 0; i <= ExcelHandler.Restaurante.Count - 1; i++)
                        {
                            createNode(ExcelHandler.Restaurante[i], ExcelHandler.Item[i], ExcelHandler.Quantidade[i],
                                ExcelHandler.Calorias[i], writer);
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        MessageBox.Show("O ficheiro XML foi criado com sucesso ! ");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro, " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Essa extensão não é suportada neste botão", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        private void createNode(string restaurante, string item, string quantidade, string calorias,
            XmlTextWriter writer)
        {
            writer.WriteStartElement("restaurante");
            writer.WriteStartElement("restaurante");
            writer.WriteString(restaurante);
            writer.WriteEndElement();
            writer.WriteStartElement("item");
            writer.WriteString(item);
            writer.WriteEndElement();
            writer.WriteStartElement("quantidade");
            writer.WriteString(quantidade);
            writer.WriteEndElement();
            writer.WriteStartElement("calorias");
            writer.WriteString(calorias);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void ValidateExcel()
        {
            Boolean isValid = true;

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, Environment.CurrentDirectory + "\\XSD\\XMLSchemaRestaurantes.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(textBox_path.Text, settings);
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

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void ValidateAll_Click(object sender, EventArgs e)
        {
            if (path != null && extension.Equals(".xml"))
            {
                string pathfile = System.IO.Directory.GetCurrentDirectory() + "\\XSD";
                openFileDialog1.InitialDirectory = pathfile;

                openFileDialog1.Filter = "xsd files (*.xsd)|*.xsd";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                    try
                    {

                        if (openFileDialog1.FileName.Contains("XMLSchemaRestaurantes"))
                        {
                            ValidateExcel();
                        }
                        else if (openFileDialog1.FileName.Contains("XMLSchemaExercicios"))
                        {
                            ValidateJson();
                        }
                        else if (openFileDialog1.FileName.Contains("XMLSchemaVegetais"))
                        {
                            ValidateTXT();
                        }
                        else
                        {
                            MessageBox.Show("Path nao encontrado", "Caminho não Encontrado");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro, " + ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Não escolheu nenhum XML", "Erro");
            }
        }

        private void button_JSON_Click(object sender, EventArgs e)
        {
            if (path != null && extension.Equals(".js"))
            {
                try
                {
                    Json.ReadFile(path);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    ExcelHandler.ReadExcel(path);

                    string pathfile = System.IO.Directory.GetCurrentDirectory() + "\\XLMS";

                    if (Directory.Exists(pathfile))
                    {
                        MessageBox.Show("Directoria já existe", "Directoria", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Tenta criar a directoria
                        Directory.CreateDirectory(pathfile);
                    }
                    saveFileDialog1.InitialDirectory = pathfile;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        XmlTextWriter writer =
                            new XmlTextWriter(saveFileDialog1.FileName,
                                System.Text.Encoding.UTF8);

                        pathexercicios = saveFileDialog1.FileName;

                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("exercicios");



                        for (int i = 0; i <= Json.NomeList.Count - 1; i++)
                        {
                            createNodeJ(Json.NomeList[i], Json.CaloriasList[i], Json.MetList[i], writer);
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        MessageBox.Show("O ficheiro XML foi criado com sucesso ! ");


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro, " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Essa extensão não é suportada neste botão", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        private void createNodeJ(string nome, string calorias, string met, XmlTextWriter writer)
        {
            writer.WriteStartElement("exercicio");
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

        private void ValidateJson()
        {
            Boolean isValid = true;

            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, Environment.CurrentDirectory + "\\XSD\\XMLSchemaExercicios.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(textBox_path.Text, settings);
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

        private void button_TXT_Click(object sender, EventArgs e)
        {
            if (path != null && extension.Equals(".txt"))
            {
                try
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    Classtxtfile.Readfile(path);

                    string pathfile = System.IO.Directory.GetCurrentDirectory() + "\\XLMS";

                    if (Directory.Exists(pathfile))
                    {
                        MessageBox.Show("Directoria já existe", "Directoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Tenta criar a directoria
                        Directory.CreateDirectory(pathfile);
                    }
                    saveFileDialog1.InitialDirectory = pathfile;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        XmlTextWriter writer =
                            new XmlTextWriter(saveFileDialog1.FileName,
                                System.Text.Encoding.UTF8);

                        pathvegetais = saveFileDialog1.FileName;

                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("vegetais");

                        for (int i = 0; i <= Classtxtfile.Calorias.Count - 1; i++)
                        {
                            createNodeT(Classtxtfile.Calorias[i], Classtxtfile.Produtos[i], Classtxtfile.Quantidades[i],
                                writer);
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        MessageBox.Show("O ficheiro XML foi criado com sucesso ! ");

                    }
                }

                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Essa extensão não é suportada neste botão", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }



        private void createNodeT(string calorias, string nome, string quantidade, XmlTextWriter writer)
        {
            writer.WriteStartElement("vegetal");
            writer.WriteStartElement("calorias");
            writer.WriteString(calorias);
            writer.WriteEndElement();
            writer.WriteStartElement("nome");
            writer.WriteString(nome);
            writer.WriteEndElement();
            writer.WriteStartElement("quantidade");
            writer.WriteString(quantidade);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void ValidateTXT()
        {
            Boolean isValid = true;

            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, Environment.CurrentDirectory + "\\XSD\\XMLSchemaVegetais.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(textBox_path.Text, settings);
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
