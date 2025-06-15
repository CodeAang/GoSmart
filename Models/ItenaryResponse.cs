using System;
namespace GoSmart.API.Models
{
	public class ItenaryResponse
	{
		public ItenaryResponse()
		{
			
		}

		public string Destination { get; set; }
		public List<DayPlan> Plan { get; set; }
	}
}

