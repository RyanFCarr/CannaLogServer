﻿#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.Runtime.Serialization;

namespace Server.Models
{
    public class GrowLog
    {
        public int Id { get; set; }
        public decimal? AirTemperature { get; set; }
        public decimal FinalPH { get; set; }
        public int FinalPPM { get; set; }
        public decimal? GrowMediumTemperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal InitialPH { get; set; }
        public int InitialPPM { get; set; }
        public decimal? LightHeight { get; set; }
        public DateTime LogDate { get; set; }
        public string? Notes { get; set; }
        public virtual IEnumerable<AdditiveAdjustment> AdditiveAdjustments { get; set; }
        public int PlantId { get; set; }
        public virtual Plant Plant { get; set; }
        public int PlantAge { get; set; }
        public decimal? PlantHeight { get; set; }
        public string? Tags { get; set; }
    }

    public class GrowLogDto
    {
        public int Id { get; set; }
        public decimal? AirTemperature { get; set; }
        public decimal FinalPH { get; set; }
        public int FinalPPM { get; set; }
        public decimal? GrowMediumTemperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal InitialPH { get; set; }
        public int InitialPPM { get; set; }
        public decimal? LightHeight { get; set; }
        public DateTime LogDate { get; set; }
        public string? Notes { get; set; }
        public AdditiveAdjustmentDto NutrientAdjustment { get; set; }
        [DataMember(Name = "phAdjustment")]
        public AdditiveAdjustmentDto PHAdjustment { get; set; }
        public int PlantId { get; set; }
        public int PlantAge { get; set; }
        public decimal? PlantHeight { get; set; }
        public string? Tags { get; set; }
    }

    public class GrowLogSaveDto
    {
        public decimal? AirTemperature { get; set; }
        public decimal FinalPH { get; set; }
        public int FinalPPM { get; set; }
        public decimal? GrowMediumTemperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal InitialPH { get; set; }
        public int InitialPPM { get; set; }
        public decimal? LightHeight { get; set; }
        public DateTime LogDate { get; set; }
        public string? Notes { get; set; }
        public AdditiveAdjustmentSaveDto? NutrientAdjustment { get; set; }
        [DataMember(Name = "phAdjustment")]
        public AdditiveAdjustmentSaveDto? PHAdjustment { get; set; }
        public int PlantId { get; set; }
        public int PlantAge { get; set; }
        public decimal? PlantHeight { get; set; }
        public string? Tags { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
