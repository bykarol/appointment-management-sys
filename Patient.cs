namespace AppointmentManagementSys
{
  class Patient : Person // Inherit from the abstract class Person
  {
    public List<MedicalHistory> History { get; }

    public Patient(string firstName, string lastName, DateTime dateOfBirth, Gender gender, string address, string phoneNumber)
        : base(firstName, lastName, dateOfBirth, gender, address, phoneNumber)
    {
      History = new List<MedicalHistory>(); // empty list
    }

    public override void DisplayInformation()
    {
      base.DisplayInformation();
      try
      {
        if (History != null && History.Count > 0)
        {
          Console.WriteLine($"Medical History:");
          int counter = 1;
          foreach (MedicalHistory record in History)
          {
            Console.WriteLine($"Record #{counter}.");
            record.DisplayMedicalHistoryInfo();
            counter++;
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error displaying medical history: {ex.Message}");
      }
    }

    public void AddMedicalRecord(string description)
    {
      MedicalHistory record = new MedicalHistory(description);
      History.Add(record);
    }
  }
}
