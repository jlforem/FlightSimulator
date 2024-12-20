namespace Remote_Flight_Controller
{
    partial class RemoteFlightController
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ipAddressTextBox = new TextBox();
            portTextBox = new TextBox();
            connectButton = new Button();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // ipAddressTextBox
            // 
            ipAddressTextBox.Location = new Point(7, 6);
            ipAddressTextBox.Name = "ipAddressTextBox";
            ipAddressTextBox.Size = new Size(100, 23);
            ipAddressTextBox.TabIndex = 0;
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(113, 5);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(59, 23);
            portTextBox.TabIndex = 1;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(178, 5);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 2;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(178, 217);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(241, 45);
            trackBar1.TabIndex = 3;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(27, 160);
            trackBar2.Name = "trackBar2";
            trackBar2.Orientation = Orientation.Vertical;
            trackBar2.Size = new Size(45, 241);
            trackBar2.TabIndex = 4;
            // 
            // RemoteFlightController
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(connectButton);
            Controls.Add(portTextBox);
            Controls.Add(ipAddressTextBox);
            Name = "RemoteFlightController";
            Text = "Form1";
            Load += RemoteFlightController_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ipAddressTextBox;
        private TextBox portTextBox;
        private Button connectButton;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
    }
}
