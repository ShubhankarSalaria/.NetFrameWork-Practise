public class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string BloodGroup { get; set; }
    public List<string> MedicalHistory { get; set; }

    public Patient(int id, string name, int age, string bloodGroup)
    {
        PatientId = id;
        Name = name;
        Age = age;
        BloodGroup = bloodGroup;
        MedicalHistory = new List<string>();
    }
}

public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public List<DateTime> AvailableSlots { get; set; }

    public Doctor(int id, string name, string specialization)
    {
        DoctorId = id;
        Name = name;
        Specialization = specialization;
        AvailableSlots = new List<DateTime>();
    }
}

public class Appointment
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Status { get; set; }

    public Appointment(int id, int patientId, int doctorId, DateTime time)
    {
        AppointmentId = id;
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentTime = time;
        Status = "Scheduled";
    }
}

public class HospitalManager
{
    private List<Patient> patients = new List<Patient>();
    private List<Doctor> doctors = new List<Doctor>();
    private List<Appointment> appointments = new List<Appointment>();

    private int patientCounter = 1;
    private int doctorCounter = 1;
    private int appointmentCounter = 1;

    public void AddPatient(string name, int age, string bloodGroup)
    {
        patients.Add(new Patient(patientCounter++, name, age, bloodGroup));
    }

    public void AddDoctor(string name, string specialization)
    {
        doctors.Add(new Doctor(doctorCounter++, name, specialization));
    }

    public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
    {
        var patient = patients.FirstOrDefault(p => p.PatientId == patientId);
        var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);

        if (patient == null || doctor == null)
            return false;

        if (!doctor.AvailableSlots.Contains(time))
            return false;

        bool alreadyBooked = appointments.Any(a =>
            a.DoctorId == doctorId &&
            a.AppointmentTime == time &&
            a.Status == "Scheduled");

        if (alreadyBooked)
            return false;

        appointments.Add(new Appointment(appointmentCounter++, patientId, doctorId, time));
        doctor.AvailableSlots.Remove(time);

        return true;
    }

    public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
    {
        return doctors
            .GroupBy(d => d.Specialization)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Appointment> GetTodayAppointments()
    {
        DateTime today = DateTime.Today;

        return appointments
            .Where(a => a.AppointmentTime.Date == today)
            .ToList();
    }

    public void AddDoctorSlot(int doctorId, DateTime slot)
    {
        var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);
        if (doctor != null && !doctor.AvailableSlots.Contains(slot))
            doctor.AvailableSlots.Add(slot);
    }

    public void AddMedicalHistory(int patientId, string record)
    {
        var patient = patients.FirstOrDefault(p => p.PatientId == patientId);
        if (patient != null)
            patient.MedicalHistory.Add(record);
    }
}

class Program
{
    static void Main()
    {
        HospitalManager hospital = new HospitalManager();

        hospital.AddPatient("Rahul", 25, "O+");
        hospital.AddPatient("Priya", 30, "A+");

        hospital.AddDoctor("Dr. Sharma", "Cardiology");
        hospital.AddDoctor("Dr. Mehta", "Orthopedic");

        hospital.AddDoctorSlot(1, DateTime.Today.AddHours(10));
        hospital.AddDoctorSlot(1, DateTime.Today.AddHours(11));
        hospital.AddDoctorSlot(2, DateTime.Today.AddHours(12));

        Console.WriteLine(hospital.ScheduleAppointment(1, 1, DateTime.Today.AddHours(10)));
        Console.WriteLine(hospital.ScheduleAppointment(2, 2, DateTime.Today.AddHours(12)));

        var groupedDoctors = hospital.GroupDoctorsBySpecialization();
        foreach (var spec in groupedDoctors)
        {
            Console.WriteLine(spec.Key);
            foreach (var doc in spec.Value)
            {
                Console.WriteLine(doc.Name);
            }
        }

        var todayAppointments = hospital.GetTodayAppointments();
        foreach (var app in todayAppointments)
        {
            Console.WriteLine($"{app.PatientId} - {app.DoctorId} - {app.AppointmentTime}");
        }

        hospital.AddMedicalHistory(1, "Diabetes");
    }
}