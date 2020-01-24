using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace JPK
{
    public partial class PodgladZakupy : Window
    {
        public PodgladZakupy(string plikXML)
        {
            InitializeComponent();

            XDocument xDocument = XDocument.Load(plikXML);
            var tns = xDocument.Root.Name.Namespace;

            var query = xDocument.Descendants(tns + "ZakupWiersz").Select(c => new
            {
                LpZakupu = (c.Element(tns + "LpZakupu") != null) ? c.Element(tns + "LpZakupu").Value : "",
                NrDostawcy = (c.Element(tns + "NrDostawcy") != null) ? c.Element(tns + "NrDostawcy").Value : "",
                NazwaDostawcy = (c.Element(tns + "NazwaDostawcy") != null) ? c.Element(tns + "NazwaDostawcy").Value : "",
                AdresDostawcy = (c.Element(tns + "AdresDostawcy") != null) ? c.Element(tns + "AdresDostawcy").Value : "",
                DowodZakupu = (c.Element(tns + "DowodZakupu") != null) ? c.Element(tns + "DowodZakupu").Value : "",
                DataZakupu = (c.Element(tns + "DataZakupu") != null) ? c.Element(tns + "DataZakupu").Value : "",
                DataWplywu = (c.Element(tns + "DataWplywu") != null) ? c.Element(tns + "DataWplywu").Value : "",
                K_43 = (c.Element(tns + "K_43") != null) ? c.Element(tns + "K_43").Value : "",
                K_44 = (c.Element(tns + "K_44") != null) ? c.Element(tns + "K_44").Value : "",
                K_45 = (c.Element(tns + "K_45") != null) ? c.Element(tns + "K_45").Value : "",
                K_46 = (c.Element(tns + "K_46") != null) ? c.Element(tns + "K_46").Value : "",
                K_47 = (c.Element(tns + "K_47") != null) ? c.Element(tns + "K_47").Value : "",
                K_48 = (c.Element(tns + "K_48") != null) ? c.Element(tns + "K_48").Value : "",
                K_49 = (c.Element(tns + "K_49") != null) ? c.Element(tns + "K_49").Value : "",
                K_50 = (c.Element(tns + "K_50") != null) ? c.Element(tns + "K_50").Value : ""
            });

            dataGridZakupy.ItemsSource = query;
        }
    }
}
