﻿using AutoMapper;

namespace Application.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
        }
    }
}