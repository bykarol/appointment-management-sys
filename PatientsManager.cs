namespace AppointmentManagementSys
{
  class PatientsManager
  {
    // List of patients
    public static List<Patient> patients { get; set; } = new List<Patient>();
    AppointmentsManager appointmentsManager = new AppointmentsManager(patients);
    public static void PatientsManagerMenu()
    {
      Console.WriteLine("\nPATIENTS MENU:");
      Console.WriteLine("1. Register New Patient");
      Console.WriteLine("2. Add Medical Records");
      Console.WriteLine("3. View Patient Information");
      Console.WriteLine("4. Edit Patient Information");
      Console.WriteLine("5. Delete Patient");
      Console.WriteLine("6. View Patient List");
      Console.WriteLine("7. Return to Main Menu");
      Console.Write("Enter an option from the menu: ");

      string userInput = Console.ReadLine();
      Console.Clear();
      switch (userInput)
      {
        case "1":
          RegisterPatient();
          break;
        case "2":
          AddMedicalRecord();
          break;
        case "3":
          DisplayPatientInformation();
          break;
        case "4":
          UpdatePatientInformation();
          break;
        case "5":
          DeletePatient();
          break;
        case "6":
          DisplayPatientList();
          break;
        case "7":
          Console.WriteLine("Returning to main menu...");
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          break;
      }
    }

    // Patients Management Methods
    private static void RegisterPatient()
    {
      try
      {
        Console.WriteLine("Registering a new patient...");
        // Gather info about the patient
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
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
        string address = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        // Data validation
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || dateOfBirth == DateTime.MinValue || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phoneNumber))
        {
          throw new ArgumentException("All fields are required to register a new patient");
        }

        // Creating a new patient
        Patient newPatient = new Patient(firstName, lastName, dateOfBirth, gender, address, phoneNumber);
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
    private static void AddMedicalRecord()
    {
      try
      {
        Console.WriteLine("Adding a record to Medical History...");
        // Get the patient data
        Patient patient = GetPatient();
        if (patient == null)
        {
          Console.WriteLine("No patient found with the provided information.");
          return;
        }
        // Getting the medical description from user
        Console.Write("Enter the medical description: ");
        string description = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(description))
        {
          throw new ArgumentException("Description cannot be empty.");
        }
        // Adding MedicalRecord to patient
        patient.AddMedicalRecord(description);
        Console.WriteLine("Medical record added successfully!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
    private static void DisplayPatientInformation()
    {
      try
      {
        // Get the patient data
        Patient patient = GetPatient();
        if (patient == null)
        {
          return;
        }
        Console.WriteLine("###################################");
        Console.WriteLine("Patient's Personal Data");
        Console.WriteLine("###################################");
        patient.DisplayInformation();
        Console.WriteLine("###################################");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }

    private static void UpdatePatientInformation()
    {
      try
      {
        Console.WriteLine("Updating patient information...");
        // Patient first name
        Console.Write("First name of the patient to be updated: ");
        string firstName = Console.ReadLine();
        // Patient last name
        Console.Write("Last name of the patient to be updated: ");
        string lastName = Console.ReadLine();

        // Validating firstname and lastname are not empty
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
          throw new ArgumentException("First name and last name cannot be empty.");
        }

        // Find the index of patient to be updated
        int index = patients.FindIndex(x => x.FirstName == firstName && x.LastName == lastName);
        if (index == -1)
        {
          Console.WriteLine("Patient not found.");
          return;
        }

        // Backup the patient info
        Patient updatedPatient = UpdatePatientData(patients[index]);
        // Remove the old patient from the list
        patients.RemoveAt(index);

        // Adding the updated patient to the list
        patients.Insert(index, updatedPatient);

        // show info updated
        Console.WriteLine("Patient's data was succesfully updated!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }

    private static void DeletePatient()
    {
      try
      {
        Console.WriteLine("Deleting a patient...");
        Patient patientToDelete = GetPatient();
        if (patientToDelete == null)
        {
          return;
        }
        // Delete the patient from patients list
        patients.Remove(patientToDelete);
        Console.WriteLine($"Patient {patientToDelete.FirstName} {patientToDelete.LastName} was successfully deleted.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }

    private static void DisplayPatientList()
    {
      try
      {
        if (patients.Count == 0)
        {
          Console.WriteLine("No patients found");
          return;
        }

        Console.WriteLine($"Displaying Patient List...");
        int counter = 1;
        foreach (Patient patient in patients)
        {
          Console.WriteLine($"#{counter}");
          patient?.DisplayInformation();
          Console.WriteLine("******************************");
          counter++;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }


    // ADITIONAL METHODS (HELPERS)
    // Function to update patient's data
    private static Patient UpdatePatientData(Patient patient)
    {
      Console.WriteLine($"\nPatient to update: {patient.FirstName} {patient.LastName}");
      Console.WriteLine("What field do you want to update?");
      Console.WriteLine("1. First Name");
      Console.WriteLine("2. Last Name");
      Console.WriteLine("3. Date of birth");
      Console.WriteLine("4. Address");
      Console.WriteLine("5. Phone Number");
      Console.Write("Enter an option from the menu: ");
      string userInput = Console.ReadLine();
      string updatedData;

      switch (userInput)
      {
        case "1":
          Console.Write("Enter first name: ");
          updatedData = Console.ReadLine();
          if (string.IsNullOrWhiteSpace(updatedData))
          {
            throw new ArgumentException("First name cannot be empty.");
          }
          patient.FirstName = updatedData;
          break;
        case "2":
          Console.Write("Enter last name: ");
          updatedData = Console.ReadLine();
          if (string.IsNullOrWhiteSpace(updatedData))
          {
            throw new ArgumentException("Last name cannot be empty.");
          }
          patient.LastName = updatedData;
          break;
        case "3":
          Console.Write("Enter date of birth (YYYY-MM-DD): ");
          updatedData = Console.ReadLine();
          if (!DateTime.TryParse(updatedData, out DateTime dateOfBirth))
          {
            throw new FormatException("Invalid date format. Please use YYYY-MM-DD format.");
          }
          patient.DateOfBirth = dateOfBirth;
          break;
        case "4":
          Console.Write("Enter address: ");
          updatedData = Console.ReadLine();
          if (string.IsNullOrWhiteSpace(updatedData))
          {
            throw new ArgumentException("Address cannot be empty.");
          }
          patient.Address = updatedData;
          break;
        case "5":
          Console.Write("Enter phone number: ");
          updatedData = Console.ReadLine();
          if (string.IsNullOrWhiteSpace(updatedData))
          {
            throw new ArgumentException("Phone number cannot be empty.");
          }
          patient.PhoneNumber = updatedData;
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.");
          break;
      }

      return patient;
    }
    public static Patient GetPatient()
    {
      Console.WriteLine("Searching patient...");
      // Patient first name
      Console.Write("Type the first name of the patient: ");
      string firstName = Console.ReadLine();
      // Patient last name
      Console.Write("Type the last name of the patient: ");
      string lastName = Console.ReadLine();

      // Validating firstname and lastname are not empty
      if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
      {
        throw new ArgumentException("First name and last name cannot be empty.");
      }

      // Look for the patient in the list of patients
      Patient? patient = patients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

      // Display the patient data
      if (patient == null)
      {
        Console.WriteLine("No patient found with the provided information.");
        return null;
      }

      return patient;
    }
  }
}


