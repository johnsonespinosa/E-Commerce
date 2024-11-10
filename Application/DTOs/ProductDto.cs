using AutoMapper;
using Domain.Entities;

namespace Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Category { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal SellPrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Stock { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
        }
    }
}