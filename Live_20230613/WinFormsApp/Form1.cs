namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adatok adatok = new();

            foreach (var item in adatok.Embers)
            {
                listBox1.Items.Add(item.Nev);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ember e2 = new Ember();
            e2.Nev = "Sanyi";
            e2.Szev = "2023";

            Adatok adatok = new();
            adatok.Embers.Add(e2);
            adatok.SaveChanges();

        }
    }
}