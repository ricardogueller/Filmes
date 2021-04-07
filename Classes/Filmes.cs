using System;

namespace DIO.Filmes
{
    public class Filmes : Entidade
    {
        //Atributos
        public Genero Genero {get; set;}
        public string Titulo {get; set;}
        public string Descricao {get; set;}
        private bool Excluido {get; set;}
        public int Ano {get; set;}
    

    //Métodos
    public Filmes(int id, Genero Genero, string Titulo, string Descricao, int Ano)
    {
        this.id = id;
        this.Genero = Genero;
        this.Titulo = Titulo;
        this.Descricao = Descricao;
        this.Ano = Ano;
    }
    
    public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
        }
        public int retornaAno()
        {
            return this.Ano;
        }
        public string retornaDescricao()
        {
            return this.Descricao;
        }
        public string retornaTitulo()
		{
			return this.Titulo;
		}
		public int retornaId()
		{
			return this.id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }    
}