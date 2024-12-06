namespace ConsoleApp1;

public class GrafoDTO
{
    public List<VerticeDTO> verticesList { get; set; } = new List<VerticeDTO>();

    public List<VerticeDTO> GetVerticesList()
    {
        return this.verticesList;
    }

    public GrafoDTO(List<Vertice> verticesList)
    {
        List<VerticeDTO> verticesDto = new List<VerticeDTO>();
        foreach (Vertice vertice in verticesList)
        {

        }
    }
}