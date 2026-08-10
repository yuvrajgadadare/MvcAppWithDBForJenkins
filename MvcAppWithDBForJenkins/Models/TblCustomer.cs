using System;
using System.Collections.Generic;

namespace MvcAppWithDBForJenkins.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string? City { get; set; }
}
