using Xunit;
using GrainChainMatrix.MVVM.ViewModel;
using System.Linq;
using System.Collections.Generic;

namespace GrainChainMatrix.Tests
{
    public class CargaViewModelTest
    {
        CargaViewModel cargaViewModel = new CargaViewModel();

        [Fact]
        public void ShouldReturnNullWhenTextIsEmpty()
        {
            IEnumerable<string> texto = Enumerable.Empty<string>();
            var resultado = cargaViewModel.ValidarMatriz(texto);
            Assert.Null(resultado);
        }

        [Fact]
        public void ShouldReturnNullWhenTextLessThanTwoLines()
        {
            IEnumerable<string> texto = new string[] {
                "10000111"
            };
            var resultado = cargaViewModel.ValidarMatriz(texto);
            Assert.Null(resultado);
        }

        [Fact]
        public void ShouldReturnNullWhenTextHasDifferentsLengthLines()
        {
            IEnumerable<string> texto = new string[] {
                "10000111", "100010"
            };
            var resultado = cargaViewModel.ValidarMatriz(texto);
            Assert.Null(resultado);
        }

        [Fact]
        public void ShouldReturnNullWhenTextHasNumbersDifferentsToZeroAndOne()
        {
            IEnumerable<string> texto = new string[] {
                "10000111", "100010"
            };
            var resultado = cargaViewModel.ValidarMatriz(texto);
            Assert.Null(resultado);
        }

        [Fact]
        public void ShouldReturnListWhenIsCorrect()
        {
            IEnumerable<string> texto = new string[] {
                "10000111", "01000000", "01000111"
            };
            List<List<char>> listado = new List<List<char>>();
            listado.Add(new List<char> { '1', '0', '0', '0', '0', '1', '1', '1' });
            listado.Add(new List<char> { '0', '1', '0', '0', '0', '0', '0', '0' });
            listado.Add(new List<char> { '0', '1', '0', '0', '0', '1', '1', '1' });
            var resultado = cargaViewModel.ValidarMatriz(texto);
            Assert.Equal(listado, resultado);
        }
    }
}
