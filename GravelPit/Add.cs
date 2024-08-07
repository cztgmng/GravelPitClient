using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static GravelPit.Hashing;
using static GravelPit.TextFormatting;

namespace GravelPit
{
    public partial class Add : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        private string client;

        public Add(string client)
        {
            InitializeComponent();

            this.client = client;
        }
        private void Add_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = $"Client: {client}";
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            monthCalendar1.MaxDate = DateTime.Today;

            Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    label4.ForeColor = Color.Gray;
                    Thread.Sleep(500);
                    label4.ForeColor = Color.White;
                    Thread.Sleep(500);
                }

                label4.Visible = false;
            });

            if (((((ushort)GetKeyState(0x90)) & 0xffff) != 0) == false)
            {
                MessageBox.Show("Uwaga, numlock jest aktywny.");
            }

            string typesJson = new HttpClient().GetStringAsync($"{MainUrl.Url}/api/GetTypes").Result;
            Dictionary<string, string> types = JsonSerializer.Deserialize<Dictionary<string, string>>(typesJson);

            new List<string>(types.Values).ForEach(delegate (string type)
            {
                comboBox2.Items.Add(type);
            });
        }

        private static int id = 0;
        private Keys m_keyCode;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_keyCode = e.KeyCode;
            if (e.KeyCode != Keys.Enter)
                return;

            Button btn = new();
            btn.FlatStyle = FlatStyle.Flat;
            btn.Size = new Size(285, 23);
            btn.Margin = new Padding(3, 1, 3, 1);
            btn.Tag = id;
            btn.Click += Btn_Click;
            btn.Font = new Font(FontFamily.GenericMonospace, btn.Font.Size);

            string type = comboBox2.Text.Replace(" ","_");

            int length = (int)Math.Round((double)(19 - type.Length) / 2, 0);
            string space = new(' ', length);

            btn.Text = $"{monthCalendar1.SelectionStart:dd-MM-yyyy}{space}{type}{space}{Format(textBox1.Text)}";

            flowLayoutPanel1.Controls.Add(btn);
            textBox1.Text = "";
            id++;

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (((Button)control).Tag == clickedButton.Tag)
                {
                    flowLayoutPanel1.Controls.Remove(control);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.m_keyCode != Keys.Enter && textBox1.Text.Length == 2 && this.m_keyCode != Keys.Back && this.m_keyCode != Keys.Oemcomma)
            {
                textBox1.Text = $"{textBox1.Text},";
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
        public class NewOrder
        {
            public required string id { get; set; }
            public required DateTime date { get; set; }
            public required string client { get; set; }
            public required string type { get; set; }
            public required float amount { get; set; }
            public int settled { get; set; }
            public DateTime? added_date { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    if (MessageBox.Show("TextBox is not empty are you sure you want to send it to the server?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }

                panel1.Location = new Point(0, 0);
                panel1.Visible = true;

                List<NewOrder> list = new List<NewOrder>();
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    string[] parts = ((Button)control).Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    NewOrder newOrder = new()
                    {
                        id = Hash($"{parts[0]}{client}{parts[1]}{((Button)control).Tag}{new Random().Next()}"),
                        date = DateTime.ParseExact(parts[0], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        client = client,
                        type = parts[1],
                        amount = float.Parse(parts[2]),
                        settled = 0,
                        added_date = DateTime.Now
                    };

                    list.Add(newOrder);
                }

                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                using (HttpClient client = new HttpClient())
                {
                    string websiteUrl = $"{MainUrl.Url}/api/AddNewOrders";

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(websiteUrl, content).Result;
                }
                Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Error\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }
        }
    }
}
