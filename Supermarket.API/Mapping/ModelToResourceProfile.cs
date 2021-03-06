using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;
using Supermarket.Resources;

namespace Supermarket.API.Mapping {
	public class ModelToResourceProfile : Profile {
		public ModelToResourceProfile() {
			CreateMap<Category, CategoryResource>();

			CreateMap<Product, ProductResource>()
				.ForMember(SourceMemberNamingConvention => SourceMemberNamingConvention.UnitOfMeasurement,
					opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
		}
	}
}