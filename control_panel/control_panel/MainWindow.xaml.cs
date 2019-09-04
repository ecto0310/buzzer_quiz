using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace control_panel
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    SerialPort serialPort = new SerialPort();

    public MainWindow()
    {
      InitializeComponent();
      Initialize();
    }

    /// <summary>
    /// Initialization process
    /// </summary>
    private void Initialize()
    {
      serialPort.DataReceived += (s, e) =>
      {
        string readData = serialPort.ReadTo("\n");
      };
    }

    /// <summary>
    /// Event when ComboBoxSerialPortList is dropdown
    /// </summary>
    private void ComboBox_DropDownOpened(object sender, EventArgs e)
    {
      string[] Ports = SerialPort.GetPortNames();

      ComboBoxSerialPortList.Items.Clear();
      foreach (string tmp in Ports)
        ComboBoxSerialPortList.Items.Add(tmp);
    }

    /// <summary>
    /// Event when ButtonConnect is click
    /// </summary>
    private void ButtonConnect_Click(object sender, RoutedEventArgs e)
    {
      if (serialPort.IsOpen)
      {
        serialPort.Close();

        ComboBoxSerialPortList.IsEnabled = true;
        ButtonSerialReset.IsEnabled = false;
        ButtonSerialNext.IsEnabled = false;
        ButtonConnect.Content = "Connect";
      }
      else
      {
        if (ComboBoxSerialPortList.SelectedItem == null)
          return;

        serialPort.PortName = ComboBoxSerialPortList.SelectedItem.ToString();
        serialPort.Open();

        ComboBoxSerialPortList.IsEnabled = false;
        ButtonSerialReset.IsEnabled = true;
        ButtonSerialNext.IsEnabled = true;
        ButtonConnect.Content = "Disconnect";
      }
    }
  }
}
