using System;
using System.Collections.Generic;

namespace Hospital_management.Models;

public partial class Encounter
{
    public int EncounterId { get; set; }

    public int PatientId { get; set; }

    public int PractitionerId { get; set; }

    public int HospitalId { get; set; }

    public DateTime EncounterDate { get; set; }

    public string? EncounterType { get; set; }

    public string? Diagnosis { get; set; }

    public string? Treatment { get; set; }

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Practitioner Practitioner { get; set; } = null!;
}
