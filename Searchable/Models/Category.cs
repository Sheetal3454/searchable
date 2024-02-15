using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Searchable.Models;

//public enum SortOrder { Ascending = 0, Descending = 1 }

public partial class Category
{
    [Key]
    [StringLength(50)]

    public string CategoryId { get; set; }

    [StringLength(100)]
    public string? CategoryName { get; set; }

    [StringLength(75)]
    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    [StringLength(75)]
    public string? ModifiedBy { get; set; }

    public DateTime ModifiedDate { get; set; }
}
