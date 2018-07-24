﻿using SharpExchange.Api.V22.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpExchange.Api.V22.Endpoints
{
	public static class ReputationHistory
	{
		/// <summary>
		/// Gets a history of a user's reputation, excluding private events.
		/// </summary>
		public static Task<Result<ReputationHistoryEntry[]>> GetByUserIdsAsync(IEnumerable<int> userIds, QueryOptions options = null)
		{
			userIds.ThrowIfNullOrEmpty(nameof(userIds));
			options = options.GetDefaultIfNull();

			var idsStr = userIds.ToDelimitedList();
			var endpoint = $"{Constants.BaseApiUrl}/users/{idsStr}/reputation-history";

			return ApiRequestScheduler.ScheduleRequestAsync<ReputationHistoryEntry[]>(endpoint, options);
		}
	}
}
