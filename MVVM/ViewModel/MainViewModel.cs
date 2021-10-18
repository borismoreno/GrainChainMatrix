using GrainChainMatrix.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainChainMatrix.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand CargaViewCommand { get; set; }

        public RelayCommand ResultadoViewCommand { get; set; }

        public CargaViewModel CargaVM { get; set; }

        public ResultadoViewModel ResultadoVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CargaVM = new CargaViewModel();
            ResultadoVM = new ResultadoViewModel();
            CurrentView = CargaVM;
            CargaViewCommand = new RelayCommand(o => 
            {
                CurrentView = CargaVM;
            });
            ResultadoViewCommand = new RelayCommand(o =>
            {
                CurrentView = ResultadoVM;
            });
        }
    }
}
