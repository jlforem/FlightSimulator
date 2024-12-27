namespace FlightController
{
    partial class dataGrid
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
            this.connectButton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.pitchTrackBar = new System.Windows.Forms.TrackBar();
            this.throttleTrackBar = new System.Windows.Forms.TrackBar();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.throttleLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.warningTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pitchTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.throttleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(190, 10);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(118, 12);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(66, 20);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "enter port";
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Location = new System.Drawing.Point(12, 12);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.ipAddressTextBox.TabIndex = 2;
            this.ipAddressTextBox.Text = "enter ip";
            // 
            // pitchTrackBar
            // 
            this.pitchTrackBar.Location = new System.Drawing.Point(13, 174);
            this.pitchTrackBar.Name = "pitchTrackBar";
            this.pitchTrackBar.Size = new System.Drawing.Size(224, 45);
            this.pitchTrackBar.TabIndex = 3;
            // 
            // throttleTrackBar
            // 
            this.throttleTrackBar.Location = new System.Drawing.Point(13, 225);
            this.throttleTrackBar.Name = "throttleTrackBar";
            this.throttleTrackBar.Size = new System.Drawing.Size(224, 45);
            this.throttleTrackBar.TabIndex = 4;
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Location = new System.Drawing.Point(243, 174);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(30, 13);
            this.pitchLabel.TabIndex = 5;
            this.pitchLabel.Text = "pitch";
            // 
            // throttleLabel
            // 
            this.throttleLabel.AutoSize = true;
            this.throttleLabel.Location = new System.Drawing.Point(243, 225);
            this.throttleLabel.Name = "throttleLabel";
            this.throttleLabel.Size = new System.Drawing.Size(39, 13);
            this.throttleLabel.TabIndex = 6;
            this.throttleLabel.Text = "throttle";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 225);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(476, 211);
            this.dataGridView1.TabIndex = 7;
            // 
            // warningTextBox
            // 
            this.warningTextBox.Location = new System.Drawing.Point(546, 199);
            this.warningTextBox.Name = "warningTextBox";
            this.warningTextBox.ReadOnly = true;
            this.warningTextBox.Size = new System.Drawing.Size(242, 20);
            this.warningTextBox.TabIndex = 8;
            this.warningTextBox.Text = "Warning: None";
            // 
            // dataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.warningTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.throttleLabel);
            this.Controls.Add(this.pitchLabel);
            this.Controls.Add(this.throttleTrackBar);
            this.Controls.Add(this.pitchTrackBar);
            this.Controls.Add(this.ipAddressTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.connectButton);
            this.Name = "dataGrid";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pitchTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.throttleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.TrackBar pitchTrackBar;
        private System.Windows.Forms.TrackBar throttleTrackBar;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.Label throttleLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox warningTextBox;
    }
}

