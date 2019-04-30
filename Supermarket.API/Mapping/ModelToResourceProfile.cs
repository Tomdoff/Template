using AutoMapper;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;
using Supermarket.Domain.Models;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile {
		public ModelToResourceProfile () {
			CreateMap<Category, CategoryResource> ();

			CreateMap<Product, ProductResource> ()
				.ForMember(SourceMemberNamingConvention=>SourceMemberNamingConvention.UnitOfMeasurement,
				opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
		}
	}
}