using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Media;
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
    private SoundPlayer soundQuestion = new SoundPlayer();
    private SoundPlayer soundCorrect = new SoundPlayer();
    private SoundPlayer soundWrong = new SoundPlayer();
    private SoundPlayer soundBuzzer = new SoundPlayer();

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
      if (ConfigurationManager.AppSettings["PathSoundQuestion"] != null)
      {
        soundQuestion.SoundLocation = ConfigurationManager.AppSettings["PathSoundQuestion"];
        soundQuestion.Load();
      }
      if (ConfigurationManager.AppSettings["PathSoundCorrect"] != null)
      {
        soundCorrect.SoundLocation = ConfigurationManager.AppSettings["PathSoundCorrect"];
        soundCorrect.Load();
      }
      if (ConfigurationManager.AppSettings["PathSoundWrong"] != null)
      {
        soundWrong.SoundLocation = ConfigurationManager.AppSettings["PathSoundWrong"];
        soundWrong.Load();
      }
      if (ConfigurationManager.AppSettings["PathSoundBuzzer"] != null)
      {
        soundBuzzer.SoundLocation = ConfigurationManager.AppSettings["PathSoundBuzzer"];
        soundBuzzer.Load();
      }
    }
  }
}
