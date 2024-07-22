using System;
namespace payment_crud.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PaymentDetails
{
	[Key]
	public int PaymentDetailId { get; set; }

	[Column(TypeName = "nvarchar(100)")]
	public string CardOwnerName { get; set; } = "";

    [Column(TypeName = "nvarchar(16)")]
    public string CardNumber { get; set; } = "";

    [Column(TypeName = "nvarchar(5)")]
    public string ExpirationDat { get; set; } = "";

    [Column(TypeName = "nvarchar(3)")]
    public string SecurityCode { get; set; } = "";
}

