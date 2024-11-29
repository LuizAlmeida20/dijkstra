using System;
using System.Text.Json;
using ConsoleApp1;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertice S = new Vertice("S", true);
            Vertice U = new Vertice("U", false);
            Vertice X = new Vertice("X", false);
            Vertice V = new Vertice("V", false);
            Vertice Y = new Vertice("Y", false);

            Aresta[] arestas =
            [
                new Aresta("A", 10, S, U),
                new Aresta("B", 5, S, X),
                new Aresta("C", 2, X, U),
                new Aresta("D", 3, V, X),
                new Aresta("E", 1, U, V),
                new Aresta("F", 9, X, V),
                new Aresta("G", 7, Y, S),
                new Aresta("H", 2, X, Y),
                new Aresta("I", 4, Y, V),
                new Aresta("J", 10, V, Y)
            ];

            foreach (Aresta aresta in arestas)
            {
                if (aresta.GetVerticeOrigemId() == "S")
                {
                    S.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "U")
                {
                    U.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "X")
                {
                    X.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "V")
                {
                    V.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "Y")
                {
                    Y.AddAresta(aresta);
                }
            }
            Grafo grafo = new Grafo();
            grafo.AddVertice(S);
            grafo.AddVertice(U);
            grafo.AddVertice(X);
            grafo.AddVertice(V);
            grafo.AddVertice(Y);

            List<Vertice> verticesDoGrafo = grafo.GetVerticesList();
            for (int i = 0; i < verticesDoGrafo.Count; i++)
            {
                Vertice vertice = verticesDoGrafo[i];
                if (vertice.GetOrigem()) {
                    vertice.MarcarComoVisitado();
                    vertice.SetValorAtual(0);
                    vertice.SetVerticePredecessor(null);
                    Vertice? verticeDeDestino = vertice.DefinirProximoVertice();
                    if (verticeDeDestino == null) {
                        break;
                    }
                    verticeDeDestino.SetVerticePredecessor(vertice);
                    foreach (Aresta aresta in vertice.GetArestas())
                    {
                        Vertice verticeAdjascente = aresta.GetVerticeDestino(); 
                        verticeAdjascente.SetValorAtual(aresta.GetPeso());
                        verticeAdjascente.SetVerticePredecessor(vertice);
                    }
                    int indexVerticeDeDestino = verticesDoGrafo.FindIndex(
                        verticeDoGrafo => verticeDoGrafo.GetVerticeId() == verticeDeDestino.GetVerticeId()
                    );
                    verticesDoGrafo.RemoveAt(indexVerticeDeDestino);
                    verticesDoGrafo.Insert(i+1, verticeDeDestino);
                    Console.WriteLine("INDEX: " + i);
                    Console.WriteLine(grafo.ToString());
                    Console.WriteLine("==============================================");
                    continue;
                }
                vertice.MarcarComoVisitado();
                Vertice? verticeDestino = vertice.DefinirProximoVertice();
                if (verticeDestino == null) {
                    break;
                }
                foreach (Aresta aresta in vertice.GetArestas()) {
                    int pesoAtualDoVertice = vertice.GetValorAtual();
                    Vertice verticeAdjascente = aresta.GetVerticeDestino();
                    if(!verticeAdjascente.GetVisitado()) {
                        verticeAdjascente.SetValorAtual(aresta.GetPeso() + pesoAtualDoVertice);
                        verticeAdjascente.SetVerticePredecessor(vertice);
                    }
                }
                verticeDestino.SetVerticePredecessor(vertice);
                int indexVerticeDestino = verticesDoGrafo.FindIndex(
                    verticeDoGrafo => verticeDoGrafo.GetVerticeId() == verticeDestino.GetVerticeId()
                );
                verticesDoGrafo.RemoveAt(indexVerticeDestino);
                verticesDoGrafo.Insert(i+1, verticeDestino);
                Console.WriteLine("INDEX: " + i);
                Console.WriteLine(grafo.ToString());
                Console.WriteLine("==============================================");
            }

            Console.WriteLine(grafo.ToString());
        }
    }
}