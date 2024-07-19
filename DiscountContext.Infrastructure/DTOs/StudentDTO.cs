namespace YourProject.Infrastructure.DTOs;
public class StudentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AddressStreet { get; set; }
    public string AddressNumber { get; set; }
    public string AddressNeighbourhood { get; set; }
    public string AddressCity { get; set; }
    public string AddressState { get; set; }
    public string AddressCountry { get; set; }
    public string AddressZipCode { get; set; }
    public int BusinessType { get; set; } 
}