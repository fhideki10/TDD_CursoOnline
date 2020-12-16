using CursoOnline.Domain.Cursos;
using CursoOnline.Domain.Cursos.Enums;
using CursoOnline.Domain.Test.Utilidades;
using ExpectedObjects;
using System;
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
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Curso_NomeVazioNulo_RetornaArgumentException(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Curso de informatica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Curso_CargaHorariaMenorQue1_RetornaArgumentException(double cargaHorariaInvalida)
        {
            string mensagemError = "Parametros inválidos!";
            var cursoEsperado = new
            {
                Nome = "Curso de informatica",
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50
            };

            var mensagemErroDominio = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            Assert.Equal(mensagemError, mensagemErroDominio);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Curso_ValorMenorQue1_RetornaArgumentException(double valorInvalido)
        {
            string mensagemError = "Parametros inválidos!";
            var cursoEsperado = new
            {
                Nome = "Curso de informatica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido)).ValidarMensagem(mensagemError);
        }

    }



}
