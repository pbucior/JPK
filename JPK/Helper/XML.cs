using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace JPK
{
    public class XML
    {
        private static XmlSchemaSet pobierzSchematXSD(string xsd)
        {
            XmlSchemaSet schema = new XmlSchemaSet();

            string zawartosc = File.ReadAllText(xsd);
            XmlReader schemaDocument = XmlReader.Create(new StringReader(zawartosc));
            string schemaLink = schemaDocument.LookupNamespace("tns");
            schema.Add(schemaLink, schemaDocument);

            return schema;
        }

        public static string walidacjaInfo(string plik, string xsd)
        {
            StringBuilder tekstBledy = new StringBuilder();
            string info = "";
            int iloscBledow = 0;

            try
            {
                XmlSchemaSet schemaSet = pobierzSchematXSD(xsd);
                using (var stream = new FileStream(plik, FileMode.Open))
                {
                    var czyBlad = false;
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                    settings.Schemas.Add(schemaSet);
                    settings.ValidationEventHandler += (a, args) =>
                    {
                        czyBlad = true;
                        iloscBledow++;
                        tekstBledy.AppendLine($"{iloscBledow}. W wierszu {args.Exception.LineNumber}:");
                        tekstBledy.AppendLine($"{args.Message}");
                    };

                    stream.Seek(0, SeekOrigin.Begin);
                    XmlReader reader = XmlReader.Create(stream, settings);

                    while (reader.Read())
                    {
                    }
                    if (czyBlad)
                    {
                        string tekstIloscBledow = $"Plik {plik} zawiera następujące błedy:" + Environment.NewLine;
                        info = tekstIloscBledow + tekstBledy.ToString();
                    }
                    else
                    {
                        info = $"Plik {plik} nie zawiera błędów.";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "JPK");
            }
            return info;
        }

        public static bool walidacja(string plik, string xsd)
        {
            bool czyPlikOk = true;
            try
            {
                XmlSchemaSet schemaSet = pobierzSchematXSD(xsd);
                using (StreamReader streamReader = new StreamReader(plik, Encoding.UTF8))
                {
                    string zawartoscPliku = streamReader.ReadToEnd();
                    XDocument xdoc = new XDocument();
                    xdoc = XDocument.Parse(zawartoscPliku);

                    xdoc.Validate(schemaSet, (s, er) =>
                    {
                        czyPlikOk = false;
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "JPK");
            }
            return czyPlikOk;
        }
    }
}
