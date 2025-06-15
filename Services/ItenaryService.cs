using System;
using GoSmart.API.Models;

namespace GoSmart.API.Services
{
	public class ItenaryService
	{
		public ItenaryService()
		{

		}

		public ItenaryResponse GenerateItenary(ItenaryRequest request)
		{
			var plan = new List<DayPlan>();

			for(int i = 1; i<=request.NumberOfDays; i++)
			{
				plan.Add(new DayPlan
				{
					Day = i,
					Activites = new List<string>
					{
						$"Explore local spots in {request.Destination}",
						"Try local cuisine",
						"Relax at hotel/spa"
					}
				});
			}
			return new ItenaryResponse
			{
				Destination = request.Destination,
				Plan = plan

			};
		}


	}
}

