using ConsoleApp1;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ConsoleApp1;


public class Vertice
{
    private string verticeId;
    private Vertice? verticePredecessor;
    private int valorAtual; //nullable int
    private bool visitado;
    private bool origem;
    private List<Aresta> arestasList = new List<Aresta>();

    public Vertice(string verticeId, bool origem)
    {
        this.verticeId = verticeId;
        this.verticePredecessor = verticePredecessor;
        this.valorAtual = int.MaxValue;
        this.visitado = false;
        this.origem = origem;
    }

    public string GetVerticeId()
    {
        return this.verticeId;
    }
    public Vertice? GetVerticePredecessor()
    {
        return this.verticePredecessor;
    }
    public int GetValorAtual()
    {
        return this.valorAtual;
    }
    public List<Aresta> GetArestas()
    {
        return this.arestasList;
    }

    public bool GetOrigem()
    {
        return this.origem;
    }

    public bool GetVisitado()
    {
        return this.visitado;
    }

    public void SetVerticeId(string verticeId)
    {
        this.verticeId = verticeId;
    }
    public void SetVerticePredecessor(Vertice? verticePredecessor)
    {
        this.verticePredecessor = verticePredecessor;
    }
    public void SetValorAtual(int valorAtual)
    {
        this.valorAtual = valorAtual;
    }

    public void AddAresta(Aresta aresta)
    {
        this.arestasList.Add(aresta);
    }

    public void MarcarComoVisitado()
    {
        this.visitado = true;
    }

    public Aresta? BuscarArestaAdjacenteComMenorPeso()
    {
        int pesoPrimeiraAresta = this.arestasList[0].GetPeso();
        int menorPeso = pesoPrimeiraAresta;
        Aresta? arestaSelecionado = null;
        foreach (Aresta aresta in this.arestasList)
        {
            if (this.ArestaTemMenorPeso(aresta, menorPeso))
            {
                menorPeso = aresta.GetPeso();
                arestaSelecionado = aresta;
            }
        }
        return arestaSelecionado;
    }

    private bool ArestaTemMenorPeso(Aresta aresta, int menorPeso)
    {
        return !aresta.VerificarVerticeDestinoFoiVisitado() && aresta.GetPeso() <= menorPeso;
    }

    public Vertice? DefinirProximoVertice()
    {
        List<Aresta> arestasDoVertice = this.arestasList;
        if (arestasDoVertice.Count == 0)
        {
            return null;
        }
        Vertice proximoVertice = null;
        int pesoPrimeiraAresta = this.arestasList[0].GetPeso();
        int menorPeso = pesoPrimeiraAresta;
        foreach (Aresta aresta in arestasDoVertice)
        {
            if (this.VerticeDestinoTemCaminhoMelhor(aresta))
            {
                proximoVertice = aresta.GetVerticeDestino();
                break;
            }

            if (this.ArestaTemMenorPeso(aresta, menorPeso))
            {
                proximoVertice = aresta.GetVerticeDestino();
            }
        }
        return proximoVertice;
    }

    public bool VerticeDestinoTemCaminhoMelhor(Aresta aresta)
    {
        Vertice verticeDestino = aresta.GetVerticeDestino();
        int pesoDaAresta = aresta.GetPeso();
        return (this.valorAtual + pesoDaAresta) < verticeDestino.GetValorAtual() && !verticeDestino.GetVisitado();
    }

    public Queue<Vertice> GetFilaDeVerticesToVisit()
    {
        Queue<Vertice> filaDeVertices = new Queue<Vertice>();
        if (this.arestasList.Count > 0)
        {
            List<Aresta> arestasAdjacentes = this.copyArestasDoVertice();

            while (arestasAdjacentes.Count > 0)
            {
                Aresta? arestaVerticeMenorPeso = null;
                int menorPeso = int.MaxValue;
                foreach (Aresta aresta in arestasAdjacentes)
                {
                    Vertice verticeDestino = aresta.GetVerticeDestino();
                    int valorVerticeDestino = verticeDestino.GetValorAtual();

                    if (verticeDestino.GetVisitado())
                        continue;

                    if (valorVerticeDestino < menorPeso)
                    {
                        arestaVerticeMenorPeso = aresta;
                        menorPeso = valorVerticeDestino;
                    }
                }

                if (arestaVerticeMenorPeso == null)
                    break;

                Vertice verticeMenorValor = arestaVerticeMenorPeso.GetVerticeDestino();

                filaDeVertices.Enqueue(verticeMenorValor);

                verticeMenorValor.MarcarComoVisitado();

                arestasAdjacentes.Remove(arestaVerticeMenorPeso);
            }
        }

        return filaDeVertices;
    }

    // public Queue<Vertice> GetFilaDeVerticesToVisit()
    // {
    //     Queue<Vertice> filaDeVertices = new Queue<Vertice>();
    //     if(this.arestasList.Count > 0)
    //     {
    //         List<Aresta> arestasAdjacentes = this.copyArestasDoVertice();
    //         Aresta primeiraArestaDaLista = arestasAdjacentes[0];
    //         Aresta arestaVerticeMenorPeso = primeiraArestaDaLista; 
    //         Vertice verticeMenorValor = arestaVerticeMenorPeso.GetVerticeDestino();
    //         int valorVerticeMenorValor = verticeMenorValor.GetValorAtual();
    //         while (arestasAdjacentes.Count > 0)
    //         {
    //             for(int i = 0; i < arestasAdjacentes.Count; i++)
    //             {
    //                 Aresta aresta = arestasAdjacentes[i];
    //                 Vertice verticeDestino = aresta.GetVerticeDestino();
    //                 int valorVerticeDestino = verticeDestino.GetValorAtual();
    //                 bool verticeDestinoFoiVisitado = verticeDestino.GetVisitado();
    //                 if (verticeDestinoFoiVisitado) {
    //                     arestasAdjacentes.Remove(arestaVerticeMenorPeso);
    //                 }
    //                 if (valorVerticeDestino < valorVerticeMenorValor)
    //                 {
    //                     arestaVerticeMenorPeso = aresta;
    //                     valorVerticeMenorValor = valorVerticeDestino;
    //                     verticeMenorValor = verticeDestino;
    //                 }
    //             }
    //             filaDeVertices.Enqueue(verticeMenorValor);
    //             arestasAdjacentes.Remove(arestaVerticeMenorPeso);
    //         }
    //     }
    //     return filaDeVertices;
    // }

    private List<Aresta> copyArestasDoVertice()
    {
        List<Aresta> arestasCopy = new List<Aresta>();
        foreach (Aresta aresta in this.arestasList)
        {
            string arestaId = aresta.GetArestaId();
            int peso = aresta.GetPeso();
            Vertice verticeOrigem = aresta.GetVerticeOrigem();
            Vertice verticeDestino = aresta.GetVerticeDestino();
            Aresta arestaCopy = new Aresta(arestaId, peso, verticeDestino, verticeDestino);
            arestasCopy.Add(arestaCopy);
        }
        return arestasCopy;
    }
}