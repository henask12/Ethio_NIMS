using ENIMS.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.DataObjects
{
	//public class TimeZoneDataSeed : IEntityTypeConfiguration<GlobalTimeZone>
	//{
	//	public void Configure(EntityTypeBuilder<GlobalTimeZone> builder)
	//	{
	//		builder.ToTable("TimeZone");
	//		builder.Property(s => s.Name)
	//			.IsRequired(false);

	//		builder.HasData
	//		(
	//			new GlobalTimeZone
	//			{
	//				Id = 1,
	//				OffsetTime = "+3",
	//				Name = "Nairobi",
	//				RecordStatus = RecordStatus.Active,
	//				StartDate = DateTime.Now,
	//				EndDate = DateTime.MaxValue,
	//			},
	//			new GlobalTimeZone
	//			{
	//				Id = 2,
	//				OffsetTime = "+4",
	//				Name = "Dubai",
	//				RecordStatus = RecordStatus.Active,
	//				StartDate = DateTime.Now,
	//				EndDate = DateTime.MaxValue,					 
	//			},
	//			new GlobalTimeZone
	//			{
	//				Id = 3,
	//				OffsetTime = "+5",
	//				Name = "India",
	//				RecordStatus = RecordStatus.Active,
	//				StartDate = DateTime.Now,
	//				EndDate = DateTime.MaxValue,
	//			}
	//		);
	//	}
	//}
}
