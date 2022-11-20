using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace WpfApp1
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDo_Click(object sender, RoutedEventArgs e)
        {
              string _FolderPath;
              var _OpenFolderBrowser = new FolderBrowserDialog();
              var _FileDialog = new OpenFileDialog();
              _FileDialog.Multiselect = true;
              _FileDialog.InitialDirectory = @"С:\\";
              _FileDialog.ShowDialog();
              string[] photos = _FileDialog.FileNames;
              _OpenFolderBrowser.ShowDialog();
              _FolderPath = _OpenFolderBrowser.SelectedPath;
            for (int i = 0; i < photos.Length; i++)
            {
                Image image = Image.FromFile(photos[i]);
                string _photoname = Path.GetFileName(photos[i]);
                string _path = _FolderPath + @"\" + image.Width.ToString() + "x" + image.Height.ToString();
                if (Directory.Exists(_path))
                {
                    File.Copy(photos[i], _path + @"\" + _photoname, true);
                }
                else
                {
                    Directory.CreateDirectory(_path);
                    File.Copy(photos[i], _path + @"\" + _photoname, true);

                }
                image.Dispose();

            }
        }

       
    }
}
