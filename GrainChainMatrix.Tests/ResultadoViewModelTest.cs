using Xunit;
using GrainChainMatrix.MVVM.ViewModel;
using System.Collections.Generic;

namespace GrainChainMatrix.Tests
{
    public class ResultadoViewModelTest
    {
        ResultadoViewModel resultadoViewModel = new ResultadoViewModel();

        [Fact]
        public void ShouldReturnMatrixWhenIsCorrect()
        {
            List<List<char>> matriz = new List<List<char>>();
            matriz.Add(new List<char> { '1', '0', '0', '0', '0', '1', '1', '1' });
            matriz.Add(new List<char> { '0', '1', '0', '0', '0', '0', '0', '0' });
            matriz.Add(new List<char> { '0', '1', '0', '0', '0', '1', '1', '1' });
            List<List<char>> esperado = new List<List<char>>();
            esperado.Add(new List<char> { 'P', 'B', 'L', 'L', 'L', 'P', 'P', 'P' });
            esperado.Add(new List<char> { 'B', 'P', 'B', 'L', 'L', 'L', 'L', 'L' });
            esperado.Add(new List<char> { 'T', 'P', 'T', 'B', 'L', 'P', 'P', 'P' });
            var resultado = resultadoViewModel.DistribucionBombillos(matriz);
            Assert.Equal(resultado, esperado);
        }
    }
}
