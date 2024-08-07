namespace GravelPit
{
    public partial class PreAdd : Form
    {
        public PreAdd()
        {
            InitializeComponent();
        }

        private async void PreAdd_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, 0);
            panel1.Visible = true;

            var dictionary = await Main.GetClientsList();
            List<string> clients = new List<string>(dictionary.Values);

            Invoke(delegate
            {
                clients.ForEach(delegate (string client)
                {
                    comboBox1.Items.Add(client);
                });
            });

            Controls.Remove(panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("client is empty!");
                return;
            }

            this.Hide();
            new Add(comboBox1.Text).ShowDialog();
            this.Close();
        }
    }
}
