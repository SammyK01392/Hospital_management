using System;
using System.Collections.Generic;

namespace Hospital_management.Models;

public partial class Practitioner
{
    public int PractitionerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Specialization { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? HospitalId { get; set; }

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual Hospital? Hospital { get; set; }
}
