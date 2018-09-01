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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.txtSettingsWebsocketInfo = new System.Windows.Forms.TextBox();
            this.lblRetry = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMA2 = new System.Windows.Forms.NumericUpDown();
            this.nudMA1 = new System.Windows.Forms.NumericUpDown();
            this.chkUpdateCandles = new System.Windows.Forms.CheckBox();
            this.dgvCandles = new System.Windows.Forms.DataGridView();
            this.ddlCandleTimes = new System.Windows.Forms.ComboBox();
            this.tmrCandleUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nupRSIDifference = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudPercentToTrade = new System.Windows.Forms.NumericUpDown();
            this.lblPrcEarn = new System.Windows.Forms.Label();
            this.nudPercentEarn = new System.Windows.Forms.NumericUpDown();
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
            this.lblApiValidity = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtAPISecret = new System.Windows.Forms.TextBox();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.lblBalanceAndTime = new System.Windows.Forms.Label();
            this.chkOverloadRetry = new System.Windows.Forms.CheckBox();
            this.nudOverloadRetryAttempts = new System.Windows.Forms.NumericUpDown();
            this.lblOverloadRetryAttempts = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPositionClosePosition = new System.Windows.Forms.TextBox();
            this.txtPositionUnrealizedPnLPercent = new System.Windows.Forms.TextBox();
            this.txtPositionUnrealizedPnL = new System.Windows.Forms.TextBox();
            this.txtPositionMargin = new System.Windows.Forms.TextBox();
            this.txtPositionLiquidation = new System.Windows.Forms.TextBox();
            this.txtPositionMarkPrice = new System.Windows.Forms.TextBox();
            this.txtPositionEntryPrice = new System.Windows.Forms.TextBox();
            this.txtPositionSize = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOrderSide = new System.Windows.Forms.TextBox();
            this.txtOrderSize = new System.Windows.Forms.TextBox();
            this.txtOrderPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRSIDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentToTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentEarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPrice)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverloadRetryAttempts)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.btnSell.Location = new System.Drawing.Point(219, 115);
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
            this.nupQty.Location = new System.Drawing.Point(93, 118);
            this.nupQty.Maximum = new decimal(new int[] {
            1000000000,
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
            this.btnCancel.Location = new System.Drawing.Point(216, 151);
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
            this.ddOrderType.Size = new System.Drawing.Size(75, 21);
            this.ddOrderType.TabIndex = 5;
            this.ddOrderType.SelectedIndexChanged += new System.EventHandler(this.ddOrderType_SelectedIndexChanged);
            // 
            // ddNetwork
            // 
            this.ddNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddNetwork.Enabled = false;
            this.ddNetwork.FormattingEnabled = true;
            this.ddNetwork.Items.AddRange(new object[] {
            "TestNet",
            "RealNet"});
            this.ddNetwork.Location = new System.Drawing.Point(172, 48);
            this.ddNetwork.Name = "ddNetwork";
            this.ddNetwork.Size = new System.Drawing.Size(76, 21);
            this.ddNetwork.TabIndex = 6;
            this.ddNetwork.SelectedIndexChanged += new System.EventHandler(this.ddNetwork_SelectedIndexChanged);
            // 
            // ddlSymbol
            // 
            this.ddlSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSymbol.Enabled = false;
            this.ddlSymbol.FormattingEnabled = true;
            this.ddlSymbol.Location = new System.Drawing.Point(93, 48);
            this.ddlSymbol.Name = "ddlSymbol";
            this.ddlSymbol.Size = new System.Drawing.Size(73, 21);
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
            this.label2.Location = new System.Drawing.Point(93, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sym / Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 32);
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
            this.groupBox1.Controls.Add(this.txtSettingsWebsocketInfo);
            this.groupBox1.Controls.Add(this.lblRetry);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudMA2);
            this.groupBox1.Controls.Add(this.nudMA1);
            this.groupBox1.Controls.Add(this.chkUpdateCandles);
            this.groupBox1.Controls.Add(this.dgvCandles);
            this.groupBox1.Controls.Add(this.ddlCandleTimes);
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1253, 236);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Candles";
            // 
            // txtSettingsWebsocketInfo
            // 
            this.txtSettingsWebsocketInfo.Enabled = false;
            this.txtSettingsWebsocketInfo.Location = new System.Drawing.Point(484, 20);
            this.txtSettingsWebsocketInfo.Name = "txtSettingsWebsocketInfo";
            this.txtSettingsWebsocketInfo.Size = new System.Drawing.Size(543, 20);
            this.txtSettingsWebsocketInfo.TabIndex = 20;
            // 
            // lblRetry
            // 
            this.lblRetry.AutoSize = true;
            this.lblRetry.Location = new System.Drawing.Point(391, 23);
            this.lblRetry.Name = "lblRetry";
            this.lblRetry.Size = new System.Drawing.Size(38, 13);
            this.lblRetry.TabIndex = 11;
            this.lblRetry.Text = "Retry: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MA 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "MA 1";
            // 
            // nudMA2
            // 
            this.nudMA2.Location = new System.Drawing.Point(292, 21);
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
            this.nudMA1.Location = new System.Drawing.Point(192, 21);
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
            this.chkUpdateCandles.Location = new System.Drawing.Point(81, 22);
            this.chkUpdateCandles.Name = "chkUpdateCandles";
            this.chkUpdateCandles.Size = new System.Drawing.Size(105, 17);
            this.chkUpdateCandles.TabIndex = 4;
            this.chkUpdateCandles.Text = "Update Every 3s";
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
            this.dgvCandles.Size = new System.Drawing.Size(1240, 188);
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
            this.ddlCandleTimes.Size = new System.Drawing.Size(68, 21);
            this.ddlCandleTimes.TabIndex = 0;
            this.ddlCandleTimes.SelectedIndexChanged += new System.EventHandler(this.ddlCandleTimes_SelectedIndexChanged);
            // 
            // tmrCandleUpdater
            // 
            this.tmrCandleUpdater.Interval = 3000;
            this.tmrCandleUpdater.Tick += new System.EventHandler(this.tmrCandleUpdater_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nupRSIDifference);
            this.groupBox2.Controls.Add(this.label22);
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
            this.groupBox2.Location = new System.Drawing.Point(425, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 106);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automated Trading";
            // 
            // nupRSIDifference
            // 
            this.nupRSIDifference.Location = new System.Drawing.Point(255, 32);
            this.nupRSIDifference.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nupRSIDifference.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nupRSIDifference.Name = "nupRSIDifference";
            this.nupRSIDifference.Size = new System.Drawing.Size(60, 20);
            this.nupRSIDifference.TabIndex = 26;
            this.nupRSIDifference.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(252, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 25;
            this.label22.Text = "RSI diff to 50";
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
            90,
            0,
            0,
            0});
            this.nudPercentToTrade.ValueChanged += new System.EventHandler(this.nudPercentToTrade_ValueChanged);
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
            25,
            0,
            0,
            131072});
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
            this.rdoSwitch.Enabled = false;
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
            this.rdoBuy.Location = new System.Drawing.Point(125, 14);
            this.rdoBuy.Name = "rdoBuy";
            this.rdoBuy.Size = new System.Drawing.Size(43, 17);
            this.rdoBuy.TabIndex = 1;
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
            this.label8.Location = new System.Drawing.Point(93, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Qty for Manual Trading";
            // 
            // tmrAutotradeExecution
            // 
            this.tmrAutotradeExecution.Interval = 2000;
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
            this.nudCurrentPrice.Location = new System.Drawing.Point(93, 75);
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
            this.nudCurrentPrice.Size = new System.Drawing.Size(73, 20);
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
            this.groupBox3.Controls.Add(this.lblApiValidity);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtAPISecret);
            this.groupBox3.Controls.Add(this.txtAPIKey);
            this.groupBox3.Controls.Add(this.lblBalanceAndTime);
            this.groupBox3.Location = new System.Drawing.Point(903, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 106);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Information";
            // 
            // lblApiValidity
            // 
            this.lblApiValidity.AutoSize = true;
            this.lblApiValidity.Location = new System.Drawing.Point(6, 84);
            this.lblApiValidity.Name = "lblApiValidity";
            this.lblApiValidity.Size = new System.Drawing.Size(60, 13);
            this.lblApiValidity.TabIndex = 23;
            this.lblApiValidity.Text = "API Validity";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 63);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "API Secret :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 21;
            this.label23.Text = "API Key :";
            // 
            // txtAPISecret
            // 
            this.txtAPISecret.Location = new System.Drawing.Point(75, 60);
            this.txtAPISecret.Name = "txtAPISecret";
            this.txtAPISecret.Size = new System.Drawing.Size(281, 20);
            this.txtAPISecret.TabIndex = 20;
            this.txtAPISecret.UseSystemPasswordChar = true;
            this.txtAPISecret.TextChanged += new System.EventHandler(this.txtAPISecret_TextChanged);
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Location = new System.Drawing.Point(75, 34);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(281, 20);
            this.txtAPIKey.TabIndex = 19;
            this.txtAPIKey.UseSystemPasswordChar = true;
            this.txtAPIKey.TextChanged += new System.EventHandler(this.txtAPIKey_TextChanged);
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
            this.chkOverloadRetry.Location = new System.Drawing.Point(300, 119);
            this.chkOverloadRetry.Name = "chkOverloadRetry";
            this.chkOverloadRetry.Size = new System.Drawing.Size(97, 17);
            this.chkOverloadRetry.TabIndex = 18;
            this.chkOverloadRetry.Text = "Overload Retry";
            this.chkOverloadRetry.UseVisualStyleBackColor = true;
            this.chkOverloadRetry.CheckedChanged += new System.EventHandler(this.chkOverloadRetry_CheckedChanged);
            // 
            // nudOverloadRetryAttempts
            // 
            this.nudOverloadRetryAttempts.Location = new System.Drawing.Point(297, 154);
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
            this.lblOverloadRetryAttempts.Location = new System.Drawing.Point(297, 138);
            this.lblOverloadRetryAttempts.Name = "lblOverloadRetryAttempts";
            this.lblOverloadRetryAttempts.Size = new System.Drawing.Size(122, 13);
            this.lblOverloadRetryAttempts.TabIndex = 20;
            this.lblOverloadRetryAttempts.Text = "Overload Retry Attempts";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPositionClosePosition);
            this.groupBox4.Controls.Add(this.txtPositionUnrealizedPnLPercent);
            this.groupBox4.Controls.Add(this.txtPositionUnrealizedPnL);
            this.groupBox4.Controls.Add(this.txtPositionMargin);
            this.groupBox4.Controls.Add(this.txtPositionLiquidation);
            this.groupBox4.Controls.Add(this.txtPositionMarkPrice);
            this.groupBox4.Controls.Add(this.txtPositionEntryPrice);
            this.groupBox4.Controls.Add(this.txtPositionSize);
            this.groupBox4.Location = new System.Drawing.Point(262, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 67);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Open Position";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(492, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Close Position";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(423, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "UnrlPnL %";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(354, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "UnrealPnL";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(285, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Margin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(216, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Liquidation";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(147, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Mark";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Entry";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Size";
            // 
            // txtPositionClosePosition
            // 
            this.txtPositionClosePosition.Enabled = false;
            this.txtPositionClosePosition.Location = new System.Drawing.Point(495, 41);
            this.txtPositionClosePosition.Name = "txtPositionClosePosition";
            this.txtPositionClosePosition.Size = new System.Drawing.Size(63, 20);
            this.txtPositionClosePosition.TabIndex = 7;
            // 
            // txtPositionUnrealizedPnLPercent
            // 
            this.txtPositionUnrealizedPnLPercent.Enabled = false;
            this.txtPositionUnrealizedPnLPercent.Location = new System.Drawing.Point(426, 41);
            this.txtPositionUnrealizedPnLPercent.Name = "txtPositionUnrealizedPnLPercent";
            this.txtPositionUnrealizedPnLPercent.Size = new System.Drawing.Size(63, 20);
            this.txtPositionUnrealizedPnLPercent.TabIndex = 6;
            // 
            // txtPositionUnrealizedPnL
            // 
            this.txtPositionUnrealizedPnL.Enabled = false;
            this.txtPositionUnrealizedPnL.Location = new System.Drawing.Point(357, 41);
            this.txtPositionUnrealizedPnL.Name = "txtPositionUnrealizedPnL";
            this.txtPositionUnrealizedPnL.Size = new System.Drawing.Size(63, 20);
            this.txtPositionUnrealizedPnL.TabIndex = 5;
            // 
            // txtPositionMargin
            // 
            this.txtPositionMargin.Enabled = false;
            this.txtPositionMargin.Location = new System.Drawing.Point(288, 41);
            this.txtPositionMargin.Name = "txtPositionMargin";
            this.txtPositionMargin.Size = new System.Drawing.Size(63, 20);
            this.txtPositionMargin.TabIndex = 4;
            // 
            // txtPositionLiquidation
            // 
            this.txtPositionLiquidation.Enabled = false;
            this.txtPositionLiquidation.Location = new System.Drawing.Point(219, 41);
            this.txtPositionLiquidation.Name = "txtPositionLiquidation";
            this.txtPositionLiquidation.Size = new System.Drawing.Size(63, 20);
            this.txtPositionLiquidation.TabIndex = 3;
            // 
            // txtPositionMarkPrice
            // 
            this.txtPositionMarkPrice.Enabled = false;
            this.txtPositionMarkPrice.Location = new System.Drawing.Point(150, 41);
            this.txtPositionMarkPrice.Name = "txtPositionMarkPrice";
            this.txtPositionMarkPrice.Size = new System.Drawing.Size(63, 20);
            this.txtPositionMarkPrice.TabIndex = 2;
            // 
            // txtPositionEntryPrice
            // 
            this.txtPositionEntryPrice.Enabled = false;
            this.txtPositionEntryPrice.Location = new System.Drawing.Point(81, 41);
            this.txtPositionEntryPrice.Name = "txtPositionEntryPrice";
            this.txtPositionEntryPrice.Size = new System.Drawing.Size(63, 20);
            this.txtPositionEntryPrice.TabIndex = 1;
            // 
            // txtPositionSize
            // 
            this.txtPositionSize.Enabled = false;
            this.txtPositionSize.Location = new System.Drawing.Point(12, 41);
            this.txtPositionSize.Name = "txtPositionSize";
            this.txtPositionSize.Size = new System.Drawing.Size(63, 20);
            this.txtPositionSize.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.txtOrderStatus);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.txtOrderSide);
            this.groupBox5.Controls.Add(this.txtOrderSize);
            this.groupBox5.Controls.Add(this.txtOrderPrice);
            this.groupBox5.Location = new System.Drawing.Point(903, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(362, 67);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Open Orders";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(210, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "Status";
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.Enabled = false;
            this.txtOrderStatus.Location = new System.Drawing.Point(213, 41);
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.Size = new System.Drawing.Size(63, 20);
            this.txtOrderStatus.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(141, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Side";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(72, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Price";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Size";
            // 
            // txtOrderSide
            // 
            this.txtOrderSide.Enabled = false;
            this.txtOrderSide.Location = new System.Drawing.Point(144, 41);
            this.txtOrderSide.Name = "txtOrderSide";
            this.txtOrderSide.Size = new System.Drawing.Size(63, 20);
            this.txtOrderSide.TabIndex = 23;
            // 
            // txtOrderSize
            // 
            this.txtOrderSize.Enabled = false;
            this.txtOrderSize.Location = new System.Drawing.Point(6, 41);
            this.txtOrderSize.Name = "txtOrderSize";
            this.txtOrderSize.Size = new System.Drawing.Size(63, 20);
            this.txtOrderSize.TabIndex = 2;
            // 
            // txtOrderPrice
            // 
            this.txtOrderPrice.Enabled = false;
            this.txtOrderPrice.Location = new System.Drawing.Point(75, 41);
            this.txtOrderPrice.Name = "txtOrderPrice";
            this.txtOrderPrice.Size = new System.Drawing.Size(63, 20);
            this.txtOrderPrice.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 439);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            ((System.ComponentModel.ISupportInitialize)(this.nupRSIDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentToTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentEarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPrice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverloadRetryAttempts)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBalanceAndTime;
        private System.Windows.Forms.CheckBox chkOverloadRetry;
        private System.Windows.Forms.NumericUpDown nudOverloadRetryAttempts;
        private System.Windows.Forms.Label lblOverloadRetryAttempts;
        private System.Windows.Forms.Label lblPrcEarn;
        private System.Windows.Forms.NumericUpDown nudPercentEarn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudPercentToTrade;
        private System.Windows.Forms.Label lblRetry;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPositionClosePosition;
        private System.Windows.Forms.TextBox txtPositionUnrealizedPnLPercent;
        private System.Windows.Forms.TextBox txtPositionUnrealizedPnL;
        private System.Windows.Forms.TextBox txtPositionMargin;
        private System.Windows.Forms.TextBox txtPositionLiquidation;
        private System.Windows.Forms.TextBox txtPositionMarkPrice;
        private System.Windows.Forms.TextBox txtPositionEntryPrice;
        private System.Windows.Forms.TextBox txtPositionSize;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtOrderSide;
        private System.Windows.Forms.TextBox txtOrderSize;
        private System.Windows.Forms.TextBox txtOrderPrice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtOrderStatus;
        private System.Windows.Forms.NumericUpDown nupRSIDifference;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAPISecret;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.Label lblApiValidity;
        private System.Windows.Forms.TextBox txtSettingsWebsocketInfo;
    }
}

