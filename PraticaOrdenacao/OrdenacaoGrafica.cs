﻿using System.Threading;
using System.Windows.Forms;

namespace Pratica5
{
    class OrdenacaoGrafica
    {
        // TODO: declarar demais métodos de ordenação
        public static void Bolha(int[] vet, Panel p)
        {
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                for (j = vet.Length - 1; j > i; j--)
                {
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                    }
                }
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(8); // espera 8 milisegundos
            }
        }
        public static void Selecao(int[] vet, Panel p)
        {
            int i, j, min, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < vet.Length; j++)
                {
                    if (vet[j] < vet[min])
                    {
                        min = j;
                    }
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;

                p.Invalidate(); // redesenha o painel
                Thread.Sleep(8); // espera 8 milisegundos
            }
        }

        public static void Insercao(int[] vet, Panel p)
        {
            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                j = i - 1;
                while (j >= 0 && temp < vet[j])
                {
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = temp;

                p.Invalidate(); // redesenha o painel
                Thread.Sleep(8); // espera 8 milisegundos
            }
        }
        public static void ShellSort(int[] vet, Panel p)
        {
            int i, j, x, n;
            int h = 1;
            n = vet.Length;
            do
            {
                h = h * 3 + 1;
            } while (h <= n);
            do
            {
                h /= 3;
                for (i = h; i < n; i++)
                {
                    x = vet[i];
                    j = i;
                    while (j > (h - 1) && vet[j - h] > x)
                    {
                        vet[j] = vet[j - h];
                        j -= h;
                    }
                    vet[j] = x;
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(8); // espera 8 milisegundos
                }


            } while (h != 1);


        }

        public static void HeapSort(int[] v, Panel p)
        {
            constroiMaxHeap(v, p);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--)
            {
                troca(v, i, 0, p);
                refaz(v, 0, --n, p);
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(8); // espera 8 milisegundos
            }
        }

        private static void constroiMaxHeap(int[] v, Panel p)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
            {
                refaz(v, i, v.Length, p);
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(8); // espera 8 milisegundos
            }


        }

        private static void refaz(int[] vetor, int pos, int tamanhoDoVetor, Panel p)
        {

            int max = 2 * pos + 1, right = max + 1;
            if (max < tamanhoDoVetor)
            {

                if (right < tamanhoDoVetor && vetor[max] < vetor[right])
                    max = right;

                if (vetor[max] > vetor[pos])
                {
                    troca(vetor, max, pos, p);
                    refaz(vetor, max, tamanhoDoVetor, p);
                }
            }
        }

        public static void troca(int[] v, int j, int aposJ, Panel p)
        {
            int aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
            p.Invalidate(); // redesenha o painel
            Thread.Sleep(8); // espera 8 milisegundos
        }

        public static void QuickSort(int[] vet, int esq, int dir, Panel p)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) i++;
                while (x < vet[j]) j--;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(8); // espera 8 milisegundos
                }
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(8); // espera 8 milisegundos
            } while (i <= j);
            if (esq < j) QuickSort(vet, esq, j, p);
            if (i < dir) QuickSort(vet, i, dir, p);
        }

        private static void merge(int[] v, int i, int m, int j)
        {
            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
                temp[k - i] = v[k];
            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                if (temp[esq] <= v[dir])
                    v[i++] = temp[esq++];
                else
                    v[i++] = v[dir++];
            }
            while (esq < k)
                v[i++] = temp[esq++];
        }
        public static void MergeSort(int[] v, int i, int j)
        {
            if (i < j)
            {
                int m = (i + j) / 2;
                MergeSort(v, i, m);
                MergeSort(v, m + 1, j);
                merge(v, i, m, j); // intercala v[i..m] e v[m+1..j] em v[i..j] 
            }
        }
    }
}