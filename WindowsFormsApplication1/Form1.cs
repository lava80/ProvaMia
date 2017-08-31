using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Prodotti pr = new Prodotti(DateTime.Now.AddMonths(-1), DateTime.Now);

            //for (int i = 0; i < pr.Count; i++)
            //{
            //    Prodotto pr1 = new Prodotto(pr[i].NIM, pr[i].ProdTime);
               
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> cons = new List<string>();
            cons.Add("r");
            cons.Add("n");
            cons.Add("c");
            cons.Add("c");
            cons.Add("m");
            cons.Add("b");
            cons.Add("h");

            List<string> vocs = new List<string>();
            vocs.Add("u");
            vocs.Add("i");
            vocs.Add("o");
            vocs.Add("a");
            vocs.Add("e");

            StringBuilder strb = new StringBuilder();

            foreach (string con in cons)
            {
                foreach (string voc in vocs)
                {
                    foreach (string con1 in cons)
                    {
                        foreach (string voc2 in vocs)
                        {
                            strb.Remove(0, strb.ToString().Length);
                            strb.Append(con);
                            strb.Append(voc);
                            strb.Append(con1);
                            strb.Append(voc2);
                            Console.WriteLine(strb.ToString());
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            OdbcConnection con = new OdbcConnection("DSN=valtra");

            OdbcDataAdapter da = new OdbcDataAdapter();
            da.SelectCommand = new OdbcCommand("select * from ev_lanci limit 100", con);

            da.Fill(ds, "Table_Prova");

            MessageBox.Show("numero righe: " + ds.Tables["Table_Prova"].Rows.Count);
        }
    }
}
