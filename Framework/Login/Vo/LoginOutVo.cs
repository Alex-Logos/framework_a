using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ZimVie.Wcs.Framework;

namespace Com.ZimVie.Wcs.Framework.Login
{
    public class LoginOutVo : ValueObject
    {
        public int RowIndex { get; set; }
        public string ItemNumber { get; set; }
        public string Identifier { get; set; }
        public decimal? PlannedQuantity { get; set; }
        public int? ActualQuantity	 { get; set; }
        public decimal? QuantityDifference { get; set; }
        public string AchievmentRatio { get; set; }
        public string ItemName { get; set; }
        /// <summary>
        /// 产线编号
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 生产线/设备
        /// </summary>
        public string LineMachine { get; set; }
        /// <summary>
        /// SAP 产线名称
        /// </summary>
        public string SapWempfLine { get; set; }
        public string Status { get; set; }
        public string DefectiveQtyIncludedFlg { get; set; }
        public int? Duration { get; set; }
        public decimal? NoOfWorkers { get; set; }
        public string Shift { get; set; }
        public string PrdShift { get; set; }
        public string PrdDate { get; set; }
        public string MONumer { get; set; }
        public string DayShift { get; set; }
        public string NightShift { get; set; }
        public decimal? ManHour { get; set; }
        public string DefectiveStage { get; set; }
        public string DeparmentName { get; set; }
        public string DeparmentCode { get; set; }
        public string WorkCenter { get; set; }
        public string ProcessWork { get; set; }
        public decimal? PrimaryDefectiveQuantity { get; set; }
        public string PrimaryDefectiveRatio { get; set; }
        public decimal? SecondaryDefectiveQuantity { get; set; }
        public string SecondaryDefectiveRatio { get; set; }
        public decimal? DefectiveQuantity { get; set; }
        public string LotNo { get; set; }       
        public DateTime StartDateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StartTimePlan { get; set; }
        public DateTime StartTimeActualHeader { get; set; }
        public DateTime StartTimeActualDetail { get; set; }
        public DateTime FinishTimeActualDetail { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string RegistrationUserCd { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string MaterialGroup { get; set; }

        public int AffectedCount = 0;

        public bool IsPlanOnly;
        
    }
}
