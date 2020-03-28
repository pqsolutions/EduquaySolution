using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IPatientData
    {
        List<Patient> GetPatient(int pId);
        List<Patient> GetPatients();
        string Add(Patient patient);
    }

    public interface IPatientDataFactory
    {
        IPatientData Create();
    }

    public class PatientDataFactory : IPatientDataFactory
    {
        public IPatientData Create()
        {
            return new PatientData();
        }
    }
}
