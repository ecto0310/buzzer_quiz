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
    public MainWindow()
    {
      InitializeComponent();
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
  }
}
