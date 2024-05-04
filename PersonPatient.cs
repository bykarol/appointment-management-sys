namespace appointment_management_sys.Classes;

public class PersonPatient : Person
{
  public string Diagnosis { get; set; }
  public PersonPatient(string firstName, string lastName, int age, string diagnosis) : base(firstName, lastName, age)
  {
    Diagnosis = diagnosis;
  }

  public override void DisplayInfo()
  {
    Console.WriteLine($"Patient: {FirstName} {LastName}, Age: {Age}, Diagnosis: {Diagnosis}");
  }


}