using FinalExam.DB;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FinalExam.UI
{


    public partial class Form1 : Form
    {
        private readonly FinalExamDataDB _context = new();

        List<Worker> wlist = new();
        List<RepairType> rtlist = new();
        FinalExamDataDB fe = new();
        List<Trouble> trlist = new();
        Troubles trs;

        public Form1()
        {
            InitializeComponent();
            trs = new Troubles();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            foreach (var w in fe.Workers)
            {
                wlist.Add(w);
                comboBox1.Items.Add(w.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Január");
            comboBox1.Items.Add("Február");
            comboBox1.Items.Add("Március");
            comboBox1.Items.Add("Április");
            comboBox1.Items.Add("Május");
            comboBox1.Items.Add("Június");
            comboBox1.Items.Add("Július");
            comboBox1.Items.Add("Augusztus");
            comboBox1.Items.Add("Szeptember");
            comboBox1.Items.Add("Október");
            comboBox1.Items.Add("November");
            comboBox1.Items.Add("December");
            comboBox1.SelectedIndex = 0;

        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            foreach (var rt in fe.RepairTypes)
            {
                rtlist.Add(rt);
                comboBox1.Items.Add(rt.Description);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trlist.Clear();

            if (radioButton1.Checked)
            {
                foreach (var tr in fe.Troubles)
                {
                    if (tr.WorkerId == wlist[comboBox1.SelectedIndex].Id)
                    {
                        trlist.Add(tr);
                    }
                }
            }

            if (radioButton2.Checked)
            {
                foreach (var tr in fe.Troubles)
                {
                    if (tr.RepairDate.HasValue)
                    {
                        if (tr.RepairDate.Value.Month == comboBox1.SelectedIndex + 1)
                        {
                            trlist.Add(tr);
                        }
                    }
                }
            }

            if (radioButton3.Checked)
            {
                foreach (var tr in fe.Troubles)
                {
                    if (tr.WorkerId == rtlist[comboBox1.SelectedIndex].Id)
                    {
                        trlist.Add(tr);
                    }
                }
            }

            fill_listBox1();
        }


        private void fill_listBox1()
        {
            /*
            listBox1.Items.Clear();
            foreach (var tr in trlist)
            {
                listBox1.Items.Add(tr.PostalCode.ToString() + " " + tr.Street + " " + tr.Number);
            }
            */
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = trlist;
            // dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Troubles));
                    trs.TroubleList = trlist;
                    // XmlSerializer ser = new XmlSerializer(Trouble.GetType());
                    ser.Serialize(sw, trs);
                }
                MessageBox.Show("A file elkészült!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string jsonExport = JsonConvert.SerializeObject(trlist);
                File.WriteAllText(saveFileDialog1.FileName, jsonExport);
                MessageBox.Show("Az exportálás sikeres volt!");
            }
        }
    }
}