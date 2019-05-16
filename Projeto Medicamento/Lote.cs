using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Lote
    {
        #region atributos
        public int id;
        public int qtde;
        public DateTime venc;
        #endregion

        #region propriedades
        public int Id { get { return this.id; } set { id = value; } }
        public int Qtde { get { return this.qtde; } set { qtde = value; } }
        public DateTime Venc { get { return this.venc; } set { venc = value; } }
        #endregion

        #region construtores
        public Lote(){}
        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }
        #endregion

        #region metodos
        public String toString()
        {
            string str = "Lote Id: " + Id + "Quantidade: " + Qtde + "Vencimento: " + Venc;
            return str;
        }
        
        #endregion
    }
}
