namespace Bpassignment.Models // Use your actual namespace
{
    public class Position
    {
        public string? Id { get; set; }    // Primary key (string allows you to define your own ID)
        public string? Name { get; set; }  // Name of the position (e.g., Sitting, Standing, Lying Down)
        
        // Navigation property for the related BPMeasurements
        public List<BPMeasurement>? BPMeasurements { get; set; }
    }
}