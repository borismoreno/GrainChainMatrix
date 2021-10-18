using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainChainMatrix.MVVM.ViewModel
{
    public class ResultadoViewModel
    {
        public List<List<char>> DistribucionBombillos(List<List<char>> matriz)
        {
            List<List<char>> retorno = new List<List<char>>();
            List<char> fila = null;
            bool iluminado = false;
            for (int i = 0; i < matriz.Count; i++)
            {
                fila = new List<char>();
                iluminado = false;
                for (int j = 0; j < matriz[i].Count; j++)
                {
                    if (matriz[i][j] == '1')
                    {
                        fila.Add('P');
                        iluminado = false;
                    }
                    else
                    {
                        if (!iluminado)
                        {
                            if (i == 0)
                            {
                                fila.Add('B');
                                iluminado = true;
                            }
                            else
                            {
                                if (retorno[i-1][j] == 'B' || retorno[i - 1][j] == 'T')
                                {
                                    fila.Add('T');
                                }
                                else
                                {
                                    fila.Add('B');
                                    iluminado = true;
                                }
                            }
                        }
                        else if (iluminado)
                        {
                            fila.Add('L');
                        }
                    }
                }
                retorno.Add(fila);
            }
            
            return retorno;
        }
    }
}
