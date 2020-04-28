using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Тип назначений
    /// </summary>
    public enum AssignmentTypeEnum
    {
        /// <summary>
        /// Анализ
        /// </summary>
        [Description("Анализ")]
        MedicalTest = 0,

        /// <summary>
        /// Операция
        /// </summary>
        [Description("Операция")]
        Operation = 1,

        /// <summary>
        /// Процедура
        /// </summary>
        [Description("Процедура")]
        Procedure = 2,

        /// <summary>
        /// Обследование
        /// </summary>
        [Description("Обследование")]
        MedicalExamination = 3,

        /// <summary>
        /// Врачебный осмотр
        /// </summary>
        [Description("Врачебный осмотр")]
        PhysicalExamination = 4,

        /// <summary>
        /// Снятие физиологических показаний
        /// </summary>
        [Description("Снятие физиологических показаний")]
        PhysiologicalIndication = 5
    }
}
