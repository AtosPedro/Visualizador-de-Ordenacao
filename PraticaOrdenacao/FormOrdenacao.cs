using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5
{
    public partial class FormOrdenacao : Form
    {


        int[] vet = new int[500]; // vetor interno para a animação

        public FormOrdenacao()
        {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        public int TipoOrdenacao = 1;
        
        public int DefineTamanho()
        {
            if (radioButton1.Checked == true)
            {
                return 1000;
            }
            else if (radioButton2.Checked == true)
            {
                return 10000;
            }
            else if (radioButton3.Checked == true)
            {
                return 50000;
            }
            else if (radioButton4.Checked == true)
            {
                return 100000;
            }
            else if (radioButton5.Checked == true)
            {
                return 500000;
            }
            else
                return 0;

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < vet.Length; i++)
            {
                e.Graphics.DrawLine(Pens.Black, i, 299, i, 299 - vet[i]);
            }
        }

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel));
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "Métodos de Ordenação - 2020/2\n\n" +
                "Desenvolvido por:\n72000996 - Atos Pedro Ferreira Rocha\n" +
                "Prof. Virgílio Borges de Oliveira\n\n" +
                "Algoritmos e Estruturas de Dados\n" +
                "Faculdade COTEMIG\n" +
                "Somente para fins didáticos.",
                "Sobre o trabalho...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void iniciaAnimacao(Action a)
        {
            if (bgw.IsBusy != true)
            {
                Preenchimento.Aleatorio(vet, 299);
                bgw.RunWorkerAsync(a);
            }
            else
            {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Métodos de Ordenação - 2020/2",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(this,
               "Animação concluída!",
               "Métodos de Ordenação - 2020/2",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }


        //BARRA DE ALGORITMOS 
        private void seleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Selecao(vet, panel));
        }
        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Insercao(vet, panel));
        }
        private void shellsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.ShellSort(vet, panel));
        }
        private void heapsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.HeapSort(vet, panel));
        }
        private void quicksortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.QuickSort(vet, 0, vet.Length - 1, panel));
        }
        private void mergesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.MergeSort(vet, 0, vet.Length - 1, panel));
        }
 


        //BARRA DE ESTÁTISTICAS
        private void bolhaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor , tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Bolha(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            
            MessageBox.Show(this,
                  $"Tamanho do vetor: {tamanhoVet}" +
                  $"\nOrdenação inicial: {nomeOrdenacao}" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método Bolha",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }
        private void seleçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor, tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            }
)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  $"Tamanho do vetor: {tamanhoVet}" +
                 $"\nOrdenação inicial: {nomeOrdenacao}" +
                 "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método Seleção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void inserçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor, tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            }; // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Insercao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  $"Tamanho do vetor: {tamanhoVet}" +
                 $"\nOrdenação inicial: {nomeOrdenacao}" +
                 "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método Inserção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void shellsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor, tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            } // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  $"Tamanho do vetor: {tamanhoVet}" +
                 $"\nOrdenação inicial: {nomeOrdenacao}" +
                 "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método ShellSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void heapsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor, tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            }// TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  $"Tamanho do vetor: {tamanhoVet}" +
                 $"\nOrdenação inicial: {nomeOrdenacao}" +
                 "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método HeapSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void quicksortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor, tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            }// TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                   $"Tamanho do vetor: {tamanhoVet}" +
                 $"\nOrdenação inicial: {nomeOrdenacao}"+
                 "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método QuickSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void mergesortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanhoVet = DefineTamanho();
            int[] vetor = new int[tamanhoVet];
            string nomeOrdenacao = "";

            switch (TipoOrdenacao)
            {
                case 1:
                    nomeOrdenacao = "Crescente";
                    Preenchimento.Crescente(vetor, tamanhoVet);
                    break;
                case 2:
                    nomeOrdenacao = "Decrescente";
                    Preenchimento.Decrescente(vetor, tamanhoVet);
                    break;
                case 3:
                    nomeOrdenacao = "Aleatório";
                    Preenchimento.Aleatorio(vetor, tamanhoVet);
                    break;
            } // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  $"Tamanho do vetor: {tamanhoVet}" +
                 $"\nOrdenação inicial: {nomeOrdenacao}" +
                 "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: TODO" +
                  "\nNº de trocas: TODO",
                  "Estatísticas do Método MergeSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void crescenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TipoOrdenacao = 1;
        }

        private void descrescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoOrdenacao = 2;
        }

        private void aleatóriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoOrdenacao = 3;
        }
    }
}
