using System.ComponentModel.DataAnnotations;

namespace CDB.Application.Dtos;

public class CdbRequestDto
{
    [Required(ErrorMessage = "O campo Quantidade de Meses é obrigatório.")]
    [Range(2, 60, ErrorMessage = "O campo Quantidade de Meses deve ser entre 2 e 60.")]
    public int QtdMeses { get; set; }

    [Required(ErrorMessage = "O campo Valor Inicial é obrigatório.")]
    [Range(1, 250000, ErrorMessage = "O campo Valor Inicial deve ser maior que 0 e menor que 250.000,00.")]
    public decimal ValorInicial { get; set; }
}
