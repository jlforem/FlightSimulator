using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net.Sockets;
using System.Threading;

namespace FlightController
{
    public partial class dataGrid : Form
    {
        public dataGrid()
        {
            InitializeComponent();
        }
        TcpClient client;
        Thread telemetryThread = null;
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ipAddress = ipAddressTextBox.Text;
                int port = int.Parse(portTextBox.Text);

                TcpClient client = new TcpClient(ipAddress, port);
                byte[] data = Encoding.ASCII.GetBytes("Connection Successful");
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                data = Encoding.ASCII.GetBytes("Still Here");

                while (client.Connected)
                {
                    stream.Write(data, 0, data.Length);
                    Thread.Sleep(1000);
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: {0}", ex);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }

            StartReceivingTelemetry();
        }

        struct ControlsUpdate
        {
            public double Throttle;
            //Current throttle setting as a percentage (i.e. 0% no
            //throttle, 100% full throttle).
            public double ElevatorPitch;
            //Current Elevator Pitch in degrees. Positive creates
            //upwards lift, negative downwards.
        }

        struct TelemetryUpdate
        {
            public double Altitude { get; set;}
            //Altitude in ft.
            public double Speed { get; set; }
            //Plane's speed in Knts.
            public double Pitch { get; set; }
            //Plane's pitch in degrees relative to horizon. Positive is planes pointing upwards, negative plane points downwards.
            public double VerticalSpeed { get; set; }
            //Plane's vertical speed in Feet per minute.
            public double Throttle { get; set; }
            //Current throttle setting as a percentage (i.e., 0% no throttle, 100% full throttle).
            public double ElevatorPitch { get; set; }
            //Current Elevator Pitch in degrees. Positive creates upwards lift, negative downwards.
            public int WarningCode { get; set; }
            //Warning code: 0 - No Warnings; 1 - Too Low (less than 1000ft); 2 - Stall.
        }

        private delegate void TelemetryUpdateDelegate(TelemetryUpdate telemetry);

        private TelemetryUpdateDelegate telemetryUpdateDelegate;

        private void UpdateTelemetry(TelemetryUpdate telemetry, byte[] buffer, int bytesRead)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            TelemetryUpdate parsedData = serializer.Deserialize<TelemetryUpdate>(data);

            telemetry.Altitude = parsedData.Altitude;
            telemetry.Speed = parsedData.Speed;
            telemetry.Pitch = parsedData.Pitch;
            telemetry.VerticalSpeed = parsedData.VerticalSpeed;
            telemetry.Throttle = parsedData.Throttle;
            telemetry.ElevatorPitch = parsedData.ElevatorPitch;
            telemetry.WarningCode = parsedData.WarningCode;
        }

        private void ReceiveTelemetryData()
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[256];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    // Process the received telemetry data
                    // Example code:
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    TelemetryUpdate telemetry = serializer.Deserialize<TelemetryUpdate>(data);
                    telemetryUpdateDelegate(telemetry);
                    UpdateTelemetry(telemetry);
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
        }

        private void StartReceivingTelemetry()
        {
            // Start a new thread to receive telemetry data
            Thread telemetryThread = new Thread(ReceiveTelemetryData);
            telemetryThread.Start();
        }

        private void RemoteFlightController_Load(object sender, EventArgs e)
        {
            // Assign the UpdateTelemetry method to the telemetryUpdateDelegate
            telemetryUpdateDelegate = UpdateTelemetry;

            // Start receiving telemetry data
            StartReceivingTelemetry();
        }

        private void warningHandler(int warningCode)
        {
            if (warningCode == 1)
            {
                warningTextBox.Text = "Warning: Too Low";
            }
            else if (warningCode == 2)
            {
                warningTextBox.Text = "Warning: Stall";
            }
            else if (warningCode == 0)
            {
                warningTextBox.Text = "No Warnings";
            }
        }
    }
}
