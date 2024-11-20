using System;
using ConsoleApp1;

namespace MyFirstApp
{
    class Program {
        static void Main(string[] args) {
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

            foreach (Aresta aresta in arestas) {
                if (aresta.GetVerticeOrigemId() == "S") {
                    v0.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "U") {
                    v1.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "X") {
                    v2.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "V") {
                    v3.AddAresta(aresta);
                }
                if (aresta.GetVerticeOrigemId() == "Y") {
                    v4.AddAresta(aresta);
                }
            }
            Grafo grafo = new Grafo();
            grafo.AddVertice(v0);
            grafo.AddVertice(v1);
            grafo.AddVertice(v2);
            grafo.AddVertice(v3);
            grafo.AddVertice(v4);

            foreach (Vertice vertice in grafo.GetVerticesList()) {
                vertice.MarcarComoVisitado();
                Vertice verticeComMenorPeso = vertice.BuscarVerticeAdjacenteComMenorPeso();
            }
        }
    }
}