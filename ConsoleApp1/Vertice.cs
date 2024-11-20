using ConsoleApp1;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ConsoleApp1;


public class Vertice
{
    private string verticeId;
    private Vertice? verticePredecessor;
    private int? valorAtual; //nullable int
    private bool visitado;
    private bool origem;
    private List<Aresta> arestasList = new List<Aresta>();

    public Vertice(string verticeId, bool origem)
    {
        this.verticeId = verticeId;
        this.verticePredecessor = verticePredecessor;
        this.valorAtual = null;
        this.valorAtual = null;
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
    public int? GetValorAtual()
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
    public void SetValorAtual(int? valorAtual)
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
            if (aresta.GetPeso() <= menorPeso && !aresta.VerificarVerticeDestinoFoiVisitado())
            {
                menorPeso = aresta.GetPeso();
                arestaSelecionado = aresta;
            }
        }
        return arestaSelecionado;
    }
}