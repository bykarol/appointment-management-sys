using System.Data.Common;

namespace AppointmentManagementSys
{
  class Patient : Person // Inherit from the abstract class Person
  {
    public string MedicalHistory { get; set; }

    public Patient(string firstName, string lastName, DateTime dateOfBirth, Gender gender, string address, string phoneNumber, string medicalHistory)
        : base(firstName, lastName, dateOfBirth, gender, address, phoneNumber)
    {
      MedicalHistory = medicalHistory;
    }

    public override void DisplayInformation()
    {
      base.DisplayInformation();
      Console.WriteLine($"Medical History: {MedicalHistory}");
    }
  }
}
