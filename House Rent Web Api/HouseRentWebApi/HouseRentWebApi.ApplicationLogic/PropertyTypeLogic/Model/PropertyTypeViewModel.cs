﻿using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.ComponentModel.DataAnnotations;

namespace HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Model
{
    public class PropertyTypeViewModel
    {
        public PropertyTypeModel Model { get; set; }
        public PropertyTypeGridModel GridModel { get; set; }
    }

    public class PropertyTypeModel : IMapFrom<PropertyType>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied name.")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PropertyType, PropertyTypeModel>();
            profile.CreateMap<PropertyTypeModel, PropertyType>();
        }
    }

    public class PropertyTypeGridModel : IMapFrom<PropertyType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PropertyType, PropertyTypeGridModel>();
            profile.CreateMap<PropertyTypeGridModel, PropertyType>();
        }
    }
}