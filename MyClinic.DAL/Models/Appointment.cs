using System;
using System.Collections.Generic;

namespace MyClinic.DAL.Models;

public partial class Appointment
{
    public string Id { get; set; } = null!;

    public string? Doctor { get; set; }

    public string? Patient { get; set; }

    public int? Cabinet { get; set; }

    public DateTime Date { get; set; }
}
