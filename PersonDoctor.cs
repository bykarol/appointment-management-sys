namespace appointment_management_sys.Classes;

public class PersonDoctor : Person
{
  public string Specialization { get; set; }
  public PersonDoctor(string firstName, string lastName, int age, string specialization) : base(firstName, lastName, age)
  {
    Specialization = specialization;
  }

  public override void DisplayInfo()
  {
    Console.WriteLine($"Doctor: {FirstName} {LastName}, Age: {Age}, Specialization: {Specialization}");
  }


}