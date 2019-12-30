using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.Enums
{
	public enum RecruitmentStatuses
	{
		New = 1,
		WaitingForPayment=2,
		Paid = 3,
		Accepted = 4,
		Denied = 5,
		Canceled = 6
	}
}