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

namespace WheatEU
{
    public partial class Form1 : Form
    {
        private List<Country> adatok;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            adatok = new List<Country>();
            using(StreamReader sr = new StreamReader(openFileDialog.FileName))
            {
                string[] years = sr.ReadLine().Split(';');
                

                while(!sr.EndOfStream)
                {
                    Dictionary<string,double> evek=new Dictionary<string,double>();
                    
                    string[] line =sr.ReadLine().Split(';');
                    for(int i=1;i<years.Length;i++)
                    {
                        if (line[i] == ":")
                        {
                         evek.Add(years[i], double.NaN);
                        }
                        else
                        {
                        evek.Add(years[i], Convert.ToDouble(line[i]));
                        }
                    }
                    Country temp=new Country(line[0],evek);
                    adatok.Add(temp);
                }
            }
            FillGridView();


            

            
        }

        private void FillGridView()
        {
            dataGridView.RowCount= adatok.Count;
            dataGridView.ColumnCount = adatok[0].Data.Count;
            
       
            int i = 0;
            foreach(string key in adatok[0].Data.Keys)
            {
                dataGridView.Columns[i].HeaderCell.Value = key;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                i++;

            }

            
            for(int j = 0; j < adatok.Count; j++)
            {
                dataGridView.Rows[j].HeaderCell.Value = adatok[j].Name;
                
            }

            for(int j = 0; j < adatok.Count; j++)
            {

                for(int k = 0; k < adatok[j].Data.Count; k++)
                {
                    double n = adatok[j].Data[Convert.ToString(dataGridView.Columns[k].HeaderCell.Value)];
                    if (double.IsNaN(n))
                    {
                        dataGridView.Rows[j].Cells[k].Value = "-";
                    }
                    else
                    {
                        dataGridView.Rows[j].Cells[k].Value = n;
                    }
                    //dataGridView.Rows[j].Cells[k];
                }


            }


        }

        
    }
}
