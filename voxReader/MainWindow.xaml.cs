using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace voxReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VoxFile voxFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                voxFile = new VoxFile();
                voxFile.ReadStream(fileStream);
            }
        }
    }
}
