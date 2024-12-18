using System.Net.Sockets;
using System.Text;
namespace Remote_Flight_Controller
{
    public partial class RemoteFlightController : Form
    {
        public RemoteFlightController()
        {
            InitializeComponent();
        }

        private void RemoteFlightController_Load(object sender, EventArgs e)
        {
            string ipAddress = "172.31.16.1"; // Replace with the target IP address
            int port = 9999; // Replace with the target port number

            try
            {
                // Create a TcpClient
                TcpClient client = new TcpClient(ipAddress, port);

                // Translate the passed message into ASCII and store it as a Byte array
                byte[] data = Encoding.ASCII.GetBytes("Connection Successful");

                // Get a client stream for reading and writing
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", "Connection Successful");

                // Buffer to store the response bytes
                data = new byte[256];

                // String to store the response ASCII representation
                string responseData = string.Empty;

                // Read the first batch of the TcpServer response bytes
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: {0}", ex);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

    }


}
