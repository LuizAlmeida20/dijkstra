namespace ConsoleApp1;

public class Grafo {
    private List<Vertice> verticesList = new List<Vertice>();

    public List<Vertice> GetVerticesList() {
        return this.verticesList;
    }

    public void AddVertice(Vertice vertice) {
        this.verticesList.Add(vertice);
    }
}