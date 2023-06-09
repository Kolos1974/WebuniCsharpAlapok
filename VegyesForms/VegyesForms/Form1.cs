namespace VegyesForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello WinForms");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            // MessageBox.Show("Megjött az egér");

        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Megjött az egér X: {e.X} Y: {e.Y} ");
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            //
        }

        private void EgeretHuzogatnak(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                MessageBox.Show("Gombra jöttek");
            }
            else
            {
                MessageBox.Show("Labelre jöttek");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Ember> emb = new List<Ember>();
            Ember e1 = new Ember();
            e1.Nev = "Peti";
            e1.SzEv = 1999;

            Ember e2 = new Ember();
            e2.Nev = "Kati";
            e2.SzEv = 2002;

            emb.Add(e1);
            emb.Add(e2);
            /*
            foreach(Ember em in  emb)
            {
                listBox1.Items.Add(em);
            }
            */

            listBox1.DataSource = emb;

            listBox1.DisplayMember = "Nev";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button b5 = new Button();
            b5.Top = 100;
            b5.Left = 100;
            this.Controls.Add(b5);

            ColorDialog cd2 = new ColorDialog();
            cd2.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button4.Text += 'a';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Form3 f3 = new Form3();

            
            f3.Show();

            if (f2.ShowDialog() == DialogResult.Yes)
            {
                MessageBox.Show("IGEN");
            }

        }
    }
}