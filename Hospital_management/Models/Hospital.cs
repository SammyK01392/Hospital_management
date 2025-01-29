using System;
using System.Collections.Generic;

namespace Hospital_management.Models;

public partial class Hospital
{
    public int HospitalId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<Practitioner> Practitioners { get; set; } = new List<Practitioner>();
}
