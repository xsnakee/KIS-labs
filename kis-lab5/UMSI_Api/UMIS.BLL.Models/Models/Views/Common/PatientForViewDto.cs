using System;
using System.Collections.Generic;
using Common.Enums;
using UMIS.BLL.Contracts.Models.Common;
using UMIS.BLL.Contracts.Models.Views.Common.Catalogs;

namespace UMIS.BLL.Contracts.Models.Views.Common
{
    /// <summary>
    /// Пациент
    /// </summary>
    public class PatientForViewDto
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PatientForViewDto()
        {
            MedicalHistories = new List<MedicalHistoryDto>();
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Паспорт (серия/номер)
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// СНИЛС
        /// </summary>
        public string SNILS { get; set; }

        /// <summary>
        /// Номер ОМС
        /// </summary>
        public string OMC { get; set; }

        /// <summary>
        /// Список телефонов
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адреса (прописки, проживания)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// Группа крови
        /// </summary>
        public BloodTypeEnum BloodGroup { get; set; }

        /// <summary>
        /// Уточнение/описание группы инвалидности
        /// </summary>
        public DisabilityDescriptionDto DisabilityDescription { get; set; }
        public int? DisabilityDescriptionId { get; set; }

        /// <summary>
        /// Истории болезней
        /// </summary>
        public IList<MedicalHistoryDto> MedicalHistories { get; set; }

        /// <summary>
        /// Трудовой анамнез
        /// </summary>
        public WorkHistoryDto WorkHistory { get; set; }
        public int? WorkHistoryId { get; set; }

        /// <summary>
        /// Аллерго анамнез
        /// </summary>
        public AllergyAnamnesisDto AllergyAnamnesis { get; set; }
        public int? AllergyAnamnesisId { get; set; }

        /// <summary>
        /// Справочники
        /// </summary>
        public IList<CatalogFieldValueForViewDto> CatalogFields{ get; set; }
    }
}
