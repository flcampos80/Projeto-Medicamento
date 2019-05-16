using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Medicamentos
    {
        #region atributos
        List<Medicamento> listaMedicamentos;
        #endregion

        #region propriedades
        public List<Medicamento> ListaMedicamentos { get { return listaMedicamentos; } set { this.listaMedicamentos = value; } }
        #endregion

        #region construtores
        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }
        #endregion

        #region métodos

        public void adicionar(Medicamento medicamento)
        {
            if (pesquisar(medicamento) == null)
                listaMedicamentos.Add(medicamento);
        }
        public bool deletar(Medicamento medicamento)
        {
            medicamento = pesquisar(medicamento);

            if (medicamento.Lotes.Count == 0 || medicamento.qtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(medicamento);
                return true;
            }
            else return false;
        }
        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.Equals(medicamento))
                    return m;
            }
            return null;
        }
        #endregion
    }
}
