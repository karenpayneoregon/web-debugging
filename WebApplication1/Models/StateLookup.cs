#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class StateLookup
{
    [Column("StateID")]
    public int Id { get; set; }

    public string StateName { get; set; }

    public string StateAbbrev { get; set; }
}