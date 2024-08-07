using System.Data;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static GravelPit.Add;
using static GravelPit.Localizer;

namespace GravelPit
{
    public partial class BulkEdit : Form
    {
        private List<NewOrder> _orders;
        public BulkEdit(List<NewOrder> orders)
        {
            InitializeComponent();

            _orders = orders;

            button2.Text = GetTranslation("CopyID");
            button3.Text = GetTranslation("Save");
            label2.Text = GetTranslation("Date");
            label3.Text = GetTranslation("Client");
            label4.Text = GetTranslation("Type");
            label5.Text = GetTranslation("Amount");
            button1.Text = GetTranslation("Delete");
        }

        private async void BulkEdit_Load(object sender, EventArgs e)
        {
            //clients
            var dictionary = await Main.GetClientsList();

            Invoke(delegate
            {
                comboBox1.Items.AddRange(dictionary.Values.ToArray());
            });

            //types
            string typesJson = new HttpClient().GetStringAsync($"{MainUrl.Url}/api/GetTypes").Result;

            Invoke(delegate
            {
                comboBox2.Items.AddRange(JsonSerializer.Deserialize<Dictionary<string, string>>(typesJson).Values.ToArray());
            });

            List<DateTime> dates = new();
            List<string> clients = new();
            List<string> types = new();
            List<float> amounts = new();

            foreach (var order in _orders)
            {
                if (!dates.Contains(order.date))
                    dates.Add(order.date);

                if (!clients.Contains(order.client))
                    clients.Add(order.client);

                if (!types.Contains(order.type))
                    types.Add(order.type);

                if (!amounts.Contains(order.amount))
                    amounts.Add(order.amount);
            }

            textBox1.Text = string.Join(",", _orders.Select(order => order.id));

            if (dates.Count > 1)
            {
                textBox2.Text = "Multiple Values";
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Text = $"{dates.First():dd-MM-yyyy}";
            }

            if (clients.Count > 1)
            {
                comboBox1.Text = "Multiple Values";
            }
            else
            {
                comboBox1.SelectedItem = $"{clients.First()}";
            }

            if (types.Count > 1)
            {
                comboBox2.Text = "Multiple Values";
            }
            else
            {
                comboBox2.SelectedItem = $"{types.First()}";
            }

            if (amounts.Count > 1)
            {
                textBox5.Text = "Multiple Values";
            }
            else
            {
                textBox5.Text = $"{amounts.First()}";
            }

            string json = JsonSerializer.Serialize(_orders, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var updatedOrders = new List<NewOrder>();

            foreach (var order in _orders)
            {
                DateTime updatedDate = textBox2.Text == "Multiple Values"
                ? order.date
                : DateTime.ParseExact(textBox2.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string updatedClient = comboBox1.Text == "Multiple Values"
                    ? order.client
                    : comboBox1.Text;

                string updatedType = comboBox2.Text == "Multiple Values"
                    ? order.type
                    : comboBox2.Text;

                float updatedAmount = textBox5.Text == "Multiple Values"
                    ? order.amount
                    : float.Parse(textBox5.Text);

                var updatedOrder = new NewOrder
                {
                    id = order.id,
                    date = updatedDate,
                    client = updatedClient,
                    type = updatedType,
                    amount = updatedAmount,
                    settled = order.settled,
                    added_date = order.added_date
                };

                updatedOrders.Add(updatedOrder);
            }

            string json = JsonSerializer.Serialize(updatedOrders, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            using (HttpClient client = new HttpClient())
            {
                string websiteUrl = $"{MainUrl.Url}/api/EditOrders";
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(websiteUrl, content);
            }

            Close();
        }
    }
}
