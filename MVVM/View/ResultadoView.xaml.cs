using GrainChainMatrix.MVVM.ViewModel;
using System;
using System.Collections.Generic;
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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace GrainChainMatrix.MVVM.View
{
    /// <summary>
    /// Interaction logic for ResultadoView.xaml
    /// </summary>
    public partial class ResultadoView : UserControl
    {
        App variables = Application.Current as App;
        public ResultadoView()
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (variables.Matriz == null)
            {
                notifier.ShowError(FindResource("errorCargaResultados").ToString());
                return;
            }
            ResultadoViewModel resultadoViewModel = new ResultadoViewModel();
            var retorno = resultadoViewModel.DistribucionBombillos(variables.Matriz);
            Habitacion.Columns = retorno.ElementAt(1).Count;
            Habitacion.Rows = retorno.Count;
            for (int i = 0; i < retorno.Count; i++)
            {
                for (int j = 0; j < retorno[i].Count; j++)
                {
                    Habitacion.Children.Add(new Rectangle()
                    {
                        Fill = ObtenerColor(retorno[i][j])
                    });
                }
            }
        }

        private SolidColorBrush ObtenerColor(char flag)
        {
            SolidColorBrush colorBrush = new SolidColorBrush();
            switch (flag)
            {
                case 'B':
                    colorBrush = Brushes.Yellow;
                    break;
                case 'T':
                case 'L':
                    colorBrush = Brushes.YellowGreen;
                    break;
                default:
                    colorBrush = Brushes.Black;
                    break;
            }
            return colorBrush;
        }
    }
}
