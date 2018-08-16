namespace BitmexSampleBotGoran
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.nupQty = new System.Windows.Forms.NumericUpDown();
            this.chkCancelWhileOrdering = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddOrderType = new System.Windows.Forms.ComboBox();
            this.ddNetwork = new System.Windows.Forms.ComboBox();
            this.ddlSymbol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMA2 = new System.Windows.Forms.NumericUpDown();
            this.nudMA1 = new System.Windows.Forms.NumericUpDown();
            this.chkUpdateCandles = new System.Windows.Forms.CheckBox();
            this.dgvCandles = new System.Windows.Forms.DataGridView();
            this.ddlCandleTimes = new System.Windows.Forms.ComboBox();
            this.tmrCandleUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSettingsWebsocketInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlAutoOrderType = new System.Windows.Forms.ComboBox();
            this.nudAutoQuantity = new System.Windows.Forms.NumericUpDown();
            this.rdoSwitch = new System.Windows.Forms.RadioButton();
            this.rdoSell = new System.Windows.Forms.RadioButton();
            this.rdoBuy = new System.Windows.Forms.RadioButton();
            this.btnAutomatedTrading = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tmrAutotradeExecution = new System.Windows.Forms.Timer(this.components);
            this.nudCurrentPrice = new System.Windows.Forms.NumericUpDown();
            this.tmrClientUpdates = new System.Windows.Forms.Timer(this.components);
            this.Heartbeat = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBalanceAndTime = new System.Windows.Forms.Label();
            this.chkOverloadRetry = new System.Windows.Forms.CheckBox();
            this.nudOverloadRetryAttempts = new System.Windows.Forms.NumericUpDown();
            this.lblOverloadRetryAttempts = new System.Windows.Forms.Label();
            this.nudPercentEarn = new System.Windows.Forms.NumericUpDown();
            this.lblPrcEarn = new System.Windows.Forms.Label();
            this.nudPercentToTrade = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPrice)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverloadRetryAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentEarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentToTrade)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuy.Location = new System.Drawing.Point(12, 115);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSell.Location = new System.Drawing.Point(379, 115);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // nupQty
            // 
            this.nupQty.Enabled = false;
            this.nupQty.Location = new System.Drawing.Point(169, 131);
            this.nupQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupQty.Name = "nupQty";
            this.nupQty.Size = new System.Drawing.Size(120, 20);
            this.nupQty.TabIndex = 2;
            this.nupQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkCancelWhileOrdering
            // 
            this.chkCancelWhileOrdering.AutoSize = true;
            this.chkCancelWhileOrdering.Checked = true;
            this.chkCancelWhileOrdering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCancelWhileOrdering.Location = new System.Drawing.Point(12, 168);
            this.chkCancelWhileOrdering.Name = "chkCancelWhileOrdering";
            this.chkCancelWhileOrdering.Size = new System.Drawing.Size(132, 17);
            this.chkCancelWhileOrdering.TabIndex = 3;
            this.chkCancelWhileOrdering.Text = "Cancel While Ordering";
            this.chkCancelWhileOrdering.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancel.Location = new System.Drawing.Point(379, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ddOrderType
            // 
            this.ddOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddOrderType.FormattingEnabled = true;
            this.ddOrderType.Items.AddRange(new object[] {
            "Market",
            "Limit Post Only"});
            this.ddOrderType.Location = new System.Drawing.Point(12, 48);
            this.ddOrderType.Name = "ddOrderType";
            this.ddOrderType.Size = new System.Drawing.Size(121, 21);
            this.ddOrderType.TabIndex = 5;
            this.ddOrderType.SelectedIndexChanged += new System.EventHandler(this.ddOrderType_SelectedIndexChanged);
            // 
            // ddNetwork
            // 
            this.ddNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddNetwork.FormattingEnabled = true;
            this.ddNetwork.Items.AddRange(new object[] {
            "TestNet",
            "RealNet"});
            this.ddNetwork.Location = new System.Drawing.Point(333, 48);
            this.ddNetwork.Name = "ddNetwork";
            this.ddNetwork.Size = new System.Drawing.Size(121, 21);
            this.ddNetwork.TabIndex = 6;
            this.ddNetwork.SelectedIndexChanged += new System.EventHandler(this.ddNetwork_SelectedIndexChanged);
            // 
            // ddlSymbol
            // 
            this.ddlSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSymbol.Enabled = false;
            this.ddlSymbol.FormattingEnabled = true;
            this.ddlSymbol.Location = new System.Drawing.Point(169, 48);
            this.ddlSymbol.Name = "ddlSymbol";
            this.ddlSymbol.Size = new System.Drawing.Size(121, 21);
            this.ddlSymbol.TabIndex = 7;
            this.ddlSymbol.SelectedIndexChanged += new System.EventHandler(this.ddlSymbol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Order Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Symbol and Current Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Network";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSettingsWebsocketInfo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudMA2);
            this.groupBox1.Controls.Add(this.nudMA1);
            this.groupBox1.Controls.Add(this.chkUpdateCandles);
            this.groupBox1.Controls.Add(this.dgvCandles);
            this.groupBox1.Controls.Add(this.ddlCandleTimes);
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1398, 236);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Candles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MA 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "MA 1";
            // 
            // nudMA2
            // 
            this.nudMA2.Location = new System.Drawing.Point(444, 19);
            this.nudMA2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMA2.Name = "nudMA2";
            this.nudMA2.Size = new System.Drawing.Size(44, 20);
            this.nudMA2.TabIndex = 6;
            this.nudMA2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudMA1
            // 
            this.nudMA1.Location = new System.Drawing.Point(321, 20);
            this.nudMA1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMA1.Name = "nudMA1";
            this.nudMA1.Size = new System.Drawing.Size(44, 20);
            this.nudMA1.TabIndex = 5;
            this.nudMA1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkUpdateCandles
            // 
            this.chkUpdateCandles.AutoSize = true;
            this.chkUpdateCandles.Checked = true;
            this.chkUpdateCandles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateCandles.Location = new System.Drawing.Point(157, 22);
            this.chkUpdateCandles.Name = "chkUpdateCandles";
            this.chkUpdateCandles.Size = new System.Drawing.Size(111, 17);
            this.chkUpdateCandles.TabIndex = 4;
            this.chkUpdateCandles.Text = "Update Every 10s";
            this.chkUpdateCandles.UseVisualStyleBackColor = true;
            this.chkUpdateCandles.CheckedChanged += new System.EventHandler(this.chkUpdateCandles_CheckedChanged);
            // 
            // dgvCandles
            // 
            this.dgvCandles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCandles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCandles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandles.Location = new System.Drawing.Point(7, 48);
            this.dgvCandles.Name = "dgvCandles";
            this.dgvCandles.RowHeadersWidth = 4;
            this.dgvCandles.Size = new System.Drawing.Size(1385, 188);
            this.dgvCandles.TabIndex = 3;
            // 
            // ddlCandleTimes
            // 
            this.ddlCandleTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCandleTimes.FormattingEnabled = true;
            this.ddlCandleTimes.Items.AddRange(new object[] {
            "1m",
            "5m",
            "1h",
            "1d"});
            this.ddlCandleTimes.Location = new System.Drawing.Point(7, 20);
            this.ddlCandleTimes.Name = "ddlCandleTimes";
            this.ddlCandleTimes.Size = new System.Drawing.Size(121, 21);
            this.ddlCandleTimes.TabIndex = 0;
            this.ddlCandleTimes.SelectedIndexChanged += new System.EventHandler(this.ddlCandleTimes_SelectedIndexChanged);
            // 
            // tmrCandleUpdater
            // 
            this.tmrCandleUpdater.Interval = 10000;
            this.tmrCandleUpdater.Tick += new System.EventHandler(this.tmrCandleUpdater_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.nudPercentToTrade);
            this.groupBox2.Controls.Add(this.lblPrcEarn);
            this.groupBox2.Controls.Add(this.nudPercentEarn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ddlAutoOrderType);
            this.groupBox2.Controls.Add(this.nudAutoQuantity);
            this.groupBox2.Controls.Add(this.rdoSwitch);
            this.groupBox2.Controls.Add(this.rdoSell);
            this.groupBox2.Controls.Add(this.rdoBuy);
            this.groupBox2.Controls.Add(this.btnAutomatedTrading);
            this.groupBox2.Location = new System.Drawing.Point(648, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 106);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automated Trading";
            // 
            // lblSettingsWebsocketInfo
            // 
            this.lblSettingsWebsocketInfo.AutoSize = true;
            this.lblSettingsWebsocketInfo.Location = new System.Drawing.Point(576, 21);
            this.lblSettingsWebsocketInfo.Name = "lblSettingsWebsocketInfo";
            this.lblSettingsWebsocketInfo.Size = new System.Drawing.Size(89, 13);
            this.lblSettingsWebsocketInfo.TabIndex = 6;
            this.lblSettingsWebsocketInfo.Text = "Websocket Info: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Qty for AutoTrading";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Order Type";
            // 
            // ddlAutoOrderType
            // 
            this.ddlAutoOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAutoOrderType.FormattingEnabled = true;
            this.ddlAutoOrderType.Items.AddRange(new object[] {
            "Market",
            "Limit Post Only"});
            this.ddlAutoOrderType.Location = new System.Drawing.Point(324, 32);
            this.ddlAutoOrderType.Name = "ddlAutoOrderType";
            this.ddlAutoOrderType.Size = new System.Drawing.Size(121, 21);
            this.ddlAutoOrderType.TabIndex = 5;
            // 
            // nudAutoQuantity
            // 
            this.nudAutoQuantity.Enabled = false;
            this.nudAutoQuantity.Location = new System.Drawing.Point(324, 82);
            this.nudAutoQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAutoQuantity.Name = "nudAutoQuantity";
            this.nudAutoQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudAutoQuantity.TabIndex = 4;
            this.nudAutoQuantity.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // rdoSwitch
            // 
            this.rdoSwitch.AutoSize = true;
            this.rdoSwitch.Location = new System.Drawing.Point(125, 76);
            this.rdoSwitch.Name = "rdoSwitch";
            this.rdoSwitch.Size = new System.Drawing.Size(57, 17);
            this.rdoSwitch.TabIndex = 3;
            this.rdoSwitch.Text = "Switch";
            this.rdoSwitch.UseVisualStyleBackColor = true;
            // 
            // rdoSell
            // 
            this.rdoSell.AutoSize = true;
            this.rdoSell.Location = new System.Drawing.Point(125, 46);
            this.rdoSell.Name = "rdoSell";
            this.rdoSell.Size = new System.Drawing.Size(42, 17);
            this.rdoSell.TabIndex = 2;
            this.rdoSell.Text = "Sell";
            this.rdoSell.UseVisualStyleBackColor = true;
            // 
            // rdoBuy
            // 
            this.rdoBuy.AutoSize = true;
            this.rdoBuy.Checked = true;
            this.rdoBuy.Location = new System.Drawing.Point(125, 14);
            this.rdoBuy.Name = "rdoBuy";
            this.rdoBuy.Size = new System.Drawing.Size(43, 17);
            this.rdoBuy.TabIndex = 1;
            this.rdoBuy.TabStop = true;
            this.rdoBuy.Text = "Buy";
            this.rdoBuy.UseVisualStyleBackColor = true;
            // 
            // btnAutomatedTrading
            // 
            this.btnAutomatedTrading.BackColor = System.Drawing.Color.LightGreen;
            this.btnAutomatedTrading.Location = new System.Drawing.Point(6, 16);
            this.btnAutomatedTrading.Name = "btnAutomatedTrading";
            this.btnAutomatedTrading.Size = new System.Drawing.Size(113, 77);
            this.btnAutomatedTrading.TabIndex = 0;
            this.btnAutomatedTrading.Text = "Start";
            this.btnAutomatedTrading.UseVisualStyleBackColor = false;
            this.btnAutomatedTrading.Click += new System.EventHandler(this.btnAutomatedTrading_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Qty for Manual Trading";
            // 
            // tmrAutotradeExecution
            // 
            this.tmrAutotradeExecution.Interval = 5000;
            this.tmrAutotradeExecution.Tick += new System.EventHandler(this.tmrAutotradeExecution_Tick);
            // 
            // nudCurrentPrice
            // 
            this.nudCurrentPrice.DecimalPlaces = 1;
            this.nudCurrentPrice.Enabled = false;
            this.nudCurrentPrice.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudCurrentPrice.Location = new System.Drawing.Point(170, 75);
            this.nudCurrentPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCurrentPrice.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudCurrentPrice.Name = "nudCurrentPrice";
            this.nudCurrentPrice.Size = new System.Drawing.Size(120, 20);
            this.nudCurrentPrice.TabIndex = 16;
            this.nudCurrentPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tmrClientUpdates
            // 
            this.tmrClientUpdates.Enabled = true;
            this.tmrClientUpdates.Tick += new System.EventHandler(this.tmrClientUpdates_Tick);
            // 
            // Heartbeat
            // 
            this.Heartbeat.Interval = 1000;
            this.Heartbeat.Tick += new System.EventHandler(this.Heartbeat_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBalanceAndTime);
            this.groupBox3.Location = new System.Drawing.Point(1104, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 105);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Information";
            // 
            // lblBalanceAndTime
            // 
            this.lblBalanceAndTime.AutoSize = true;
            this.lblBalanceAndTime.Location = new System.Drawing.Point(6, 16);
            this.lblBalanceAndTime.Name = "lblBalanceAndTime";
            this.lblBalanceAndTime.Size = new System.Drawing.Size(47, 13);
            this.lblBalanceAndTime.TabIndex = 18;
            this.lblBalanceAndTime.Text = "Network";
            // 
            // chkOverloadRetry
            // 
            this.chkOverloadRetry.AutoSize = true;
            this.chkOverloadRetry.Checked = true;
            this.chkOverloadRetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverloadRetry.Location = new System.Drawing.Point(509, 119);
            this.chkOverloadRetry.Name = "chkOverloadRetry";
            this.chkOverloadRetry.Size = new System.Drawing.Size(97, 17);
            this.chkOverloadRetry.TabIndex = 18;
            this.chkOverloadRetry.Text = "Overload Retry";
            this.chkOverloadRetry.UseVisualStyleBackColor = true;
            this.chkOverloadRetry.CheckedChanged += new System.EventHandler(this.chkOverloadRetry_CheckedChanged);
            // 
            // nudOverloadRetryAttempts
            // 
            this.nudOverloadRetryAttempts.Location = new System.Drawing.Point(509, 165);
            this.nudOverloadRetryAttempts.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudOverloadRetryAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOverloadRetryAttempts.Name = "nudOverloadRetryAttempts";
            this.nudOverloadRetryAttempts.Size = new System.Drawing.Size(120, 20);
            this.nudOverloadRetryAttempts.TabIndex = 19;
            this.nudOverloadRetryAttempts.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudOverloadRetryAttempts.ValueChanged += new System.EventHandler(this.nudOverloadRetryAttempts_ValueChanged);
            // 
            // lblOverloadRetryAttempts
            // 
            this.lblOverloadRetryAttempts.AutoSize = true;
            this.lblOverloadRetryAttempts.Location = new System.Drawing.Point(506, 149);
            this.lblOverloadRetryAttempts.Name = "lblOverloadRetryAttempts";
            this.lblOverloadRetryAttempts.Size = new System.Drawing.Size(122, 13);
            this.lblOverloadRetryAttempts.TabIndex = 20;
            this.lblOverloadRetryAttempts.Text = "Overload Retry Attempts";
            // 
            // nudPercentEarn
            // 
            this.nudPercentEarn.DecimalPlaces = 2;
            this.nudPercentEarn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPercentEarn.Location = new System.Drawing.Point(189, 33);
            this.nudPercentEarn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPercentEarn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPercentEarn.Name = "nudPercentEarn";
            this.nudPercentEarn.Size = new System.Drawing.Size(60, 20);
            this.nudPercentEarn.TabIndex = 21;
            this.nudPercentEarn.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // lblPrcEarn
            // 
            this.lblPrcEarn.AutoSize = true;
            this.lblPrcEarn.Location = new System.Drawing.Point(186, 14);
            this.lblPrcEarn.Name = "lblPrcEarn";
            this.lblPrcEarn.Size = new System.Drawing.Size(51, 13);
            this.lblPrcEarn.TabIndex = 22;
            this.lblPrcEarn.Text = "% to earn";
            // 
            // nudPercentToTrade
            // 
            this.nudPercentToTrade.Location = new System.Drawing.Point(189, 82);
            this.nudPercentToTrade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPercentToTrade.Name = "nudPercentToTrade";
            this.nudPercentToTrade.Size = new System.Drawing.Size(60, 20);
            this.nudPercentToTrade.TabIndex = 23;
            this.nudPercentToTrade.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPercentToTrade.ValueChanged += new System.EventHandler(this.nudPercentToTrade_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "% to Trade";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 439);
            this.Controls.Add(this.lblOverloadRetryAttempts);
            this.Controls.Add(this.nudOverloadRetryAttempts);
            this.Controls.Add(this.chkOverloadRetry);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.nudCurrentPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlSymbol);
            this.Controls.Add(this.ddNetwork);
            this.Controls.Add(this.ddOrderType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkCancelWhileOrdering);
            this.Controls.Add(this.nupQty);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Name = "Form1";
            this.Text = "BitMex Bot Goran";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nupQty)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPrice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverloadRetryAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentEarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentToTrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.NumericUpDown nupQty;
        private System.Windows.Forms.CheckBox chkCancelWhileOrdering;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddOrderType;
        private System.Windows.Forms.ComboBox ddNetwork;
        private System.Windows.Forms.ComboBox ddlSymbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlCandleTimes;
        private System.Windows.Forms.DataGridView dgvCandles;
        private System.Windows.Forms.Timer tmrCandleUpdater;
        private System.Windows.Forms.CheckBox chkUpdateCandles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMA2;
        private System.Windows.Forms.NumericUpDown nudMA1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSwitch;
        private System.Windows.Forms.RadioButton rdoSell;
        private System.Windows.Forms.RadioButton rdoBuy;
        private System.Windows.Forms.Button btnAutomatedTrading;
        private System.Windows.Forms.ComboBox ddlAutoOrderType;
        private System.Windows.Forms.NumericUpDown nudAutoQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer tmrAutotradeExecution;
        private System.Windows.Forms.NumericUpDown nudCurrentPrice;
        private System.Windows.Forms.Timer tmrClientUpdates;
        private System.Windows.Forms.Timer Heartbeat;
        private System.Windows.Forms.Label lblSettingsWebsocketInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBalanceAndTime;
        private System.Windows.Forms.CheckBox chkOverloadRetry;
        private System.Windows.Forms.NumericUpDown nudOverloadRetryAttempts;
        private System.Windows.Forms.Label lblOverloadRetryAttempts;
        private System.Windows.Forms.Label lblPrcEarn;
        private System.Windows.Forms.NumericUpDown nudPercentEarn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudPercentToTrade;
    }
}

