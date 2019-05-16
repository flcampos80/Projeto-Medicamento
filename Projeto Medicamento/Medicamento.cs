using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Medicamento
    {
        #region atributos
        int id;
        string nome;
        string laboratorio;
        Queue<Lote> lotes;
        #endregion

        #region propriedades
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Nome { get { return this.nome; } set { this.nome = value; } }
        public string Laboratorio { get { return this.laboratorio; } set { this.laboratorio = value; } }
        public Queue<Lote> Lotes { get { return this.lotes; } set { this.lotes = value; } }
        #endregion

        #region contrutores
        public Medicamento(int id)
        {
            this.id = id;
            lotes = new Queue<Lote>();
        }
        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }
        #endregion

        #region metodos
        public int qtdeDisponivel()
        {
            int qtde = 0;
            foreach(Lote lote in lotes)
            {
                qtde += lote.Qtde;
            }
            return qtde;
        }
        public void comprar(Lote lote)
        {
            if (pesquisar(lote)==null)
            {
                Lotes.Enqueue(lote);
            }
        }

        private object pesquisar(Lote lote)
        {
            throw new NotImplementedException();
        }

        public bool vender(int qtde)
        {
            do
            {
                if (qtdeDisponivel() >= qtde && qtde > 0)
                {
                    if (lotes.Peek().Qtde > qtde)
                    {
                        lotes.Peek().Qtde -= qtde;
                        return true;
                    }
                    else if (lotes.Peek().Qtde <= qtde)
                    {
                        qtde -= lotes.Peek().Qtde;
                        lotes.Dequeue();
                    }
                }
                else return false;
            }
            while (qtde != 0);
            return true;
        }
        public string toString()
        {
            string str = "Medicamento Id: " + id + " - Nome: " + nome + " - Laboratório: " + laboratorio + " - Disponível: " + qtdeDisponivel();
            return str;
        }
        
        #endregion
    }
}
