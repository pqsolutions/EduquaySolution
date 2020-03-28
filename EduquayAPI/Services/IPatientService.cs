using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IPatientService
    {
        string AddPatient(Patient pdata);
        List<Patient> GetPatient(int pId);
        List<Patient> GetPatients();
    }
}
