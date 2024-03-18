using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Enums
{
	public enum OrderStatus
	{
		Pending  ,//: Chờ xử lý
		Processin,//: Đang xử lý
		Shipped  ,//: Đã gửi hàng
		Delivered,//: Đã giao hàng
		Cancelled,//: Đã hủy
		Completed,//: Đã hoàn thành
		OnHold  ,//: Tạm dừng
		Refunded ,//: Đã hoàn tiền
		Returned//: Đã trả lại
	}
}
