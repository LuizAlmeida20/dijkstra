namespace ConsoleApp1;

public class VerticeDTO
{
    public string verticeId { get; set; }
    public Vertice? verticePredecessor { get; set; }
    public int valorAtual { get; set; } //nullable int
    public bool visitado { get; set; }
    public bool origem { get; set; }
    public List<ArestaDTO> arestasList { get; set; } = new List<ArestaDTO>();

    public VerticeDTO(
        string verticeId,
        Vertice? verticePredecessor,
        int valorAtual,
        bool visitado,
        bool origem,
        List<Aresta> arestasDaEntidade
    ) {
        this.verticeId = verticeId;
        this.verticePredecessor = verticePredecessor;
        this.valorAtual = valorAtual;
        this.visitado = visitado;
        this.origem = origem;
        foreach (Aresta aresta in arestasDaEntidade)
        {
            string arestaId = aresta.GetArestaId();
            int peso = aresta.GetPeso();
            Vertice verticeOrigem = aresta.GetVerticeOrigem();
            Vertice verticeDestino = aresta.GetVerticeDestino();
        }
    }
}