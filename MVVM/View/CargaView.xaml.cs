using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GrainChainMatrix.MVVM.ViewModel;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace GrainChainMatrix.MVVM.View
{
    /// <summary>
    /// Interaction logic for CargaView.xaml
    /// </summary>
    public partial class CargaView : UserControl
    {
        App variables = Application.Current as App;
        public CargaView()
        {
            InitializeComponent();
        }

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);
            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));
        });

        private void VerificarArchivo()
        {
            string fileName = variables.FileNombre;
            if (fileName != null)
                myTextBox.Text = File.ReadAllText(fileName);
        }

        private void OpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            CargaViewModel cargaViewModel = new CargaViewModel();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                var matriz = cargaViewModel.ValidarMatriz(File.ReadAllLines(openFileDialog.FileName).Where(arg => !string.IsNullOrWhiteSpace(arg)));
                if (matriz != null)
                {
                    variables.FileNombre = openFileDialog.FileName;
                    variables.Matriz = matriz;
                    notifier.ShowSuccess(FindResource("successCargaMatriz").ToString());
                }
                else
                {
                    variables.FileNombre = null;
                    variables.Matriz = null;
                    notifier.ShowError(FindResource("errorCargaMatriz").ToString());
                }
                myTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            VerificarArchivo();
        }
    }
}
