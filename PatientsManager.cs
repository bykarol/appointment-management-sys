namespace AppointmentManagementSys
{
  class PatientsManager
  {
    // List of patients
    private static List<Patient> patients = new List<Patient>();
    public static void PatientsManagerMenu()
    {
      Console.WriteLine("\nPATIENTS MENU:");
      Console.WriteLine("1. Register New Patient");
      Console.WriteLine("2. Search and Display Patient Information");
      Console.WriteLine("3. Update Patient Information");
      Console.WriteLine("4. Delete Patient");
      Console.Write("Enter an option from the menu: ");

      string? userInput = Console.ReadLine();
      Console.Clear();
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
      try
      {
        Console.WriteLine("Registering a new patient...");
        // Gather info about the patient
        Console.Write("Enter first name: ");
        string? firstName = Console.ReadLine();
        Console.Write("Enter last name: ");
        string? lastName = Console.ReadLine();
        Console.Write("Enter date of birth (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
        {
          throw new FormatException("Invalid date format. Please use YYYY-MM-DD format.");
        }
        Console.Write("Enter gender (Male/Female): ");
        if (!Enum.TryParse(Console.ReadLine(), out Gender gender) || !Enum.IsDefined(typeof(Gender), gender))
        {
          throw new ArgumentException("Invalid gender. Please enter Male or Female.");
        }
        Console.Write("Enter address: ");
        string? address = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string? phoneNumber = Console.ReadLine();
        Console.Write("Enter medical history: ");
        string? medicalHistory = Console.ReadLine();

        // Creating a new patient object
        Patient newPatient = new Patient(firstName, lastName, dateOfBirth, gender, address, phoneNumber, medicalHistory);
        // Adding the new patient to the list of patients
        patients.Add(newPatient);
        // Message to the user
        Console.WriteLine("Patient registered successfully!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
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
