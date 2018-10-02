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
            this.txtTPTimer = new System.Windows.Forms.TextBox();
            this.dgvCandles1d = new System.Windows.Forms.DataGridView();
            this.dgvCandles1h = new System.Windows.Forms.DataGridView();
            this.txtWebSocketFails = new System.Windows.Forms.TextBox();
            this.txtSettingsWebsocketInfo = new System.Windows.Forms.TextBox();
            this.lblRetry = new System.Windows.Forms.Label();
            this.chkUpdateCandles = new System.Windows.Forms.CheckBox();
            this.dgvCandles = new System.Windows.Forms.DataGridView();
            this.ddlCandleTimes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMA2 = new System.Windows.Forms.NumericUpDown();
            this.nudMA1 = new System.Windows.Forms.NumericUpDown();
            this.tmrCandleUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkManualControl = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.ddlStrategyType = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtTPExecute = new System.Windows.Forms.TextBox();
            this.txtTPStart = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.nudExecuteTrailingProfit = new System.Windows.Forms.NumericUpDown();
            this.nudStartTrailingProfit = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.nudPercentEarn = new System.Windows.Forms.NumericUpDown();
            this.nupRSIDifference = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.lblPrcEarn = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCancelStopLoss = new System.Windows.Forms.TextBox();
            this.txtStartStopLoss = new System.Windows.Forms.TextBox();
            this.txtExecuteStopLoss = new System.Windows.Forms.TextBox();
            this.chkStopLoss = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.nudExecuteStopLoss = new System.Windows.Forms.NumericUpDown();
            this.nudStartStopLoss = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudPercentToTrade = new System.Windows.Forms.NumericUpDown();
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
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtPercentBTCEarned = new System.Windows.Forms.TextBox();
            this.txtBTCEarned = new System.Windows.Forms.TextBox();
            this.txtCurrentBalance = new System.Windows.Forms.TextBox();
            this.txtBalanceStart = new System.Windows.Forms.TextBox();
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
            this.label36 = new System.Windows.Forms.Label();
            this.txtTrailingProfitStart = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtOrderType = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOrderSide = new System.Windows.Forms.TextBox();
            this.txtOrderSize = new System.Windows.Forms.TextBox();
            this.txtOrderPrice = new System.Windows.Forms.TextBox();
            this.tmrCandleUpdaterhd = new System.Windows.Forms.Timer(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.nudATRMultiplier = new System.Windows.Forms.NumericUpDown();
            this.nudATRPeriod = new System.Windows.Forms.NumericUpDown();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.nudLongLimit = new System.Windows.Forms.NumericUpDown();
            this.nudShortLimit = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.nudPriceChange = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.nupRSIDifferenceThree = new System.Windows.Forms.NumericUpDown();
            this.nudLeverage = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles1d)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles1h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExecuteTrailingProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartTrailingProfit)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentEarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRSIDifference)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExecuteStopLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartStopLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentToTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPrice)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverloadRetryAttempts)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATRMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudATRPeriod)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShortLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRSIDifferenceThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeverage)).BeginInit();
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
            this.btnSell.Location = new System.Drawing.Point(182, 115);
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
            this.nupQty.Size = new System.Drawing.Size(83, 20);
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
            this.btnCancel.Location = new System.Drawing.Point(182, 151);
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
            this.groupBox1.Controls.Add(this.txtTPTimer);
            this.groupBox1.Controls.Add(this.dgvCandles1d);
            this.groupBox1.Controls.Add(this.dgvCandles1h);
            this.groupBox1.Controls.Add(this.txtWebSocketFails);
            this.groupBox1.Controls.Add(this.txtSettingsWebsocketInfo);
            this.groupBox1.Controls.Add(this.lblRetry);
            this.groupBox1.Controls.Add(this.chkUpdateCandles);
            this.groupBox1.Controls.Add(this.dgvCandles);
            this.groupBox1.Controls.Add(this.ddlCandleTimes);
            this.groupBox1.Location = new System.Drawing.Point(12, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1253, 231);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Candles - 3 sec update Selected / 5 min update 1h and 1d Candles";
            // 
            // txtTPTimer
            // 
            this.txtTPTimer.Enabled = false;
            this.txtTPTimer.Location = new System.Drawing.Point(1159, 20);
            this.txtTPTimer.Name = "txtTPTimer";
            this.txtTPTimer.Size = new System.Drawing.Size(88, 20);
            this.txtTPTimer.TabIndex = 24;
            // 
            // dgvCandles1d
            // 
            this.dgvCandles1d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCandles1d.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCandles1d.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandles1d.Location = new System.Drawing.Point(851, 48);
            this.dgvCandles1d.Name = "dgvCandles1d";
            this.dgvCandles1d.RowHeadersWidth = 4;
            this.dgvCandles1d.Size = new System.Drawing.Size(396, 183);
            this.dgvCandles1d.TabIndex = 23;
            // 
            // dgvCandles1h
            // 
            this.dgvCandles1h.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvCandles1h.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCandles1h.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandles1h.Location = new System.Drawing.Point(414, 48);
            this.dgvCandles1h.Name = "dgvCandles1h";
            this.dgvCandles1h.RowHeadersWidth = 4;
            this.dgvCandles1h.Size = new System.Drawing.Size(431, 183);
            this.dgvCandles1h.TabIndex = 22;
            // 
            // txtWebSocketFails
            // 
            this.txtWebSocketFails.Enabled = false;
            this.txtWebSocketFails.Location = new System.Drawing.Point(1000, 20);
            this.txtWebSocketFails.Name = "txtWebSocketFails";
            this.txtWebSocketFails.Size = new System.Drawing.Size(153, 20);
            this.txtWebSocketFails.TabIndex = 21;
            this.txtWebSocketFails.Text = "Websocket failed times - 0";
            // 
            // txtSettingsWebsocketInfo
            // 
            this.txtSettingsWebsocketInfo.Enabled = false;
            this.txtSettingsWebsocketInfo.Location = new System.Drawing.Point(484, 20);
            this.txtSettingsWebsocketInfo.Name = "txtSettingsWebsocketInfo";
            this.txtSettingsWebsocketInfo.Size = new System.Drawing.Size(510, 20);
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
            this.dgvCandles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCandles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCandles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandles.Location = new System.Drawing.Point(7, 48);
            this.dgvCandles.Name = "dgvCandles";
            this.dgvCandles.RowHeadersWidth = 4;
            this.dgvCandles.Size = new System.Drawing.Size(401, 183);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MA 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "MA 1";
            // 
            // nudMA2
            // 
            this.nudMA2.Location = new System.Drawing.Point(6, 45);
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
            this.nudMA1.Location = new System.Drawing.Point(7, 19);
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
            // tmrCandleUpdater
            // 
            this.tmrCandleUpdater.Interval = 3000;
            this.tmrCandleUpdater.Tick += new System.EventHandler(this.tmrCandleUpdater_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.nudLeverage);
            this.groupBox2.Controls.Add(this.chkManualControl);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.ddlStrategyType);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.nudPercentToTrade);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ddlAutoOrderType);
            this.groupBox2.Controls.Add(this.nudAutoQuantity);
            this.groupBox2.Controls.Add(this.rdoSwitch);
            this.groupBox2.Controls.Add(this.rdoSell);
            this.groupBox2.Controls.Add(this.rdoBuy);
            this.groupBox2.Controls.Add(this.btnAutomatedTrading);
            this.groupBox2.Location = new System.Drawing.Point(369, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 211);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automated Trading - 2 sec update";
            // 
            // chkManualControl
            // 
            this.chkManualControl.AutoSize = true;
            this.chkManualControl.Location = new System.Drawing.Point(456, 178);
            this.chkManualControl.Name = "chkManualControl";
            this.chkManualControl.Size = new System.Drawing.Size(75, 17);
            this.chkManualControl.TabIndex = 32;
            this.chkManualControl.Text = "Man, Con,";
            this.chkManualControl.UseVisualStyleBackColor = true;
            this.chkManualControl.CheckedChanged += new System.EventHandler(this.chkManualControl_CheckedChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(454, 135);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(46, 13);
            this.label33.TabIndex = 31;
            this.label33.Text = "Strategy";
            // 
            // ddlStrategyType
            // 
            this.ddlStrategyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStrategyType.FormattingEnabled = true;
            this.ddlStrategyType.Items.AddRange(new object[] {
            "Strat1",
            "Strat2",
            "Strat3"});
            this.ddlStrategyType.Location = new System.Drawing.Point(457, 151);
            this.ddlStrategyType.Name = "ddlStrategyType";
            this.ddlStrategyType.Size = new System.Drawing.Size(65, 21);
            this.ddlStrategyType.TabIndex = 30;
            this.ddlStrategyType.SelectedIndexChanged += new System.EventHandler(this.ddlStrategyType_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtTPExecute);
            this.groupBox8.Controls.Add(this.txtTPStart);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.nudExecuteTrailingProfit);
            this.groupBox8.Controls.Add(this.nudStartTrailingProfit);
            this.groupBox8.Location = new System.Drawing.Point(363, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(159, 97);
            this.groupBox8.TabIndex = 29;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Strategy 2 - Trailing Profit";
            // 
            // txtTPExecute
            // 
            this.txtTPExecute.Enabled = false;
            this.txtTPExecute.Location = new System.Drawing.Point(93, 22);
            this.txtTPExecute.Name = "txtTPExecute";
            this.txtTPExecute.Size = new System.Drawing.Size(60, 20);
            this.txtTPExecute.TabIndex = 34;
            // 
            // txtTPStart
            // 
            this.txtTPStart.Enabled = false;
            this.txtTPStart.Location = new System.Drawing.Point(6, 22);
            this.txtTPStart.Name = "txtTPStart";
            this.txtTPStart.Size = new System.Drawing.Size(62, 20);
            this.txtTPStart.TabIndex = 33;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(91, 45);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 13);
            this.label35.TabIndex = 25;
            this.label35.Text = "-% to exe TP";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 45);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 13);
            this.label34.TabIndex = 24;
            this.label34.Text = "% to start TP";
            // 
            // nudExecuteTrailingProfit
            // 
            this.nudExecuteTrailingProfit.DecimalPlaces = 2;
            this.nudExecuteTrailingProfit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudExecuteTrailingProfit.Location = new System.Drawing.Point(93, 61);
            this.nudExecuteTrailingProfit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudExecuteTrailingProfit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudExecuteTrailingProfit.Name = "nudExecuteTrailingProfit";
            this.nudExecuteTrailingProfit.Size = new System.Drawing.Size(60, 20);
            this.nudExecuteTrailingProfit.TabIndex = 23;
            this.nudExecuteTrailingProfit.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            // 
            // nudStartTrailingProfit
            // 
            this.nudStartTrailingProfit.DecimalPlaces = 2;
            this.nudStartTrailingProfit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudStartTrailingProfit.Location = new System.Drawing.Point(6, 61);
            this.nudStartTrailingProfit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStartTrailingProfit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudStartTrailingProfit.Name = "nudStartTrailingProfit";
            this.nudStartTrailingProfit.Size = new System.Drawing.Size(60, 20);
            this.nudStartTrailingProfit.TabIndex = 22;
            this.nudStartTrailingProfit.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.nudStartTrailingProfit.ValueChanged += new System.EventHandler(this.nudStartTrailingProfit_ValueChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.nudPercentEarn);
            this.groupBox7.Controls.Add(this.nupRSIDifference);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.lblPrcEarn);
            this.groupBox7.Location = new System.Drawing.Point(189, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(168, 97);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Strategy 1 - RSI, BB, MACD, TD Seq";
            // 
            // nudPercentEarn
            // 
            this.nudPercentEarn.DecimalPlaces = 2;
            this.nudPercentEarn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPercentEarn.Location = new System.Drawing.Point(5, 61);
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
            // nupRSIDifference
            // 
            this.nupRSIDifference.Location = new System.Drawing.Point(87, 61);
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
            7,
            0,
            0,
            -2147483648});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(84, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 25;
            this.label22.Text = "RSI diff to 50";
            // 
            // lblPrcEarn
            // 
            this.lblPrcEarn.AutoSize = true;
            this.lblPrcEarn.Location = new System.Drawing.Point(3, 45);
            this.lblPrcEarn.Name = "lblPrcEarn";
            this.lblPrcEarn.Size = new System.Drawing.Size(51, 13);
            this.lblPrcEarn.TabIndex = 22;
            this.lblPrcEarn.Text = "% to earn";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.txtCancelStopLoss);
            this.groupBox6.Controls.Add(this.txtStartStopLoss);
            this.groupBox6.Controls.Add(this.txtExecuteStopLoss);
            this.groupBox6.Controls.Add(this.chkStopLoss);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.nudExecuteStopLoss);
            this.groupBox6.Controls.Add(this.nudStartStopLoss);
            this.groupBox6.Location = new System.Drawing.Point(189, 112);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(262, 93);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Stop Loss";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(171, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(71, 13);
            this.label28.TabIndex = 34;
            this.label28.Text = "Cancel SL at:";
            // 
            // txtCancelStopLoss
            // 
            this.txtCancelStopLoss.Enabled = false;
            this.txtCancelStopLoss.Location = new System.Drawing.Point(174, 59);
            this.txtCancelStopLoss.Name = "txtCancelStopLoss";
            this.txtCancelStopLoss.Size = new System.Drawing.Size(60, 20);
            this.txtCancelStopLoss.TabIndex = 33;
            // 
            // txtStartStopLoss
            // 
            this.txtStartStopLoss.Enabled = false;
            this.txtStartStopLoss.Location = new System.Drawing.Point(6, 59);
            this.txtStartStopLoss.Name = "txtStartStopLoss";
            this.txtStartStopLoss.Size = new System.Drawing.Size(59, 20);
            this.txtStartStopLoss.TabIndex = 32;
            // 
            // txtExecuteStopLoss
            // 
            this.txtExecuteStopLoss.Enabled = false;
            this.txtExecuteStopLoss.Location = new System.Drawing.Point(87, 59);
            this.txtExecuteStopLoss.Name = "txtExecuteStopLoss";
            this.txtExecuteStopLoss.Size = new System.Drawing.Size(60, 20);
            this.txtExecuteStopLoss.TabIndex = 31;
            // 
            // chkStopLoss
            // 
            this.chkStopLoss.AutoSize = true;
            this.chkStopLoss.Location = new System.Drawing.Point(174, 16);
            this.chkStopLoss.Name = "chkStopLoss";
            this.chkStopLoss.Size = new System.Drawing.Size(73, 17);
            this.chkStopLoss.TabIndex = 23;
            this.chkStopLoss.Text = "Stop Loss";
            this.chkStopLoss.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(84, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(84, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "% to execute SL";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(2, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 13);
            this.label25.TabIndex = 28;
            this.label25.Text = "% to start SL";
            // 
            // nudExecuteStopLoss
            // 
            this.nudExecuteStopLoss.DecimalPlaces = 2;
            this.nudExecuteStopLoss.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudExecuteStopLoss.Location = new System.Drawing.Point(87, 33);
            this.nudExecuteStopLoss.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudExecuteStopLoss.Name = "nudExecuteStopLoss";
            this.nudExecuteStopLoss.Size = new System.Drawing.Size(60, 20);
            this.nudExecuteStopLoss.TabIndex = 29;
            this.nudExecuteStopLoss.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // nudStartStopLoss
            // 
            this.nudStartStopLoss.DecimalPlaces = 2;
            this.nudStartStopLoss.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudStartStopLoss.Location = new System.Drawing.Point(5, 33);
            this.nudStartStopLoss.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudStartStopLoss.Name = "nudStartStopLoss";
            this.nudStartStopLoss.Size = new System.Drawing.Size(60, 20);
            this.nudStartStopLoss.TabIndex = 28;
            this.nudStartStopLoss.Value = new decimal(new int[] {
            75,
            0,
            0,
            65536});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "% to Trade";
            // 
            // nudPercentToTrade
            // 
            this.nudPercentToTrade.Location = new System.Drawing.Point(6, 112);
            this.nudPercentToTrade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPercentToTrade.Name = "nudPercentToTrade";
            this.nudPercentToTrade.Size = new System.Drawing.Size(60, 20);
            this.nudPercentToTrade.TabIndex = 23;
            this.nudPercentToTrade.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.nudPercentToTrade.ValueChanged += new System.EventHandler(this.nudPercentToTrade_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Qty for AutoTrading";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 135);
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
            this.ddlAutoOrderType.Location = new System.Drawing.Point(6, 151);
            this.ddlAutoOrderType.Name = "ddlAutoOrderType";
            this.ddlAutoOrderType.Size = new System.Drawing.Size(121, 21);
            this.ddlAutoOrderType.TabIndex = 5;
            // 
            // nudAutoQuantity
            // 
            this.nudAutoQuantity.Enabled = false;
            this.nudAutoQuantity.Location = new System.Drawing.Point(72, 112);
            this.nudAutoQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAutoQuantity.Name = "nudAutoQuantity";
            this.nudAutoQuantity.Size = new System.Drawing.Size(96, 20);
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
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Qty for Man. Trad.";
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
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.txtPercentBTCEarned);
            this.groupBox3.Controls.Add(this.txtBTCEarned);
            this.groupBox3.Controls.Add(this.txtCurrentBalance);
            this.groupBox3.Controls.Add(this.txtBalanceStart);
            this.groupBox3.Controls.Add(this.lblApiValidity);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtAPISecret);
            this.groupBox3.Controls.Add(this.txtAPIKey);
            this.groupBox3.Controls.Add(this.lblBalanceAndTime);
            this.groupBox3.Location = new System.Drawing.Point(903, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 211);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Information";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(107, 155);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(75, 13);
            this.label32.TabIndex = 39;
            this.label32.Text = "% BTC earned";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 155);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "BTC earned:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(107, 106);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(85, 13);
            this.label30.TabIndex = 37;
            this.label30.Text = "Current balance:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 106);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 13);
            this.label29.TabIndex = 35;
            this.label29.Text = "Balance at start:";
            // 
            // txtPercentBTCEarned
            // 
            this.txtPercentBTCEarned.Enabled = false;
            this.txtPercentBTCEarned.Location = new System.Drawing.Point(110, 171);
            this.txtPercentBTCEarned.Name = "txtPercentBTCEarned";
            this.txtPercentBTCEarned.Size = new System.Drawing.Size(96, 20);
            this.txtPercentBTCEarned.TabIndex = 36;
            // 
            // txtBTCEarned
            // 
            this.txtBTCEarned.Enabled = false;
            this.txtBTCEarned.Location = new System.Drawing.Point(6, 171);
            this.txtBTCEarned.Name = "txtBTCEarned";
            this.txtBTCEarned.Size = new System.Drawing.Size(97, 20);
            this.txtBTCEarned.TabIndex = 35;
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Enabled = false;
            this.txtCurrentBalance.Location = new System.Drawing.Point(109, 122);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.Size = new System.Drawing.Size(97, 20);
            this.txtCurrentBalance.TabIndex = 34;
            // 
            // txtBalanceStart
            // 
            this.txtBalanceStart.Enabled = false;
            this.txtBalanceStart.Location = new System.Drawing.Point(6, 122);
            this.txtBalanceStart.Name = "txtBalanceStart";
            this.txtBalanceStart.Size = new System.Drawing.Size(97, 20);
            this.txtBalanceStart.TabIndex = 33;
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
            this.chkOverloadRetry.Location = new System.Drawing.Point(263, 119);
            this.chkOverloadRetry.Name = "chkOverloadRetry";
            this.chkOverloadRetry.Size = new System.Drawing.Size(97, 17);
            this.chkOverloadRetry.TabIndex = 18;
            this.chkOverloadRetry.Text = "Overload Retry";
            this.chkOverloadRetry.UseVisualStyleBackColor = true;
            this.chkOverloadRetry.CheckedChanged += new System.EventHandler(this.chkOverloadRetry_CheckedChanged);
            // 
            // nudOverloadRetryAttempts
            // 
            this.nudOverloadRetryAttempts.Location = new System.Drawing.Point(263, 154);
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
            this.nudOverloadRetryAttempts.Size = new System.Drawing.Size(85, 20);
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
            this.lblOverloadRetryAttempts.Location = new System.Drawing.Point(263, 138);
            this.lblOverloadRetryAttempts.Name = "lblOverloadRetryAttempts";
            this.lblOverloadRetryAttempts.Size = new System.Drawing.Size(82, 13);
            this.lblOverloadRetryAttempts.TabIndex = 20;
            this.lblOverloadRetryAttempts.Text = "Overl. Retry Att.";
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
            this.groupBox4.Size = new System.Drawing.Size(571, 67);
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
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.txtTrailingProfitStart);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.txtOrderType);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.txtOrderStatus);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.txtOrderSide);
            this.groupBox5.Controls.Add(this.txtOrderSize);
            this.groupBox5.Controls.Add(this.txtOrderPrice);
            this.groupBox5.Location = new System.Drawing.Point(839, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(426, 67);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Open Orders";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(348, 25);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 13);
            this.label36.TabIndex = 31;
            this.label36.Text = "Stop Lo / Pr";
            // 
            // txtTrailingProfitStart
            // 
            this.txtTrailingProfitStart.Enabled = false;
            this.txtTrailingProfitStart.Location = new System.Drawing.Point(351, 41);
            this.txtTrailingProfitStart.Name = "txtTrailingProfitStart";
            this.txtTrailingProfitStart.Size = new System.Drawing.Size(63, 20);
            this.txtTrailingProfitStart.TabIndex = 30;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(279, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 13);
            this.label27.TabIndex = 29;
            this.label27.Text = "Type";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Enabled = false;
            this.txtOrderType.Location = new System.Drawing.Point(282, 41);
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.Size = new System.Drawing.Size(63, 20);
            this.txtOrderType.TabIndex = 28;
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
            // tmrCandleUpdaterhd
            // 
            this.tmrCandleUpdaterhd.Interval = 300000;
            this.tmrCandleUpdaterhd.Tick += new System.EventHandler(this.tmrCandleUpdaterhd_Tick);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.label37);
            this.groupBox9.Controls.Add(this.nudATRMultiplier);
            this.groupBox9.Controls.Add(this.nudATRPeriod);
            this.groupBox9.Controls.Add(this.nudMA1);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.nudMA2);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Location = new System.Drawing.Point(12, 191);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(204, 111);
            this.groupBox9.TabIndex = 23;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Indicator settings";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(149, 47);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(41, 13);
            this.label38.TabIndex = 14;
            this.label38.Text = "ATR M";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(149, 21);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 13;
            this.label37.Text = "ATR";
            // 
            // nudATRMultiplier
            // 
            this.nudATRMultiplier.DecimalPlaces = 1;
            this.nudATRMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudATRMultiplier.Location = new System.Drawing.Point(99, 45);
            this.nudATRMultiplier.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudATRMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudATRMultiplier.Name = "nudATRMultiplier";
            this.nudATRMultiplier.Size = new System.Drawing.Size(44, 20);
            this.nudATRMultiplier.TabIndex = 12;
            this.nudATRMultiplier.Value = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.nudATRMultiplier.ValueChanged += new System.EventHandler(this.nudATRMultiplier_ValueChanged);
            // 
            // nudATRPeriod
            // 
            this.nudATRPeriod.Location = new System.Drawing.Point(99, 19);
            this.nudATRPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudATRPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudATRPeriod.Name = "nudATRPeriod";
            this.nudATRPeriod.Size = new System.Drawing.Size(44, 20);
            this.nudATRPeriod.TabIndex = 11;
            this.nudATRPeriod.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudATRPeriod.ValueChanged += new System.EventHandler(this.nudATRPeriod_ValueChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.nudLongLimit);
            this.groupBox10.Controls.Add(this.nudShortLimit);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.nudPriceChange);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.nupRSIDifferenceThree);
            this.groupBox10.Location = new System.Drawing.Point(220, 191);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(143, 111);
            this.groupBox10.TabIndex = 24;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Strategy 3";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(74, 69);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(55, 13);
            this.label42.TabIndex = 34;
            this.label42.Text = "Long Limit";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 69);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 13);
            this.label41.TabIndex = 33;
            this.label41.Text = "Short Limit";
            // 
            // nudLongLimit
            // 
            this.nudLongLimit.DecimalPlaces = 1;
            this.nudLongLimit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudLongLimit.Location = new System.Drawing.Point(77, 85);
            this.nudLongLimit.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudLongLimit.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudLongLimit.Name = "nudLongLimit";
            this.nudLongLimit.Size = new System.Drawing.Size(60, 20);
            this.nudLongLimit.TabIndex = 32;
            this.nudLongLimit.Value = new decimal(new int[] {
            7400,
            0,
            0,
            0});
            // 
            // nudShortLimit
            // 
            this.nudShortLimit.DecimalPlaces = 1;
            this.nudShortLimit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudShortLimit.Location = new System.Drawing.Point(6, 85);
            this.nudShortLimit.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudShortLimit.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudShortLimit.Name = "nudShortLimit";
            this.nudShortLimit.Size = new System.Drawing.Size(60, 20);
            this.nudShortLimit.TabIndex = 31;
            this.nudShortLimit.Value = new decimal(new int[] {
            6500,
            0,
            0,
            0});
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(72, 21);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(70, 13);
            this.label40.TabIndex = 30;
            this.label40.Text = "Price change";
            // 
            // nudPriceChange
            // 
            this.nudPriceChange.DecimalPlaces = 1;
            this.nudPriceChange.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudPriceChange.Location = new System.Drawing.Point(6, 19);
            this.nudPriceChange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPriceChange.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudPriceChange.Name = "nudPriceChange";
            this.nudPriceChange.Size = new System.Drawing.Size(60, 20);
            this.nudPriceChange.TabIndex = 29;
            this.nudPriceChange.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(72, 47);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 13);
            this.label39.TabIndex = 28;
            this.label39.Text = "RSI diff to 50";
            // 
            // nupRSIDifferenceThree
            // 
            this.nupRSIDifferenceThree.Location = new System.Drawing.Point(6, 45);
            this.nupRSIDifferenceThree.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nupRSIDifferenceThree.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nupRSIDifferenceThree.Name = "nupRSIDifferenceThree";
            this.nupRSIDifferenceThree.Size = new System.Drawing.Size(60, 20);
            this.nupRSIDifferenceThree.TabIndex = 27;
            this.nupRSIDifferenceThree.Value = new decimal(new int[] {
            7,
            0,
            0,
            -2147483648});
            // 
            // nudLeverage
            // 
            this.nudLeverage.DecimalPlaces = 2;
            this.nudLeverage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLeverage.Location = new System.Drawing.Point(6, 178);
            this.nudLeverage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLeverage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.nudLeverage.Name = "nudLeverage";
            this.nudLeverage.Size = new System.Drawing.Size(60, 20);
            this.nudLeverage.TabIndex = 27;
            this.nudLeverage.Value = new decimal(new int[] {
            500,
            0,
            0,
            131072});
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(72, 180);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(52, 13);
            this.label43.TabIndex = 33;
            this.label43.Text = "Leverage";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 551);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles1d)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles1h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMA1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExecuteTrailingProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartTrailingProfit)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentEarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRSIDifference)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExecuteStopLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartStopLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentToTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPrice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverloadRetryAttempts)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATRMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudATRPeriod)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShortLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRSIDifferenceThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeverage)).EndInit();
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
        private System.Windows.Forms.TextBox txtWebSocketFails;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkStopLoss;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown nudExecuteStopLoss;
        private System.Windows.Forms.NumericUpDown nudStartStopLoss;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtOrderType;
        private System.Windows.Forms.TextBox txtStartStopLoss;
        private System.Windows.Forms.TextBox txtExecuteStopLoss;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtCancelStopLoss;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtPercentBTCEarned;
        private System.Windows.Forms.TextBox txtBTCEarned;
        private System.Windows.Forms.TextBox txtCurrentBalance;
        private System.Windows.Forms.TextBox txtBalanceStart;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox ddlStrategyType;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.NumericUpDown nudExecuteTrailingProfit;
        private System.Windows.Forms.NumericUpDown nudStartTrailingProfit;
        private System.Windows.Forms.Timer tmrCandleUpdaterhd;
        private System.Windows.Forms.DataGridView dgvCandles1d;
        private System.Windows.Forms.DataGridView dgvCandles1h;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtTrailingProfitStart;
        private System.Windows.Forms.TextBox txtTPExecute;
        private System.Windows.Forms.TextBox txtTPStart;
        private System.Windows.Forms.TextBox txtTPTimer;
        private System.Windows.Forms.CheckBox chkManualControl;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown nudATRMultiplier;
        private System.Windows.Forms.NumericUpDown nudATRPeriod;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown nudPriceChange;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown nupRSIDifferenceThree;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.NumericUpDown nudLongLimit;
        private System.Windows.Forms.NumericUpDown nudShortLimit;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.NumericUpDown nudLeverage;
    }
}

