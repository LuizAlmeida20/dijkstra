namespace ConsoleApp1;

public class Aresta
{
    private string arestaId;
    private int peso;
    private Vertice verticeOrigem;
    private Vertice verticeDestino;

    public Aresta(string arestaId, int peso, Vertice verticeOrigem, Vertice verticeDestino)
    {
        this.arestaId = arestaId;
        this.peso = peso;
        this.verticeOrigem = verticeOrigem;
        this.verticeDestino = verticeDestino;
    }

    public string GetArestaId()
    {
        return this.arestaId;
    }
    public int GetPeso()
    {
        return this.peso;
    }
    public string GetVerticeOrigemId()
    {
        return this.verticeOrigem.GetVerticeId();
    }
    
    public Vertice GetVerticeOrigem()
    {
        return this.verticeOrigem;
    }
    public Vertice GetVerticeDestino()
    {
        return this.verticeDestino;
    }

    public void SetArestaId(string arestaId)
    {
        this.arestaId = arestaId;
    }
    public void SetPeso(int peso)
    {
        this.peso = peso;
    }
    public void SetVerticeOrigem(Vertice verticeOrigem)
    {
        this.verticeOrigem = verticeOrigem;
    }
    public void SetVerticeDestino(Vertice verticeDestino)
    {
        this.verticeDestino = verticeDestino;
    }

    public bool VerificarVerticeDestinoFoiVisitado()
    {
        return this.verticeDestino.GetVisitado();
    }
    
    

}