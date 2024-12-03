using System;
using System.Text.Json;
using ConsoleApp1;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertice A = new Vertice("A", true);
            Vertice B = new Vertice("B", false);
            Vertice C = new Vertice("C", false);
            Vertice D = new Vertice("D", false);
            Vertice E = new Vertice("E", false);
            Vertice F = new Vertice("F", false);

            Aresta[] arestas =
            [
                new Aresta("A", 4, A, B),
                new Aresta("B", 2, A, C),
                new Aresta("C", 5, B, C),
                new Aresta("D", 10, B, D),
                new Aresta("E", 3, C, E),
                new Aresta("F", 4, E, D),
                new Aresta("G", 11, D, F),
            ];

            foreach (Aresta aresta in arestas)
            {
                if (aresta.GetVerticeOrigemId() == "A")
                {
                    A.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "B")
                {
                    B.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "C")
                {
                    C.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "D")
                {
                    D.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "E")
                {
                    E.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "F")
                {
                    F.AddAresta(aresta);
                }
            }
            Grafo grafo = new Grafo();
            grafo.AddVertice(A);
            grafo.AddVertice(B);
            grafo.AddVertice(C);
            grafo.AddVertice(D);
            grafo.AddVertice(E);
            grafo.AddVertice(F);

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
            }

            Console.WriteLine(grafo.ToString());
            // GrafoDTO grafoToJson = new GrafoDTO(grafo.GetVerticesList());
            // string json = JsonSerializer.Serialize(grafoToJson);
            // Console.WriteLine(json);
        }
    }
}