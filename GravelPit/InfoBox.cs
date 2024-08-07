using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static GravelPit.Add;
using static GravelPit.Localizer;

namespace GravelPit
{
    public partial class InfoBox : Form
    {
        private string id;
        private string _client;
        private string _type;
        public InfoBox(string id, DateTime date, string client, string type, double amount, int settled, DateTime? added_date)
        {
            InitializeComponent();

            this.id = id;
            this._client = client;
            this._type = type;

            textBox1.Text = id;
            textBox2.Text = $"{date:dd-MM-yyyy}";
            textBox5.Text = amount.ToString();
            if (settled == 1)
                checkBox1.Checked = true;
            textBox3.Text = $"{added_date:dd-MM-yyyy HH:mm:ss}";

            button2.Text = GetTranslation("CopyID");
            button3.Text = GetTranslation("Save");
            label2.Text = GetTranslation("Date");
            label3.Text = GetTranslation("Client");
            label4.Text = GetTranslation("Type");
            label5.Text = GetTranslation("Amount");
            button1.Text = GetTranslation("Delete");
            label7.Text = GetTranslation("Settled");
            label8.Text = GetTranslation("AddedDate");
        }

        [STAThread]
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new()
            {
                id = id,
                date = DateTime.ParseExact(textBox2.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                client = comboBox1.Text,
                type = comboBox2.Text,
                amount = float.Parse(textBox5.Text),
                settled = checkBox1.Checked ? 1 : 0,
                added_date = DateTime.Now
            };

            string json = JsonSerializer.Serialize(newOrder, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            using (HttpClient client = new HttpClient())
            {
                string websiteUrl = $"{MainUrl.Url}/api/EditOrder";

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(websiteUrl, content).Result;
            }

            Main.needUpdate = true;

            Close();
        }

        private async void InfoBox_Load(object sender, EventArgs e)
        {
            //clients
            var dictionary = await Main.GetClientsList();

            Invoke(delegate
            {
                comboBox1.Items.AddRange(dictionary.Values.ToArray());
            });

            comboBox1.SelectedItem = _client;

            //types
            string typesJson = new HttpClient().GetStringAsync($"{MainUrl.Url}/api/GetTypes").Result;
            Dictionary<string, string> types = JsonSerializer.Deserialize<Dictionary<string, string>>(typesJson);

            Invoke(delegate
            {
                comboBox2.Items.AddRange(types.Values.ToArray());
            });
            comboBox2.SelectedItem = _type;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize(id, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            using (HttpClient client = new HttpClient())
            {
                string websiteUrl = $"{MainUrl.Url}/api/DeleteOrder";

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(websiteUrl, content).Result;
            }

            Main.needUpdate = true;

            Close();
        }
    }
}
