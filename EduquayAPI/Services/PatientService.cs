using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class PatientService: IPatientService
    {
        private readonly IPatientData _patientData;

        public PatientService(IPatientDataFactory patientDataFactory)
        {
            _patientData = new PatientDataFactory().Create();
        }
        public string AddPatient(Patient pdata)
        {
            var result =_patientData.Add(pdata);

            return result;
        }

        public List<Patient> GetPatient(int pId)
        {
            var patient = _patientData.GetPatient(pId);
            return patient;
        }
        public List<Patient> GetPatients()
        {
            var allPatients = _patientData.GetPatients();
            return allPatients;
        }
    }
}
