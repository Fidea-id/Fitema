using System;
using AutoMapper;
using Fitema.Models;
using Fitema.Requests;

namespace Fitema.MapperProfiles
{
	public class TransactionProfile : Profile
	{
		//public TransactionProfile()
		//{
		//	CreateMap<TransactionSubmitRequest, TransactionSubmitDto>();
		//	CreateMap<TransactionSubmitDto, Leases>();
		//	CreateMap<ProductItemRequest, ProductItemDto>();
		//	CreateMap<TransactionVerifyRequest, TransactionVerifyDto>();
		//	CreateMap<TransactionVerifyDto, Plans>();
		//	CreateMap<TransactionVerifyDto, LeaseHolds[]>().ConvertUsing(new TransactionDetailItemConverter());
		//	CreateMap<PossibleDuplicateInvoiceRequest, PossibleDuplicateInvoiceDto>();
		//	CreateMap<TransactionDrawnCreateRequest, TransactionDrawn[]>().ConvertUsing(new TransactionDrawnConverter());
		//}

  //      public class TransactionDetailItemConverter : ITypeConverter<TransactionVerifyDto, LeaseHolds[]>
  //      {
  //          public LeaseHolds[] Convert(TransactionVerifyDto source, LeaseHolds[] destination, ResolutionContext context)
  //          {
		//		return (from x in source.Products
		//				select new LeaseHolds
		//				{
		//					Price = source.TransactionsDetailId,
		//					TotalPrice = x.TotalPrice,
		//					Name = x.Name,
		//					Price = x.Price,
		//					Promo = x.Qty,
		//					Period = x._12NC,
		//				}).ToArray();
  //          }
  //      }

  //      public class TransactionDrawnConverter : ITypeConverter<TransactionDrawnCreateRequest, TransactionDrawn[]>
  //      {
  //          public TransactionDrawn[] Convert(TransactionDrawnCreateRequest source, TransactionDrawn[] destination, ResolutionContext context)
  //          {
		//		return (from x in source.TransactionsId
		//				select new TransactionDrawn
		//				{
		//					TransactionsId = x
		//				}).ToArray();
  //          }
  //      }

    }
}

