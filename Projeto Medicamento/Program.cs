using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Program
    {
        static Medicamento medicamento;
        static Medicamentos medicamentos;

        static void Main(string[] args)
        {
            medicamentos = new Medicamentos();
            int opcao = 1;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(55, 02); Console.WriteLine("FARMÁCIA LEON");
                Console.SetCursorPosition(30, 10); Console.WriteLine("################################################################");
                Console.SetCursorPosition(30, 11); Console.WriteLine("# 0. Finalizar processo                                        #");
                Console.SetCursorPosition(30, 12); Console.WriteLine("# 1. Cadastrar medicamento                                     #");
                Console.SetCursorPosition(30, 13); Console.WriteLine("# 2. Consultar medicamento (sintético: informar dados)         #");
                Console.SetCursorPosition(30, 14); Console.WriteLine("# 3. Consultar medicamento (analítico: informar dados + lotes) #");
                Console.SetCursorPosition(30, 15); Console.WriteLine("# 4. Comprar medicamento (cadastrar lote)                      #");
                Console.SetCursorPosition(30, 16); Console.WriteLine("# 5. Vender medicamento (abater do lote mais antigo)           #");
                Console.SetCursorPosition(30, 17); Console.WriteLine("# 6. Listar medicamentos (informar dados sintéticos)           #");
                Console.SetCursorPosition(30, 18); Console.WriteLine("################################################################");
                Console.SetCursorPosition(30, 22); Console.Write("Digite uma opção: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao > 6)
                    {
                        Console.WriteLine("*** Esta opção é invalida, escolha a opção entre 0 e 6 ***");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("*** Esta opção é invalida, escolha a opção entre 0 e 6 ***");
                    continue;
                }
                switch (opcao)
                {
                    case 1: cadastrarMedicamento(); break;
                    case 2: consultarSintetico(); break;
                    case 3: consultarAnalitico(); break;
                    case 4: comprarMedicamento(); break;
                    case 5: venderMedicamento(); break;
                    case 6: listarMedicamentos(); break;
                }
            }
            while (opcao != 0);
        }

        #region metodos funcionais
        static public void cadastrarMedicamento()
        {
            int idMed, idlote, qtde;
            string nome, laboratorio;
            DateTime venc;

            //Cadastrar medicamentos
            Console.WriteLine("Preencha os dados a seguir: ");
            Console.WriteLine();
            Console.Write("Id: "); idMed = entraInt();
            Console.Write("Nome: "); nome = Console.ReadLine();
            Console.Write("Laboratório: "); laboratorio = Console.ReadLine();

            //Cadastrar lote do medicamento
            Console.Write("Id do Lote: "); idlote = entraInt();
            Console.Write("Quantidade: "); qtde = entraInt();
            Console.Write("\nData de Vencimento: ");
            venc = entraData();

            if (venc != DateTime.MinValue)
            {
                //Adicionar medicamentos na lista
                medicamento = new Medicamento(idMed, nome, laboratorio);
                medicamentos.adicionar(medicamento);
                medicamento.comprar(new Lote(idlote, qtde, venc));
                Console.WriteLine("Medicamento adicionado com sucesso!");
            }
            else
                Console.WriteLine("Tente novamente!");
                Console.ReadKey();
        }

        static public void consultarSintetico()
        {
            Console.WriteLine("Digite ID medicamento: ");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
                Console.WriteLine(medicamento.toString() + "\n");
            else
                Console.WriteLine("Medicamento não encontrado!");
            Console.ReadKey();
        }

        static public void consultarAnalitico()
        {
            Console.WriteLine("Digite ID medicamento: ");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.WriteLine(medicamento.toString() + "\n");
                foreach (Lote lote in medicamento.Lotes)
                {
                    Console.WriteLine(lote.toString());
                }
            }
            else
                Console.WriteLine("Medicamento não encontrado!");
            Console.ReadKey();
        }

        static public void comprarMedicamento()
        {
            int idLote, qtde;
            DateTime venc;
            Console.WriteLine("Digite ID medicamento: ");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.Write("ID do Lote: "); idLote = entraInt();
                Console.Write("Quantidade: "); qtde = entraInt();
                Console.Write("\nData vencimento: ");
                venc = entraData();
                if (venc != DateTime.MinValue)
                {
                    medicamento.comprar(new Lote(idLote, qtde, venc));
                    Console.WriteLine("Medicamento adicionado com sucesso!");
                }
                else
                    Console.WriteLine("Tente novamente!");
            }
            else
                Console.WriteLine("Medicamento não encontrado!");
            Console.ReadKey();
        }

        static public void venderMedicamento()
        {
            int qtde;
            Console.WriteLine("Digite ID medicamento: ");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.Write("Digite quantidade: ");
                qtde = entraInt();
                if (medicamento.vender(qtde))
                {
                    Console.WriteLine("Medicamento vendido!");
                    if (medicamentos.deletar(medicamento))
                        Console.WriteLine("Medicamento zerado e deletado!!!");
                    else
                        Console.WriteLine("Resta: " + medicamento.qtdeDisponivel() + " no estoque!!!");
                }
                else
                    Console.WriteLine("Quantidade insuficiente!!!");
            }
            else
                Console.WriteLine("Medicamento não encontrado! ");
            Console.ReadKey();
        }

        static public void listarMedicamentos()
        {
            Console.WriteLine("Lista de medicamentos!");
            if (medicamentos.ListaMedicamentos.Count != 0)
            {
                foreach (Medicamento medicamento in medicamentos.ListaMedicamentos)
                {
                    Console.WriteLine("\n " + medicamento.toString());
                }
            }
            else
                Console.WriteLine("Estoque vazio!!!");
            Console.ReadKey();
        }

        static public int entraInt()
        {
            int num = 0;
            while(num == 0)
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Write("Digite um número válido: ");
                    num = 0;
                }
            }
            return num;
        }

        static public DateTime entraData()
        {
            DateTime data;
            int dia, mes, ano;
            Console.Write("\nDia: ");
            dia = entraInt();
            Console.Write("\nMês: ");
            mes = entraInt();
            Console.Write("\nAno: ");
            ano = entraInt();
            try
            {
                data = new DateTime(ano, mes, dia);
                if (data.Ticks - DateTime.Now.Ticks > 0)
                    return data;
                else
                {
                    Console.WriteLine("Medicamento vencido! Cadastre um novo!");
                    return DateTime.MinValue;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Data inválida!\n\n");
                Console.ReadKey();
                return entraData();
            }

        }
        #endregion
    }
}
