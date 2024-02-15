using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Searchable.Models;

public enum SortOrder {Ascending=0,Descending=1}

public partial class User
{
    [Key]
    [StringLength(50)]
    public string UserId { get; set; }

    [StringLength(100)]
    public string? UserName { get; set; }

    [StringLength(75)]
    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage="Email is not valid")]
    public string? Email { get; set; }

    [StringLength(200)]
    public string? Password { get; set; }
}
