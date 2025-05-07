using System.ComponentModel.DataAnnotations;

namespace CDB.Application.Dtos;

public class CdbResponseDto
{
    [Required(ErrorMessage = "O campo Valor Bruto é obrigatório.")]
    [Range(0.1, 100000000000000, ErrorMessage = "O campo Valor Bruto deve ser maior que 0 e menor que 1000.000.00.000.000,00")]
    public decimal ValorBruto { get; set; }

    [Required(ErrorMessage = "O campo Valor Líquido é obrigatório.")]
    [Range(0.1, 100000000000000, ErrorMessage = "O campo Valor Líquido deve ser maior que 0 e menor que 1000.000.00.000.000,00")]
    public decimal ValorLiquido { get; set; }
}