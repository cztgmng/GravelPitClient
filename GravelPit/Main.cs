using GravelPit.Properties;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;
using static GravelPit.Add;
using static GravelPit.Localizer;
using static GravelPit.TextFormatting;

namespace GravelPit
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            monthCalendar1.MaxDate = DateTime.Today;
            monthCalendar2.MaxDate = DateTime.Today;
            richTextBox1.Text = $"Selection: {DateTime.Today:dd-MM-yyyy}";
            bulkEditButton.Visible = false;
        }
        private void LoadTranslations()
        {
            button1.Text = GetTranslation("Add");
            label1.Text = GetTranslation("Start");
            label2.Text = GetTranslation("End");
            button2.Text = GetTranslation("Search");
            label7.Text = GetTranslation("SearchPanel");
            button3.Text = GetTranslation("Export");
            button4.Text = GetTranslation("CheckingMode");
            SettledButton.Text = GetTranslation("Settled");
            NotSettledButton.Text = GetTranslation("NotSettled");
            toolStripDropDownButton1.Text = GetTranslation("Company");
            settingsDropDownButton.Text = GetTranslation("Settings");
            clientsToolStripMenuItem.Text = GetTranslation("Clients");
            richTextBox1.Text = $"{GetTranslation("Selection")}: {monthCalendar1.SelectionStart:dd-MM-yyyy}";
        }
        private void Main_Load(object sender, EventArgs e)
        {
            UpdateClients();

            LoadTranslations();

            englishButton.Click += (s, ev) => selectLanguage(s, ev, "en-EN");
            polishButton.Click += (s, ev) => selectLanguage(s, ev, "pl-PL");

            label9.Text = "v1.0.2.2";
        }
        public static async Task<Dictionary<string, string>> GetClientsList()
        {
            Console.WriteLine($"{MainUrl.Url}/api/GetClients");
            string clientsJson = await new HttpClient().GetStringAsync($"{MainUrl.Url}/api/GetClients");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(clientsJson);
        }
        private async void UpdateClients()
        {
            comboBox1.Items.Clear();

            comboBox1.Items.Add(GetTranslation("ClientsSummary"));

            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(this.Width + 50, this.Height + 50);
            panel1.Visible = true;

            var dictionary = await GetClientsList();

            string[] valuesArray = new string[dictionary.Values.Count];
            dictionary.Values.CopyTo(valuesArray, 0);

            await Invoke(async delegate
            {
                comboBox1.Items.AddRange(valuesArray);
            });

            panel1.Visible = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PreAdd().ShowDialog();
            UpdateClients();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            ChangeSelection();
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            ChangeSelection();
        }

        private void ChangeSelection()
        {
            if (monthCalendar1.SelectionStart.Date != monthCalendar2.SelectionStart.Date)
            {
                richTextBox1.Text = $"{GetTranslation("Start")}: {monthCalendar1.SelectionStart:dd-MM-yyyy} {GetTranslation("End")}: {monthCalendar2.SelectionStart:dd-MM-yyyy}";
            }
            else
            {
                richTextBox1.Text = $"{GetTranslation("Selection")}: {monthCalendar1.SelectionStart:dd-MM-yyyy}";
            }

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void ClearData()
        {
            foreach (Control control in mainPanel.Controls)
            {
                mainPanel.Controls.Remove(control);
            }
        }
        private static Dictionary<string, NewOrder> ordersDictionary = new();
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(MainUrl.Url);
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Client is empty.", "Error");
                return;
            }

            ordersDictionary.Clear();

            bulkEditButton.Visible = false;
            OrdersToEdit.Clear();

            richTextBox2.Text = $"";

            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(this.Width + 50, this.Height + 50);
            panel1.Visible = true;

            mainPanel.Controls.Clear();

            this.Width = 1168;

            string apiUrl = "";

            bool isTotal = comboBox1.Text == GetTranslation("ClientsSummary");

            if (isTotal)
            {
                apiUrl = $"{MainUrl.Url}/api/GetOrdersForPeriodOfTimeForAllClients?start={monthCalendar1.SelectionStart:yyyy-MM-dd}&end={monthCalendar2.SelectionStart:yyyy-MM-dd}";
            }
            else
            {
                apiUrl = $"{MainUrl.Url}/api/GetOrdersForPeriodOfTime?client={comboBox1.Text}&start={monthCalendar1.SelectionStart:yyyy-MM-dd}&end={monthCalendar2.SelectionStart:yyyy-MM-dd}";
            }

            string json = await Task.Run(async () =>
            {
                using HttpClient client = new();
                return await client.GetStringAsync(apiUrl);
            });
            List<NewOrder> orders = JsonSerializer.Deserialize<List<NewOrder>>(json);

            panel1.Visible = false;

            if (isTotal)
            {
                CreateTotalSummary(orders);
                return;
            }

            Dictionary<string, List<NewOrder>> data = new Dictionary<string, List<NewOrder>>();

            //int lastPos = 286;
            int lastPos = 0;

            Invoke(delegate
            {
                foreach (var order in orders)
                {
                    if (!data.ContainsKey(order.type))
                    {
                        data.Add(order.type, new List<NewOrder> { order });
                    }
                    else
                    {
                        data[order.type].Add(order);
                    }
                }

                foreach (var key in data.Keys)
                {
                    float sum = 0;

                    FlowLayoutPanel panelWithAll = new FlowLayoutPanel();
                    panelWithAll.BackColor = Color.FromArgb(39, 39, 39);
                    panelWithAll.ForeColor = Color.White;
                    panelWithAll.AutoScroll = false;
                    panelWithAll.Location = new Point(lastPos, 39);
                    lastPos += 230;
                    panelWithAll.Size = new Size(216, mainPanel.Height - 41);
                    panelWithAll.Resize += PanelWithAll_Resize;
                    panelWithAll.Tag = "panelWithAll";

                    FlowLayoutPanel panelWithOrders = new FlowLayoutPanel();
                    panelWithOrders.BackColor = Color.FromArgb(39, 39, 39);
                    panelWithOrders.ForeColor = Color.White;
                    panelWithOrders.AutoScroll = true;
                    panelWithOrders.Location = new Point(0, 20);
                    panelWithOrders.Size = new Size(216, panelWithAll.Size.Height - 45);

                    Label typeLabel = new Label();
                    typeLabel.Text = key;
                    typeLabel.Font = new Font("Segoe UI", 9);
                    typeLabel.Anchor = AnchorStyles.Bottom;
                    typeLabel.ForeColor = Color.White;

                    panelWithAll.Controls.Add(typeLabel);

                    foreach (var order in data[key])
                    {
                        sum += order.amount;

                        ordersDictionary.Add(order.id, order);

                        Button btn = new Button();
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.Size = new Size(185, 23);
                        btn.Margin = new Padding(3, 1, 3, 1);
                        btn.Font = new Font(FontFamily.GenericMonospace, btn.Font.Size);
                        btn.ForeColor = Color.White;

                        if (order.settled == 1)
                        {
                            btn.BackgroundImage = Resources.settled;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        btn.Tag = order.id;
                        btn.Click += Btn_Click;

                        btn.Text = $"{order.date:dd-MM-yyyy} {Format(order.amount.ToString())}";

                        panelWithOrders.Controls.Add(btn);
                    }

                    panelWithAll.Controls.Add(panelWithOrders);

                    Label summaryLabel = new Label();
                    summaryLabel.Text = Format(sum.ToString());
                    summaryLabel.Font = new Font("Segoe UI", 9);
                    summaryLabel.Anchor = AnchorStyles.Bottom;
                    summaryLabel.ForeColor = Color.White;
                    panelWithAll.Controls.Add(summaryLabel);

                    mainPanel.Controls.Add(panelWithAll);
                }
                richTextBox2.Text = $"{GetTranslation("ResultsFor")}: {comboBox1.Text}";
                richTextBox2.SelectAll();
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            });

            button3.Visible = true;
        }

        private void PanelWithAll_Resize(object? sender, EventArgs e)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            var panelWithOrders = panel.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
            panelWithOrders.Size = new Size(216, panel.Size.Height - 45);
        }

        private void CreateTotalSummary(List<NewOrder> orders)
        {
            var grouped = orders.GroupBy(order => order.client)
                         .ToDictionary(group => group.Key, group => group.ToList());

            var allTypes = orders.Select(order => order.type).Distinct().ToList();
            var summary = new List<string>();
            var totalAmounts = new Dictionary<string, decimal>();

            foreach (var type in allTypes)
            {
                totalAmounts[type] = 0;
            }

            foreach (var kvp in grouped)
            {
                string clientName = kvp.Key;

                var clientTypes = kvp.Value.Select(order => order.type).Distinct().ToList();

                var headerBuilder = new StringBuilder();
                headerBuilder.Append("<br><h2>").Append(clientName).Append("</h2><table style=\"margin-left: auto;margin-right: auto;\"><tr><th>LP</th>");
                foreach (var type in clientTypes)
                {
                    headerBuilder.Append("<th>").Append(type).Append("</th>");
                }
                headerBuilder.Append("</tr>");
                summary.Add(headerBuilder.ToString());

                var toAddAmounts = clientTypes.ToDictionary(type => type, type => new List<decimal>());

                foreach (var order in kvp.Value)
                {
                    if (toAddAmounts.ContainsKey(order.type))
                    {
                        toAddAmounts[order.type].Add((decimal)order.amount);
                    }
                }

                var sums = clientTypes.ToDictionary(type => type, type => toAddAmounts[type].Sum());

                var sb = new StringBuilder();
                int i = 0;
                while (toAddAmounts.Any(pair => pair.Value.Count > 0))
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{i + 1}.</td>");

                    foreach (var type in clientTypes)
                    {
                        if (toAddAmounts[type].Count > 0)
                        {
                            sb.AppendLine($"<td>{toAddAmounts[type][0]}</td>");
                            toAddAmounts[type].RemoveAt(0);
                        }
                        else
                        {
                            sb.AppendLine("<td></td>");
                        }
                    }

                    sb.AppendLine("</tr>");
                    i++;
                }

                var sumRowBuilder = new StringBuilder();
                sumRowBuilder.Append("<tr><th>Suma</th>");
                foreach (var type in clientTypes)
                {
                    sumRowBuilder.Append("<th>").Append(sums[type]).Append("</th>");
                }
                sumRowBuilder.Append("</tr></table>");
                summary.Add(sb.ToString() + sumRowBuilder.ToString());

                foreach (var type in clientTypes)
                {
                    totalAmounts[type] += sums[type];
                }
            }

            var totalSummaryBuilder = new StringBuilder();
            totalSummaryBuilder.Append("<style> table, th, td { border: 1px solid black; border-collapse: collapse; text-align: center; } th { width: 100px; } h2 { text-align: center; } </style> <h1 style=\"text-align: center;\">" + GetTranslation("ClientsSummary") + "</h1> <p style=\"text-align: center;margin-top: -15px;\">" + GetTranslation("From") + " ")
                               .Append(monthCalendar1.SelectionStart.ToString("dd-MM-yyyy"))
                               .Append($" {GetTranslation("To")} ")
                               .Append(monthCalendar2.SelectionStart.ToString("dd-MM-yyyy"))
                               .Append("</p> <br><br>")
                               .Append(string.Join(Environment.NewLine, summary))
                               .Append("<br><br><br><table style=\"margin-left: auto;margin-right: auto;\"><tr><th>TOTAL</th>");

            foreach (var type in allTypes)
            {
                totalSummaryBuilder.Append("<th>").Append(type).Append("</th>");
            }
            totalSummaryBuilder.Append("</tr><tr><th>Suma</th>");

            foreach (var type in allTypes)
            {
                totalSummaryBuilder.Append("<th>").Append(totalAmounts[type]).Append("</th>");
            }
            totalSummaryBuilder.Append("</tr></table></body></html>");

            File.WriteAllText("all.html", totalSummaryBuilder.ToString());

            using Process fileopener = new Process();
            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + "all.html" + "\"";
            fileopener.Start();
        }
        public static List<string> OrdersToEdit = new List<string>();
        public static bool needUpdate = false;
        private void Btn_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (checkingMode)
            {
                if (button.BackColor == Color.FromArgb(255, 39, 39, 39))
                {
                    button.BackColor = Color.Green;
                }
                else
                {
                    button.BackColor = Color.FromArgb(255, 39, 39, 39);
                }

                return;
            }

            if (Control.ModifierKeys.HasFlag(Keys.Shift))
            {
                if (button.BackColor == Color.FromArgb(255, 39, 39, 39))
                {
                    if (!OrdersToEdit.Contains(button.Tag.ToString()))
                        OrdersToEdit.Add(button.Tag.ToString());

                    button.BackColor = Color.Gray;
                }
                else
                {
                    if (OrdersToEdit.Contains(button.Tag.ToString()))
                        OrdersToEdit.Remove(button.Tag.ToString());

                    button.BackColor = Color.FromArgb(255, 39, 39, 39);
                }


                if (OrdersToEdit.Count > 0)
                    bulkEditButton.Visible = true;
                else
                    bulkEditButton.Visible = false;

                return;
            }

            foreach (var order in ordersDictionary)
            {
                if (order.Key == button.Tag)
                {
                    needUpdate = false;

                    new InfoBox(order.Value.id, order.Value.date, order.Value.client, order.Value.type, order.Value.amount, order.Value.settled, order.Value.added_date).ShowDialog();

                    if (needUpdate)
                        button2.PerformClick();

                    break;
                }
            }
        }

        private void UpdateSum(Label label, float value)
        {
            label.Text = Format((float.Parse(label.Text) + value).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Dictionary<string, decimal> sortedOrders = new Dictionary<string, decimal>();

            foreach (var order in ordersDictionary)
            {
                if (!sortedOrders.TryGetValue(order.Value.type, out decimal value))
                {
                    sortedOrders.Add(order.Value.type, (decimal)order.Value.amount);
                }
                else
                {
                    sortedOrders[order.Value.type] = value + (decimal)order.Value.amount;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var order in sortedOrders)
            {
                sb.Append($"<tr><td>{order.Key}</td><td>{TextFormatting.Format(order.Value.ToString())}</td></tr>");
            }

            string html = $@"
                <style>
                    table, th, td {{ border: 1px solid black; border-collapse: collapse; text-align: center; }}
                    th {{ width: 100px; }}
                </style>
                <h1 style='text-align: center;'>{richTextBox2.Text.Split(':')[1].Trim()}</h1>
                <p style='text-align: center; margin-top: -15px;'>{GetTranslation("From")} {monthCalendar1.SelectionStart:dd-MM-yyyy} {GetTranslation("To")} {monthCalendar2.SelectionStart:dd-MM-yyyy}</p>
                <br>
                <table style='margin-left: auto; margin-right: auto;'>
                <tr><th>{GetTranslation("Type")}</th><th>{GetTranslation("Amount")}</th></tr>{sb.ToString()}
                </table>
            ";

            File.WriteAllText("document.html", html);

            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + "document.html" + "\"";
            fileopener.Start();
        }
        private static bool checkingMode = false;
        private void button4_Click(object sender, EventArgs e)
        {
            checkingMode = !checkingMode;

            if (checkingMode)
            {
                button4.BackColor = Color.Green;
            }
            else
            {
                button4.BackColor = Color.White;

                foreach (Control control in this.Controls)
                {
                    if (control is FlowLayoutPanel)
                    {
                        foreach (Control control2 in control.Controls)
                        {
                            control2.BackColor = Color.FromArgb(255, 39, 39, 39);
                        }
                    }
                }
            }
        }

        private async void SettledButton_Click(object sender, EventArgs e)
        {
            string apiUrl = $"{MainUrl.Url}/api/SetSettled?client={comboBox1.Text}&start={monthCalendar1.SelectionStart:yyyy-MM-dd}&end={monthCalendar2.SelectionStart:yyyy-MM-dd}&settled=1";

            if (MessageBox.Show($"{GetTranslation("SetSettledP1")}\n{GetTranslation("SetSettledP2")} \"{comboBox1.Text}\" {GetTranslation("SetSettledP3")} {GetTranslation("From")} {monthCalendar1.SelectionStart:dd-MM-yyyy} {GetTranslation("To")} {monthCalendar2.SelectionStart:dd-MM-yyyy}\n({GetTranslation("SetSettledP4")}!)", $"{GetTranslation("AreYouSure")}?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await new HttpClient().GetStringAsync(apiUrl);
                button2.PerformClick();
            }
        }

        private async void NotSettledButton_Click(object sender, EventArgs e)
        {
            string apiUrl = $"{MainUrl.Url}/api/SetSettled?client={comboBox1.Text}&start={monthCalendar1.SelectionStart:yyyy-MM-dd}&end={monthCalendar2.SelectionStart:yyyy-MM-dd}&settled=0";

            if (MessageBox.Show($"{GetTranslation("SetSettledP1-2")}\n{GetTranslation("SetSettledP2")} \"{comboBox1.Text}\" {GetTranslation("SetSettledP3")} {GetTranslation("From")} {monthCalendar1.SelectionStart:dd-MM-yyyy} {GetTranslation("To")} {monthCalendar2.SelectionStart:dd-MM-yyyy}\n({GetTranslation("SetSettledP4")}!)", $"{GetTranslation("AreYouSure")}?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await new HttpClient().GetStringAsync(apiUrl);
                button2.PerformClick();
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            panel2.Height = this.Height - 131;
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Clients().ShowDialog();
            UpdateClients();
        }

        private void selectLanguage(object sender, EventArgs e, string language)
        {
            File.WriteAllText($"{Environment.GetEnvironmentVariable("APPDATA")}\\GravelPit\\lang.txt", language);

            var newCluture = new CultureInfo(language);
            newCluture.NumberFormat.NumberDecimalSeparator = ",";

            CultureInfo.CurrentCulture = newCluture;
            CultureInfo.CurrentUICulture = newCluture;
            LoadTranslations();

            if (!string.IsNullOrEmpty(comboBox1.Text))
                button2.PerformClick();
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Types().ShowDialog();
            UpdateClients();
        }

        private void bulkEditButton_Click(object sender, EventArgs e)
        {
            new BulkEdit(OrdersToEdit.Where(key => ordersDictionary.ContainsKey(key)).Select(key => ordersDictionary[key]).ToList()).ShowDialog();
            button2.PerformClick();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            foreach (var control in mainPanel.Controls)
            {
                ((FlowLayoutPanel)control).Height = mainPanel.Height - 41;
            }
        }
    }
}