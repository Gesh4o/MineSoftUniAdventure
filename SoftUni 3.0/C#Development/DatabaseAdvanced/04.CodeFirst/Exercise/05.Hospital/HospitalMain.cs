namespace _05.Hospital
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    // This project was directly used for task №8.
    class HospitalMain
    {
        private static HospitalDbContext dbContext = new HospitalDbContext();

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "exit")
            {
                string[] commandArgs = command.Split(' ');
                try
                {
                    switch (commandArgs[0])
                    {
                        case "create":
                            CreateEntity(commandArgs);
                            break;
                        case "find":
                            FindEnity(commandArgs);
                            break;
                        case "help":
                            DisplayHelpMessage();
                            break;
                        default:
                            Console.WriteLine($"Command: \"{command}\" not supported!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
        }

        private static void DisplayHelpMessage()
        {
            Console.WriteLine("Go help yourself!!!");
        }

        private static void FindEnity(string[] commandArgs)
        {
            ValidateLength(commandArgs.Length - 1, 2);
            string entityName = commandArgs[1];
            int entityId;
            if (!int.TryParse(commandArgs[2], out entityId))
            {
                new ArgumentException($"Argument: \"{commandArgs[2]}\"  is invalid ID!");
            }

            switch (entityName)
            {
                case "patient":
                    Patient patient = dbContext.Patients.Include(p => p.Visitations).FirstOrDefault(p=> p.Id == entityId);

                    if (patient == null)
                    {
                        throw new ArgumentException("Patient was not found!");
                    }

                    // Just for testing.
                    foreach (Visitation v in patient.Visitations)
                    {
                        Console.WriteLine(v.Patient.FirstName);
                    }

                    Console.WriteLine(patient.ToString());
                    break;
                case "medicament":
                    Medicament medicament = dbContext.Medicaments.Find(entityId);

                    if (medicament == null)
                    {
                        throw new ArgumentException("Medicament was not found!");
                    }

                    Console.WriteLine(medicament.ToString());
                    break;
                case "visitation":
                    Visitation visitation = dbContext.Visitations.Find(entityId);

                    if (visitation == null)
                    {
                        throw new ArgumentException("Patient was not found!");
                    }

                    Console.WriteLine(visitation.ToString());
                    break;
                case "diagnose":
                    Diagnose diagnose = dbContext.Diagnoses.Find(entityId);

                    if (diagnose == null)
                    {
                        throw new ArgumentException("Patient was not found!");
                    }

                    Console.WriteLine(diagnose.ToString());
                    break;
                default:
                    throw new ArgumentException($"Entity type: \" {entityName}\" was not found!");
            }
        }

        private static void CreateEntity(string[] commandArgs)
        {
            int resultId;
            string entityName = commandArgs[1];

            switch (entityName)
            {
                case "patient":
                    resultId = InsertNewPatient(commandArgs);
                    break;
                case "diagnose":
                    resultId = InsertNewDiagnose(commandArgs);
                    break;
                case "medicament":
                    resultId = InsertNewMedicament(commandArgs);
                    break;
                case "visitation":
                    resultId = InsertNewVisitation(commandArgs);
                    break;
                case "doctor":
                    resultId = InsertNewDoctor(commandArgs);
                    break;
                default:
                    Console.WriteLine($"Entity: \"{entityName}\" not supported!");
                    return;
            }

            Console.WriteLine($"{entityName} with ID: {resultId} was made!");
        }

        private static int InsertNewDoctor(string[] commandArgs)
        {
            int resultId;
            ValidateLength(commandArgs.Length - 2, 2);

            Doctor doctor = new Doctor(commandArgs[2], commandArgs[3]);
            dbContext.Doctors.Add(doctor);
            dbContext.SaveChanges();

            resultId = doctor.Id;
            return resultId;
        }

        private static int InsertNewVisitation(string[] commandArgs)
        {
            int patientId;
            int doctorId;
            int resultId;
            ValidateLength(commandArgs.Length - 2, 3);

            DateTime date;
            if (!DateTime.TryParse(commandArgs[2], out date))
            {
                throw new ArgumentException($"Argument: \"{commandArgs[2]}\"  is invalid Date!");
            }

            if (!int.TryParse(commandArgs[3], out patientId))
            {
                throw new ArgumentException($"Argument: \"{commandArgs[3]}\"  is invalid ID!");
            }

            if (!int.TryParse(commandArgs[4], out doctorId))
            {
                throw new ArgumentException($"Argument: \"{commandArgs[4]}\"  is invalid ID!");
            }

            Patient patientVisitation = dbContext.Patients.Find(patientId);
            if (patientVisitation == null)
            {
                throw new ArgumentException($"Patient with ID: \"{patientId}\" was not found!");
            }

            Doctor doctorVisitation = dbContext.Doctors.Find(doctorId);
            if (patientVisitation == null)
            {
                throw new ArgumentException($"Doctor with ID: \"{doctorId}\" was not found!");
            }

            Visitation visitation = new Visitation(date, patientVisitation, doctorVisitation);
            dbContext.Visitations.Add(visitation);

            dbContext.SaveChanges();
            resultId = visitation.Id;
            return resultId;
        }

        private static int InsertNewMedicament(string[] commandArgs)
        {
            int patientId;
            int resultId;

            ValidateLength(commandArgs.Length - 2, 2);

            string medicamentName = commandArgs[2];
            if (!int.TryParse(commandArgs[3], out patientId))
            {
                throw new ArgumentException($"Argument: \"{commandArgs[3]}\"  is invalid ID!");
            }

            Patient patientMedicament = dbContext.Patients.Find(patientId);
            if (patientMedicament == null)
            {
                throw new ArgumentException($"Patient with ID: \"{patientId}\" was not found!");
            }

            Medicament medicament = new Medicament(medicamentName, patientMedicament);
            dbContext.Medicaments.Add(medicament);

            dbContext.SaveChanges();
            resultId = medicament.Id;

            return resultId;
        }

        private static int InsertNewDiagnose(string[] commandArgs)
        {
            int patientId;
            int resultId;
            Patient patientDiagnose;

            ValidateLength(commandArgs.Length - 2, 2);

            string diagnoseName = commandArgs[2];
            if (!int.TryParse(commandArgs[3], out patientId))
            {
                throw new ArgumentException($"Argument: \"{commandArgs[3]}\"  is invalid ID!");
            }

            patientDiagnose = dbContext.Patients.Find(patientId);
            if (patientDiagnose == null)
            {
               throw new ArgumentException($"Patient with ID: \"{patientId}\" was not found!");
            }

            Diagnose diagnose = new Diagnose(diagnoseName, patientDiagnose);
            dbContext.Diagnoses.Add(diagnose);

            dbContext.SaveChanges();
            resultId = diagnose.Id;

            return resultId;
        }

        private static int InsertNewPatient(string[] commandArgs)
        {
            int resultId;
            ValidateLength(commandArgs.Length - 2, 3);

            bool hasMedicalInsurance;
            if (!bool.TryParse(commandArgs[4], out hasMedicalInsurance))
            {
                new ArgumentException("Medical insurance argument must be valid!");
            }

            string firstName = commandArgs[2];
            string lastName = commandArgs[3];

            Patient patient = new Patient(firstName, lastName, hasMedicalInsurance);
            dbContext.Patients.Add(patient);

            dbContext.SaveChanges();
            resultId = patient.Id;
            return resultId;
        }

        private static void ValidateLength(int actialLength,int  expectedLength)
        {
            if (actialLength != expectedLength)
            {
                throw new ArgumentException("Arguments count do not match!");
            }
        }
    }
}
