using System.ComponentModel.DataAnnotations;

namespace CDB.Application.Dtos;

public class CdbResponseDto
{
    public decimal ValorBruto { get; set; }
    public decimal ValorLiquido { get; set; }
}