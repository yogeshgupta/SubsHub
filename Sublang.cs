using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace subhub
{
    public partial class Sublang : Form
    {          

        public Sublang()
        {
            InitializeComponent();
            string getLang = Properties.Settings.Default.langPref;
            switch (getLang)
            {
                case "eng":
                    English.Checked = true;
                    break;
                case "ara":
                    Arabic.Checked = true;
                    break;
                case "bul":
                    Bulgarian.Checked = true;
                    break;
                case "chi":
                    Chinese.Checked = true;
                    break;
                case "cze":
                    Czech.Checked = true;
                    break;
                case "dan":
                    Danish.Checked = true;
                    break;
                case "dut":
                    Dutch.Checked = true;
                    break;
                case "fin":
                    Finnish.Checked = true;
                    break;
                case "fre":
                    French.Checked = true;
                    break;
                case "ger":
                    Germany.Checked = true;
                    break;
                case "heb":
                    Hebrew.Checked = true;
                    break;
                case "hin":
                    Hindi.Checked = true;
                    break;
                case "hun":
                    Hungarian.Checked = true;
                    break;
                case "ita":
                    Italian.Checked = true;
                    break;
                case "jpn":
                    Japanese.Checked = true;
                    break;
                case "kot":
                    Korean.Checked = true;
                    break;
                case "lav":
                    Latvian.Checked = true;
                    break;
                case "pol":
                    Polish.Checked = true;
                    break;
                case "por":
                    Portugese.Checked = true;
                    break;
                case "rum":
                    Romanian.Checked = true;
                    break;
                case "rus":
                    Russian.Checked = true;
                    break;
                case "scc":
                    Serbian.Checked = true;
                    break;
                case "slv":
                    Slovenian.Checked = true;
                    break;
                case "spa":
                    Spanish.Checked = true;
                    break;
                case "swe":
                    Swedish.Checked = true;
                    break;
                case "tha":
                    Thai.Checked = true;
                    break;
                case "tur":
                    Turkish.Checked = true;
                    break;
                case "urd":
                    Urdu.Checked = true;
                    break;
                case "ukr":
                    Ukranian.Checked = true;
                    break;
                case "vie":
                    Vienamese.Checked = true;
                    break;

            }
        }

        public void Selectbtn_Click(object sender, EventArgs e)
        {
            string langsub="eng";
            
            if (English.Checked)
                    langsub = "eng";
                else if (Arabic.Checked)
                    langsub = "ara";
                else if (Bulgarian.Checked)
                    langsub = "bul";
                else if (Chinese.Checked)
                    langsub = "chi";
                else if (Czech.Checked)
                    langsub = "cze";
                else if (Danish.Checked)
                    langsub = "dan";
                else if (Dutch.Checked)
                    langsub = "dut";
                else if (Finnish.Checked)
                    langsub = "fin";
                else if (French.Checked)
                    langsub = "fre";
                else if (Germany.Checked)
                    langsub = "ger";
                else if (Hebrew.Checked)
                    langsub = "heb";
                else if (Hindi.Checked)
                    langsub = "hin";
                else if (Hungarian.Checked)
                    langsub = "hun";
                else if (Italian.Checked)
                    langsub = "ita";
                else if (Japanese.Checked)
                    langsub = "jpn";
                else if (Korean.Checked)
                    langsub = "kot";
                else if (Latvian.Checked)
                    langsub = "lav";
                else if (Polish.Checked)
                    langsub = "pol";
                else if (Portugese.Checked)
                    langsub = "por";
                else if (Romanian.Checked)
                    langsub = "rum";
                else if (Russian.Checked)
                    langsub = "rus";
                else if (Serbian.Checked)
                    langsub = "scc";
                else if (Slovenian.Checked)
                    langsub = "slv";
                else if (Spanish.Checked)
                    langsub = "spa";
                else if (Swedish.Checked)
                    langsub = "swe";
                else if (Thai.Checked)
                    langsub = "tha";
                else if (Turkish.Checked)
                    langsub = "tur";
                else if (Urdu.Checked)
                    langsub = "urd";
                else if (Ukranian.Checked)
                    langsub = "ukr";
                else if (Vienamese.Checked)
                    langsub = "vie";

            Properties.Settings.Default.langPref = langsub;
            Properties.Settings.Default.Save();            
            Close();
        }


    }
}
