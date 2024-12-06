using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using ConsoleApp1;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertice RJ = new Vertice("RJ", true);
            Vertice SP = new Vertice("SP", false);
            Vertice PP = new Vertice("PP", false);
            Vertice RP = new Vertice("RP", false);
            Vertice OP = new Vertice("OP", false);
            Vertice BN = new Vertice("BN", false);

            Aresta[] arestas =
            [
                new Aresta("RJ - PP", 20, RJ, PP),
                new Aresta("RJ - SP", 60, RJ, SP),
                new Aresta("RJ - RP", 160, RJ, RP),
                new Aresta("PP - BN", 350, PP, BN),
                new Aresta("SP - RP", 30, SP, RP),
                new Aresta("SP - OP", 50, SP, OP),
                new Aresta("RP - BN", 40, RP, BN),
                new Aresta("RP - OP", 10, RP, OP),
            ];

            foreach (Aresta aresta in arestas)
            {
                if (aresta.GetVerticeOrigemId() == "RJ")
                {
                    RJ.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "PP")
                {
                    PP.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "SP")
                {
                    SP.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "RP")
                {
                    RP.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "BN")
                {
                    BN.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "OP")
                {
                    OP.AddAresta(aresta);
                }
            }
            Grafo grafo = new Grafo();
            grafo.AddVertice(RJ);
            grafo.AddVertice(SP);
            grafo.AddVertice(PP);
            grafo.AddVertice(RP);
            grafo.AddVertice(OP);
            grafo.AddVertice(BN);

            List<Vertice> verticesDoGrafo = grafo.GetVerticesList();
            for (int i = 0; i < verticesDoGrafo.Count; i++)
            {
                Vertice currentVertice = verticesDoGrafo[i];
                if (currentVertice.GetOrigem())
                {
                    currentVertice.SetValorAtual(0);
                    handleCurrentVertice(currentVertice, grafo);
                    Console.WriteLine(grafo.ToString());
                    Console.WriteLine("************************");
                    continue;
                }
                handleCurrentVertice(currentVertice, grafo);
                Console.WriteLine(grafo.ToString());
                Console.WriteLine("************************");
            }
        }
        public static void VisitarVerticesAjacentes(Vertice currentVertice, Grafo grafo)
        {
            foreach (Aresta aresta in currentVertice.GetArestas())
            {
                Console.WriteLine(grafo.ToString());
                Console.WriteLine("###############################");
                int pesoAresta = aresta.GetPeso();
                int possivelNovoValorVerticeDestino = currentVertice.GetValorAtual() + pesoAresta;
                int valorVerticeDestino = aresta.GetVerticeDestino().GetValorAtual();
                if (possivelNovoValorVerticeDestino < valorVerticeDestino)
                {
                    Vertice verticeDestino = aresta.GetVerticeDestino();
                    verticeDestino.SetValorAtual(possivelNovoValorVerticeDestino);
                    verticeDestino.SetVerticePredecessor(currentVertice);
                }
            }
        }

        public static void handleCurrentVertice(Vertice currentVertice, Grafo grafo)
        {
            VisitarVerticesAjacentes(currentVertice, grafo);
            Queue<Vertice> filaPrioridade = currentVertice.GetFilaDeVerticesToVisit();
            while (filaPrioridade.Count > 0)
            {
                Vertice verticeDaLista = filaPrioridade.Dequeue();
                VisitarVerticesAjacentes(verticeDaLista, grafo);
            }
            currentVertice.MarcarComoVisitado();
        }
    }
}