namespace ConsoleApp1;

public class ArestaDTO
{
    public string arestaId;
    public int peso;
    public Vertice verticeOrigem;
    public Vertice verticeDestino;

    public ArestaDTO(
        string arestaId,
        int peso,
        Vertice verticeOrigem,
        Vertice verticeDestino
    ) {
        this.arestaId = arestaId;
        this.peso = peso;
        this.verticeOrigem = verticeOrigem;
        this.verticeDestino = verticeDestino;
    }
}