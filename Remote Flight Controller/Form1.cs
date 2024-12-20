using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Web.Script.Serialization;
namespace Remote_Flight_Controller
{
    public partial class RemoteFlightController : Form
    {
        public RemoteFlightController()
        {
            InitializeComponent();
        }

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
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

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
            public double Altitude;
            //Altitude in ft.
            public double Speed;
            //Plane's speed in Knts.
            public double Pitch;
            //Plane's pitch in degrees relative to horizon. Positive is planes pointing upwards, negative plane points downwards.
            public double VerticalSpeed;
            //Plane's vertical speed in Feet per minute.
            public double Throttle;
            //Current throttle setting as a percentage (i.e., 0% no throttle, 100% full throttle).
            public double ElevatorPitch;
            //Current Elevator Pitch in degrees. Positive creates upwards lift, negative downwards.
            public int WarningCode;
            //Warning code: 0 - No Warnings; 1 - Too Low (less than 1000ft); 2 - Stall.
        }

        private delegate void TelemetryUpdateDelegate(TelemetryUpdate telemetry);

        private TelemetryUpdateDelegate telemetryUpdateDelegate;

        private void UpdateTelemetry(TelemetryUpdate telemetry)
        {
            // Parse the JSON data and update the TelemetryUpdate struct
            // Example code:
            //telemetry.Altitude = parsedData["Altitude"];
            // telemetry.Speed = parsedData["Speed"];
            // ...

            // Update the UI with the telemetry data
            // Example code:
            // altitudeLabel.Text = telemetry.Altitude.ToString();
            // speedLabel.Text = telemetry.Speed.ToString();
            // ...
        }

        private void ReceiveTelemetryData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ReceiveTelemetryData));
            }
            else
            {
                var Serializer = new JsonSerializer();
                TelemetryUpdate telemetry = Serializer.Deserialize<TelemetryUpdate>(jsonData);
                UpdateTelemetry(telemetry);
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
    }
}
