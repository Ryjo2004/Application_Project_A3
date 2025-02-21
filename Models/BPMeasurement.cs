using System;  // Ensure this is included for DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes if needed

namespace Bpassignment.Models // Use your actual namespace
{
    public class BPMeasurement
    {
        public int Id { get; set; }          // Primary key
        public int Systolic { get; set; }    // Systolic blood pressure
        public int Diastolic { get; set; }   // Diastolic blood pressure
        public DateTime MeasurementDate { get; set; }  // Date of the measurement

        // Foreign key to the Position table
        public string? PositionId { get; set; }  // This represents the relationship to Position
        public Position? Position { get; set; }  // Navigation property to the Position

        // Category based on systolic/diastolic values
        public string Category
        {
            get
            {
                if (Systolic < 120 && Diastolic < 80)
                    return "Normal";
                else if (Systolic < 130 && Diastolic < 80)
                    return "Elevated";
                else if (Systolic < 140 || Diastolic < 90)
                    return "Hypertension Stage 1";
                else if (Systolic < 180 || Diastolic < 120)
                    return "Hypertension Stage 2";
                else
                    return "Hypertensive Crisis";
            }
        }

        // Add a color based on the category
        public string Color
        {
            get
            {
                switch (Category)
                {
                    case "Normal":
                        return "green";
                    case "Elevated":
                        return "blue";
                    case "Hypertension Stage 1":
                        return "orange";
                    case "Hypertension Stage 2":
                        return "red";
                    case "Hypertensive Crisis":
                        return "darkred";
                    default:
                        return "black";
                }
            }
        }
    }
}