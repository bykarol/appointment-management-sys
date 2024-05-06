using System;

namespace AppointmentManagementSys
{
  class PatientsManager
  {
    public static void PatientsManagerMenu()
    {
      Console.WriteLine("\nPATIENTS MENU:");
      Console.WriteLine("1. Register New Patient");
      Console.WriteLine("2. Search and Display Patient Information");
      Console.WriteLine("3. Update Patient Information");
      Console.WriteLine("4. Delete Patient");
      Console.Write("Enter an option from the menu: ");

      string? userInput = Console.ReadLine();
      switch (userInput)
      {
        case "1":
          RegisterPatient();
          break;
        case "2":
          SearchAndDisplayPatient();
          break;
        case "3":
          UpdatePatientInformation();
          break;
        case "4":
          DeletePatient();
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          break;
      }
    }

    // Additional methods (Patients Management)
    static void RegisterPatient()
    {
      Console.WriteLine("Registering a new patient...");
    }

    static void SearchAndDisplayPatient()
    {
      Console.WriteLine("Searching and displaying patient information...");
    }

    static void UpdatePatientInformation()
    {
      Console.WriteLine("Updating patient information...");
    }

    static void DeletePatient()
    {
      Console.WriteLine("Deleting a patient...");
    }
  }
}
