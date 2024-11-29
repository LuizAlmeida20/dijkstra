namespace ConsoleApp1;

public class Grafo
{
    private List<Vertice> verticesList = new List<Vertice>();

    public List<Vertice> GetVerticesList()
    {
        return this.verticesList;
    }

    public void AddVertice(Vertice vertice)
    {
        this.verticesList.Add(vertice);
    }

    public override string ToString()
    {
        List<string> arrStringVertices = new List<string>();
        foreach (Vertice vertice in verticesList)
        {
            string verticeId = vertice.GetVerticeId();
            Vertice? verticePredecessor = vertice.GetVerticePredecessor();
            string? verticePredecessorId = null;
            bool? visitado = vertice.GetVisitado();
            if (verticePredecessor is not null)
            {
                verticePredecessorId = verticePredecessor.GetVerticeId();
            }

            int? peso = vertice.GetValorAtual(); 
            string representacaoVertice = $"Vertice :::::::::::: {verticeId}\n" +
                                          $"Visitado ::::::::::: {visitado}\n" +
                                          $"Vertice predecessor: {verticePredecessorId}\n" +
                                          $"Valor :::::::::::::: {peso}";
            arrStringVertices.Add(representacaoVertice);
        }

        return string.Join("\n\n", arrStringVertices);
    }
}