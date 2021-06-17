using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CotacaoDolarHG
{
    public partial class frmCotacaoDolar : Form
    {
        public frmCotacaoDolar()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmCotacaoDolar_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strucURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=9cfc615f";
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Retorna um http Response Message, por isso o tipo da variável é var
                    //(o tipo poderia ser HttpResponseMessage)
                    var response = client.GetAsync(strucURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //PEGA A STRING EM JSON
                        var result = response.Content.ReadAsStringAsync().Result;

                        //DESSERIALIZA O JSON DENTRO DO OBJETO market QUE CHAMA A CLASSE Currency
                        Market market = JsonConvert.DeserializeObject<Market>(result);

                        lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Buy);
                        lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Sell);
                        lblVar.Text = string.Format(CultureInfo.GetCultureInfo("pr-BR"), "{0:P}", market.Currency.Variation / 100);

                    }
                    else
                    {
                        lblBuy.Text = "-";
                        lblSell.Text = "-";
                        lblVar.Text = "-";
                    }
                    
                }
                catch (Exception ex)
                {
                    lblBuy.Text = "-";
                    lblSell.Text = "-";
                    lblVar.Text = "-";

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
