namespace TurboAzureTask.Models;

public class Car
{
    public string Id { get; set; }
    public string CarName { get; set; }
    public string? CarModel { get; set; }
    public int CarYear { get; set; }
    public int CarPrice { get; set; }
    public string? CarImage { get; set; }
    public string? CarDescription { get; set; }
    public string? CarCity { get; set; }
    public string? CarColor { get; set; }
    public string? CarManufacturer { get; set; }
    public decimal CarKilometer { get; set; }
    public DateTime? CarDate { get; set; }
    public string? CarStatus { get; set; }
}