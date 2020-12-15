using CursoOnline.Domain.Cursos;
using ExpectedObjects;
using Xunit;

namespace CursoOnline.Domain.Test.Cursos
{
    public class CursoTest
    {
        [Fact(DisplayName = "CriacaoDoCurso")]
        public void CriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Curso de informatica",
                CargaHoraria = (double) 40,
                PublicoAlvo = "Estudante",
                Valor = (double) 50
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
    }
}
