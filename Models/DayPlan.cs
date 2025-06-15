using System;
namespace GoSmart.API.Models
{
	public class DayPlan
	{
		public DayPlan()
		{
		}

		public int Day { get; set; }
		public List<string> Activites { get; set; }
	}
}

