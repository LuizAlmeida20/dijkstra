using ConsoleApp1;
namespace ConsoleApp1;


public class Vertice {
    private string verticeId;
    private int verticePredecessor;
    private int? valorAtual; //nullable int
    private bool visitado;
    private bool? origem;
    private List<Aresta> arestasList = new List<Aresta>();
    
    public Vertice(string verticeId, bool? origem) {
        this.verticeId = verticeId;
        this.verticePredecessor = verticePredecessor;
        this.valorAtual = null;
        this.valorAtual = null;
        this.visitado = false;
        this.origem = origem;
    }
    
    public string GetVerticeId() {
        return this.verticeId;
    }
    public int GetVerticePredecessor() {
        return this.verticePredecessor;
    }
    public int? GetValorAtual() {
        return this.valorAtual;
    }
    public List<Aresta> GetArestas() {
        return this.arestasList;
    }

    public bool? GetOrigem() {
        return this.origem;
    }
    
    public void SetVerticeId(string verticeId) {
        this.verticeId = verticeId;
    }
    public void SetVerticePredecessor(int verticePredecessor) {
        this.verticePredecessor = verticePredecessor;
    }
    public void SetValorAtual(int valorAtual) {
        this.valorAtual = valorAtual;
    }

    public void AddAresta(Aresta aresta) {
        this.arestasList.Add(aresta);
    }

    public void MarcarComoVisitado() {
        this.visitado = true;
    }
    
    public Vertice BuscarVerticeAdjacenteComMenorPeso() {
        Vertice verticeSelecionado = this.arestasList[0].GetVerticeDestino();
        int pesoPrimeiraAresta = this.arestasList[0].GetPeso();
        foreach (Aresta aresta in this.arestasList) {
            if (aresta.GetPeso() < pesoPrimeiraAresta) {
                verticeSelecionado = aresta.GetVerticeDestino();
            }
        }
        return verticeSelecionado;
    }
}