using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace JPK
{
    public partial class PodgladSprzedaz : Window
    {
        public PodgladSprzedaz(string plikXML)
        {
            InitializeComponent();

            XDocument xDocument = XDocument.Load(plikXML);
            var tns = xDocument.Root.Name.Namespace;

            var query = xDocument.Descendants(tns + "SprzedazWiersz").Select(c => new
            {
                LpSprzedazy = (c.Element(tns + "LpSprzedazy") != null) ? c.Element(tns + "LpSprzedazy").Value : "",
                NrKontrahenta = (c.Element(tns + "NrKontrahenta") != null) ? c.Element(tns + "NrKontrahenta").Value : "",
                NazwaKontrahenta = (c.Element(tns + "NazwaKontrahenta") != null) ? c.Element(tns + "NazwaKontrahenta").Value : "",
                AdresKontrahenta = (c.Element(tns + "AdresKontrahenta") != null) ? c.Element(tns + "AdresKontrahenta").Value : "",
                DowodSprzedazy = (c.Element(tns + "DowodSprzedazy") != null) ? c.Element(tns + "DowodSprzedazy").Value : "",
                DataWystawienia = (c.Element(tns + "DataWystawienia") != null) ? c.Element(tns + "DataWystawienia").Value : "",
                DataSprzedazy = (c.Element(tns + "DataSprzedazy") != null) ? c.Element(tns + "DataSprzedazy").Value : "",
                K_10 = (c.Element(tns + "K_10") != null) ? c.Element(tns + "K_10").Value : "",
                K_11 = (c.Element(tns + "K_11") != null) ? c.Element(tns + "K_11").Value : "",
                K_12 = (c.Element(tns + "K_12") != null) ? c.Element(tns + "K_12").Value : "",
                K_13 = (c.Element(tns + "K_13") != null) ? c.Element(tns + "K_13").Value : "",
                K_14 = (c.Element(tns + "K_14") != null) ? c.Element(tns + "K_14").Value : "",
                K_15 = (c.Element(tns + "K_15") != null) ? c.Element(tns + "K_15").Value : "",
                K_16 = (c.Element(tns + "K_16") != null) ? c.Element(tns + "K_16").Value : "",
                K_17 = (c.Element(tns + "K_17") != null) ? c.Element(tns + "K_17").Value : "",
                K_18 = (c.Element(tns + "K_18") != null) ? c.Element(tns + "K_18").Value : "",
                K_19 = (c.Element(tns + "K_19") != null) ? c.Element(tns + "K_19").Value : "",
                K_20 = (c.Element(tns + "K_20") != null) ? c.Element(tns + "K_20").Value : "",
                K_21 = (c.Element(tns + "K_21") != null) ? c.Element(tns + "K_21").Value : "",
                K_22 = (c.Element(tns + "K_22") != null) ? c.Element(tns + "K_22").Value : "",
                K_23 = (c.Element(tns + "K_23") != null) ? c.Element(tns + "K_23").Value : "",
                K_24 = (c.Element(tns + "K_24") != null) ? c.Element(tns + "K_24").Value : "",
                K_25 = (c.Element(tns + "K_25") != null) ? c.Element(tns + "K_25").Value : "",
                K_26 = (c.Element(tns + "K_26") != null) ? c.Element(tns + "K_26").Value : "",
                K_27 = (c.Element(tns + "K_27") != null) ? c.Element(tns + "K_27").Value : "",
                K_28 = (c.Element(tns + "K_28") != null) ? c.Element(tns + "K_28").Value : "",
                K_29 = (c.Element(tns + "K_29") != null) ? c.Element(tns + "K_29").Value : "",
                K_30 = (c.Element(tns + "K_30") != null) ? c.Element(tns + "K_30").Value : "",
                K_31 = (c.Element(tns + "K_31") != null) ? c.Element(tns + "K_31").Value : "",
                K_32 = (c.Element(tns + "K_32") != null) ? c.Element(tns + "K_32").Value : "",
                K_33 = (c.Element(tns + "K_33") != null) ? c.Element(tns + "K_33").Value : "",
                K_34 = (c.Element(tns + "K_34") != null) ? c.Element(tns + "K_34").Value : "",
                K_35 = (c.Element(tns + "K_35") != null) ? c.Element(tns + "K_35").Value : "",
                K_36 = (c.Element(tns + "K_36") != null) ? c.Element(tns + "K_36").Value : "",
                K_37 = (c.Element(tns + "K_37") != null) ? c.Element(tns + "K_37").Value : "",
                K_38 = (c.Element(tns + "K_38") != null) ? c.Element(tns + "K_38").Value : "",
                K_39 = (c.Element(tns + "K_39") != null) ? c.Element(tns + "K_39").Value : ""
            });

            dataGridSprzedaz.ItemsSource = query;
        }
    }
}
