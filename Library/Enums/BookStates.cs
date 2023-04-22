using System.ComponentModel;

namespace Library.Enums;

public enum BookStates
{
    [Description("Удалена")]
    Deleted,
    [Description("В наличии")]
    InStock,
    [Description("Выдана")]
    OutOfStock
}