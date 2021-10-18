using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace GrainChainMatrix.MVVM.ViewModel
{
    public class CargaViewModel
    {
        public CargaViewModel()
        {

        }

        public List<List<char>> ValidarMatriz(IEnumerable<string> lineas)
        {
            List<List<char>> matriz = new List<List<char>>();
            List<char> fila = null;
            var linea = string.Empty;
            if (lineas.Count() < 2)
                return null;
            for (int i = 0; i < lineas.Count(); i++)
            {
                fila = new List<char>();
                linea = lineas.ElementAt(i);
                if (i > 0)
                {
                    if (linea.Length != lineas.ElementAt(i - 1).Length)
                        return null;
                }
                for (int j = 0; j < linea.Length; j++)
                {
                    if (linea[j] != '1' && linea[j] != '0')
                        return null;
                    else
                        fila.Add(linea[j]);
                }
                matriz.Add(fila);
            }
            return matriz;
        }
    }
}
