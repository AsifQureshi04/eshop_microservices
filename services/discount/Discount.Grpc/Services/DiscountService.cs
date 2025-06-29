﻿using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
    {
        public async override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            // Get discount from database
            
            var coupon = await dbContext.Coupon              
                                        .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if(coupon is null)
                coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc"};

            logger.LogInformation("Discount is retrieved for product name : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);
            var CouponModel = coupon.Adapt<CouponModel>();
            return CouponModel;
            
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

            dbContext.Coupon.Add(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);
            return coupon.Adapt<CouponModel>();
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

            dbContext.Coupon.Update(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);
            return coupon.Adapt<CouponModel>();
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {

            var coupon = await dbContext
                .Coupon
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with product name = {request.ProductName} is not found"));

            dbContext.Coupon.Remove(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully deleted.ProductName : {ProductName}", request.ProductName);
            return new DeleteDiscountResponse { Success = true };

        }
    }
}
