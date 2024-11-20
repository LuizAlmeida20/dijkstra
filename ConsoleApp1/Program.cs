using System;
using System.Text.Json;
using ConsoleApp1;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertice v0 = new Vertice("S", true);
            Vertice v1 = new Vertice("U", false);
            Vertice v2 = new Vertice("X", false);
            Vertice v3 = new Vertice("V", false);
            Vertice v4 = new Vertice("Y", false);

            Aresta[] arestas =
            [
                new Aresta("A", 10, v0, v1),
                new Aresta("B", 5, v0, v2),
                new Aresta("C", 2, v2, v3),
                new Aresta("D", 3, v3, v2),
                new Aresta("E", 1, v1, v3),
                new Aresta("F", 9, v2, v3),
                new Aresta("G", 7, v4, v0),
                new Aresta("H", 2, v2, v4),
                new Aresta("I", 4, v4, v3),
                new Aresta("J", 10, v3, v4)
            ];

            foreach (Aresta aresta in arestas)
            {
                if (aresta.GetVerticeOrigemId() == "S")
                {
                    v0.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "U")
                {
                    v1.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "X")
                {
                    v2.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "V")
                {
                    v3.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "Y")
                {
                    v4.AddAresta(aresta);
                }
            }
            Grafo grafo = new Grafo();
            grafo.AddVertice(v0);
            grafo.AddVertice(v1);
            grafo.AddVertice(v2);
            grafo.AddVertice(v3);
            grafo.AddVertice(v4);

            List<Vertice> verticesDoGrafo = grafo.GetVerticesList();
            Console.WriteLine("GRAFO = " + JsonSerializer.Serialize(verticesDoGrafo, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine("GRAFO COUNT = " + verticesDoGrafo.Count);
            for (int i = 0; i < verticesDoGrafo.Count; i++)
            {
                Vertice vertice = verticesDoGrafo[i];
                if (vertice.GetOrigem())
                {
                    vertice.MarcarComoVisitado();
                    vertice.SetValorAtual(0);
                    vertice.SetVerticePredecessor(null);
                    Aresta? arestaComMenorPeso = vertice.BuscarArestaAdjacenteComMenorPeso();
                    if (arestaComMenorPeso == null) {
                        break;
                    }
                    Vertice verticeDeDestino = arestaComMenorPeso.GetVerticeDestino();
                    verticeDeDestino.SetVerticePredecessor(vertice);
                    verticeDeDestino.SetValorAtual(vertice.GetValorAtual() + arestaComMenorPeso.GetPeso());
                    int indexVerticeDeDestino = verticesDoGrafo.FindIndex(
                        verticeDoGrafo => verticeDoGrafo.GetVerticeId() == verticeDeDestino.GetVerticeId()
                    );
                    verticesDoGrafo.RemoveAt(indexVerticeDeDestino);
                    verticesDoGrafo.Insert(i+1, verticeDeDestino);
                    Console.Write("VERTICE DESTINO AFTER ORIGIN :::");
                    Console.WriteLine(JsonSerializer.Serialize(verticeDeDestino, new JsonSerializerOptions { WriteIndented = true }));
                    Console.WriteLine(verticeDeDestino.GetValorAtual());
                    continue;
                }
                vertice.MarcarComoVisitado();
                Aresta? arestaMenorPeso = vertice.BuscarArestaAdjacenteComMenorPeso();
                if (arestaMenorPeso == null) {
                    break;
                }
                Vertice verticeDestino = arestaMenorPeso.GetVerticeDestino();
                verticeDestino.SetValorAtual(arestaMenorPeso.GetPeso() + vertice.GetValorAtual());
                verticeDestino.SetVerticePredecessor(vertice);
                int indexVerticeDestino = verticesDoGrafo.FindIndex(
                    verticeDoGrafo => verticeDoGrafo.GetVerticeId() == verticeDestino.GetVerticeId()
                );
                verticesDoGrafo.RemoveAt(indexVerticeDestino);
                verticesDoGrafo.Insert(i+1, verticeDestino);
                Console.Write("VERTICE DESTINO :::");
                Console.WriteLine(JsonSerializer.Serialize(verticeDestino, new JsonSerializerOptions { WriteIndented = true }));
            }

            Console.Write("GRAFO FINAL ::::");
            Console.WriteLine(JsonSerializer.Serialize(verticesDoGrafo, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}