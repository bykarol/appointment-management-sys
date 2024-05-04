namespace appointment_management_sys.Classes;
public class Person
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public int Age { get; set; }

  public Person(string firstName, string lastName, int age)
  {
    FirstName = firstName;
    LastName = lastName;
    Age = age;
  }

  public virtual void DisplayInfo()
  {
    Console.WriteLine($"Name: {FirstName} {LastName}, Age: {Age}");
  }
}