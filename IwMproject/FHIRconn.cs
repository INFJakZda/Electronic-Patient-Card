using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Hl7.FhirPath;

namespace IwMproject
{
    class FHIRconn
    {
        private string FhirClientEndPoint = "http://hapi.fhir.org/baseDstu3/";
        private FhirClient client;

        public FHIRconn()
        {
            client = new FhirClient(FhirClientEndPoint);
        }

        public Patient GetPatientByID(string id)
        {
            Patient patient = client.Read<Patient>("Patient/" + id);
            return patient;
        }

        public List<Patient> GetListOfPatients(string patientName)
        {
            Patient patient;
            List<Patient> patients = new List<Patient>();
            var b = client.Search<Hl7.Fhir.Model.Patient>(new string[] { "name=" + patientName });

            foreach (var Entry in b.Entry)
            {
                var x = Entry.Resource;
                patient = (Patient)x;
                patients.Add(patient);
            }
            return patients;
        }

        public List<Patient> GetListOfAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                patients.AddRange(GetListOfPatients(letter.ToString()));
            }
            return patients;
        }
    }
}
