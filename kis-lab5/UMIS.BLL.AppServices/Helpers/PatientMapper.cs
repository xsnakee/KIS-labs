using System;
using System.Collections.Generic;
using System.Text;
using UMIS.BLL.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.BLL.AppServices.Helpers
{
    /// <summary>
    /// Маппер данных пациента
    /// </summary>
    public static class PatientMapper
    {
        public static Patient FillFrom(this Patient patient, PatientDto patientDto)
        {
            patient.Surname = patientDto.Surname;
            patient.Name = patientDto.Name;
            patient.Patronymic = patientDto.Patronymic;
            patient.Passport = patientDto.Passport;
            patient.SNILS = patientDto.SNILS;
            patient.OMC = patientDto.OMC;
            patient.Phone = patientDto.Phone;
            patient.Address = patientDto.Address;
            patient.Email = patientDto.Email;
            patient.Birthday = patientDto.Birthday;
            patient.Gender = patientDto.Gender;
            patient.BloodGroup = patientDto.BloodGroup;

            return patient;
        }
    }
}
