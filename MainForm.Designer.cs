namespace Network_Serial_Ports
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.com_gbox = new System.Windows.Forms.GroupBox();
            this.comlist_cbx = new System.Windows.Forms.ComboBox();
            this.open_btn = new System.Windows.Forms.Button();
            this.port_name_lbl = new System.Windows.Forms.Label();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.baudRate_lbl = new System.Windows.Forms.Label();
            this.parity_lbl = new System.Windows.Forms.Label();
            this.baudRate_cbx = new System.Windows.Forms.ComboBox();
            this.parity_cbx = new System.Windows.Forms.ComboBox();
            this.dataBits_cbx = new System.Windows.Forms.ComboBox();
            this.stopBits_lbl = new System.Windows.Forms.Label();
            this.dataBits_lbl = new System.Windows.Forms.Label();
            this.stopBits_cbx = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.send_btn = new System.Windows.Forms.Button();
            this.rx_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.tx_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.com_gbox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // com_gbox
            // 
            this.com_gbox.Controls.Add(this.comlist_cbx);
            this.com_gbox.Controls.Add(this.open_btn);
            this.com_gbox.Controls.Add(this.port_name_lbl);
            this.com_gbox.Controls.Add(this.refresh_btn);
            this.com_gbox.Controls.Add(this.baudRate_lbl);
            this.com_gbox.Controls.Add(this.parity_lbl);
            this.com_gbox.Controls.Add(this.baudRate_cbx);
            this.com_gbox.Controls.Add(this.parity_cbx);
            this.com_gbox.Controls.Add(this.dataBits_cbx);
            this.com_gbox.Controls.Add(this.stopBits_lbl);
            this.com_gbox.Controls.Add(this.dataBits_lbl);
            this.com_gbox.Controls.Add(this.stopBits_cbx);
            this.com_gbox.Location = new System.Drawing.Point(12, 12);
            this.com_gbox.Name = "com_gbox";
            this.com_gbox.Size = new System.Drawing.Size(498, 76);
            this.com_gbox.TabIndex = 25;
            this.com_gbox.TabStop = false;
            this.com_gbox.Text = "COM";
            // 
            // comlist_cbx
            // 
            this.comlist_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comlist_cbx.FormattingEnabled = true;
            this.comlist_cbx.Location = new System.Drawing.Point(6, 40);
            this.comlist_cbx.Name = "comlist_cbx";
            this.comlist_cbx.Size = new System.Drawing.Size(76, 21);
            this.comlist_cbx.TabIndex = 7;
            // 
            // open_btn
            // 
            this.open_btn.Enabled = false;
            this.open_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.open_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open_btn.Location = new System.Drawing.Point(424, 39);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(68, 22);
            this.open_btn.TabIndex = 17;
            this.open_btn.Text = "Open";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // port_name_lbl
            // 
            this.port_name_lbl.Location = new System.Drawing.Point(6, 24);
            this.port_name_lbl.Name = "port_name_lbl";
            this.port_name_lbl.Size = new System.Drawing.Size(76, 13);
            this.port_name_lbl.TabIndex = 8;
            this.port_name_lbl.Text = "Port Name:";
            this.port_name_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(366, 38);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(52, 23);
            this.refresh_btn.TabIndex = 22;
            this.refresh_btn.Text = "Refersh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            // 
            // baudRate_lbl
            // 
            this.baudRate_lbl.Location = new System.Drawing.Point(88, 24);
            this.baudRate_lbl.Name = "baudRate_lbl";
            this.baudRate_lbl.Size = new System.Drawing.Size(71, 13);
            this.baudRate_lbl.TabIndex = 26;
            this.baudRate_lbl.Text = "Baud Rate:";
            this.baudRate_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parity_lbl
            // 
            this.parity_lbl.Location = new System.Drawing.Point(308, 24);
            this.parity_lbl.Name = "parity_lbl";
            this.parity_lbl.Size = new System.Drawing.Size(52, 13);
            this.parity_lbl.TabIndex = 33;
            this.parity_lbl.Text = "Parity:";
            this.parity_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baudRate_cbx
            // 
            this.baudRate_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRate_cbx.FormattingEnabled = true;
            this.baudRate_cbx.Location = new System.Drawing.Point(88, 40);
            this.baudRate_cbx.Name = "baudRate_cbx";
            this.baudRate_cbx.Size = new System.Drawing.Size(71, 21);
            this.baudRate_cbx.TabIndex = 27;
            // 
            // parity_cbx
            // 
            this.parity_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parity_cbx.FormattingEnabled = true;
            this.parity_cbx.Location = new System.Drawing.Point(308, 40);
            this.parity_cbx.Name = "parity_cbx";
            this.parity_cbx.Size = new System.Drawing.Size(52, 21);
            this.parity_cbx.TabIndex = 32;
            // 
            // dataBits_cbx
            // 
            this.dataBits_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBits_cbx.FormattingEnabled = true;
            this.dataBits_cbx.Location = new System.Drawing.Point(165, 40);
            this.dataBits_cbx.Name = "dataBits_cbx";
            this.dataBits_cbx.Size = new System.Drawing.Size(66, 21);
            this.dataBits_cbx.TabIndex = 28;
            // 
            // stopBits_lbl
            // 
            this.stopBits_lbl.Location = new System.Drawing.Point(237, 24);
            this.stopBits_lbl.Name = "stopBits_lbl";
            this.stopBits_lbl.Size = new System.Drawing.Size(65, 13);
            this.stopBits_lbl.TabIndex = 31;
            this.stopBits_lbl.Text = "Stop Bits:";
            this.stopBits_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataBits_lbl
            // 
            this.dataBits_lbl.Location = new System.Drawing.Point(165, 24);
            this.dataBits_lbl.Name = "dataBits_lbl";
            this.dataBits_lbl.Size = new System.Drawing.Size(66, 13);
            this.dataBits_lbl.TabIndex = 29;
            this.dataBits_lbl.Text = "Data Bits:";
            this.dataBits_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stopBits_cbx
            // 
            this.stopBits_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBits_cbx.FormattingEnabled = true;
            this.stopBits_cbx.Location = new System.Drawing.Point(237, 40);
            this.stopBits_cbx.Name = "stopBits_cbx";
            this.stopBits_cbx.Size = new System.Drawing.Size(65, 21);
            this.stopBits_cbx.TabIndex = 30;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_lbl,
            this.toolStripStatusLabel1,
            this.tx_label,
            this.rx_label,
            this.statusTimeLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 278);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(522, 22);
            this.statusStrip.TabIndex = 26;
            this.statusStrip.Text = "statusStrip";
            // 
            // status_lbl
            // 
            this.status_lbl.ActiveLinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(411, 17);
            this.status_lbl.Spring = true;
            this.status_lbl.Text = "Not Connected";
            this.status_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // statusTimeLabel
            // 
            this.statusTimeLabel.Name = "statusTimeLabel";
            this.statusTimeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // send_btn
            // 
            this.send_btn.Enabled = false;
            this.send_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.send_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send_btn.Location = new System.Drawing.Point(436, 139);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(68, 22);
            this.send_btn.TabIndex = 34;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // rx_label
            // 
            this.rx_label.Name = "rx_label";
            this.rx_label.Size = new System.Drawing.Size(33, 17);
            this.rx_label.Text = "RX: 0";
            // 
            // tx_label
            // 
            this.tx_label.Name = "tx_label";
            this.tx_label.Size = new System.Drawing.Size(32, 17);
            this.tx_label.Text = "TX: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 300);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.com_gbox);
            this.Name = "MainForm";
            this.Text = "Network Serial Ports";
            this.com_gbox.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox com_gbox;
        private System.Windows.Forms.ComboBox comlist_cbx;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Label port_name_lbl;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Label baudRate_lbl;
        private System.Windows.Forms.Label parity_lbl;
        private System.Windows.Forms.ComboBox baudRate_cbx;
        private System.Windows.Forms.ComboBox parity_cbx;
        private System.Windows.Forms.ComboBox dataBits_cbx;
        private System.Windows.Forms.Label stopBits_lbl;
        private System.Windows.Forms.Label dataBits_lbl;
        private System.Windows.Forms.ComboBox stopBits_cbx;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel status_lbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusTimeLabel;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.ToolStripStatusLabel tx_label;
        private System.Windows.Forms.ToolStripStatusLabel rx_label;
    }
}

