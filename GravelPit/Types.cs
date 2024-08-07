using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static GravelPit.Localizer;

namespace GravelPit
{
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();

            saveButton.Text = GetTranslation("Save");
        }

        private void Types_Load(object sender, EventArgs e)
        {
            string dictionary = new HttpClient().GetStringAsync($"{MainUrl.Url}/api/GetTypes").Result;
            Dictionary<string, string> types = JsonSerializer.Deserialize<Dictionary<string, string>>(dictionary);

            Invoke(delegate
            {
                foreach (var type in types)
                {
                    RichTextBox richTextBox = new RichTextBox();
                    richTextBox.Text = type.Value;
                    richTextBox.Tag = type.Key;
                    richTextBox.Size = new Size(266, 24);
                    richTextBox.Multiline = false;

                    flowLayoutPanel1.Controls.Add(richTextBox);

                    Button deleteButton = new Button();
                    deleteButton.Text = "X";
                    deleteButton.Size = new Size(30, 23);
                    deleteButton.Location = new Point(355, 0);
                    deleteButton.FlatStyle = FlatStyle.Flat;
                    deleteButton.BackColor = Color.FromArgb(44, 46, 48);
                    deleteButton.ForeColor = Color.Red;
                    ToolTip deleteButtonToolTip = new ToolTip();
                    deleteButtonToolTip.SetToolTip(deleteButton, "Delete type.");
                    flowLayoutPanel1.Controls.Add(deleteButton);

                    Control[] controls = { richTextBox, deleteButton };
                    deleteButton.Click += (s, ev) => DeleteButton_Click(s, ev, controls);
                }
            });
        }
        private void DeleteButton_Click(object? sender, EventArgs e, Control[] controls)
        {
            foreach (var control in controls)
            {
                flowLayoutPanel1.Controls.Remove(control);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Text = "";
            richTextBox.Tag = "";
            richTextBox.Size = new Size(266, 24);

            flowLayoutPanel1.Controls.Add(richTextBox);

            Button deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.Size = new Size(30, 23);
            deleteButton.Location = new Point(355, 0);
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.BackColor = Color.FromArgb(44, 46, 48);
            deleteButton.ForeColor = Color.Red;
            ToolTip deleteButtonToolTip = new ToolTip();
            deleteButtonToolTip.SetToolTip(deleteButton, "Delete type.");
            flowLayoutPanel1.Controls.Add(deleteButton);

            Control[] controls = { richTextBox, deleteButton };
            deleteButton.Click += (s, ev) => DeleteButton_Click(s, ev, controls);

            flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
            flowLayoutPanel1.PerformLayout();

            richTextBox.Focus();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var types = new List<List<string>>();

            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control is RichTextBox textBox)
                {
                    if (textBox.Text == "")
                    {
                        MessageBox.Show(GetTranslation("EmptyTextbox"));
                        return;
                    }

                    types.Add(new List<string> { textBox.Tag.ToString(), textBox.Text });
                }
            }

            string json = JsonSerializer.Serialize(types, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            using (HttpClient client = new HttpClient())
            {
                string websiteUrl = $"{MainUrl.Url}/api/EditTypes";

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(websiteUrl, content).Result;
            }

            Close();
        }
    }
}
