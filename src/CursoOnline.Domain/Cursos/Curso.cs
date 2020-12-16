using CursoOnline.Domain.Cursos.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Domain.Cursos
{
    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if(String.IsNullOrEmpty(nome) || cargaHoraria <= 0 || valor <= 0)
            {
                throw new ArgumentException("Parametros inválidos!");
            }

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }

    }
}
