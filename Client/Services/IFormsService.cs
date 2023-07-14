﻿using OptechX.Portal.Shared.Models.Forms;

namespace OptechX.Portal.Client.Services
{
	public interface IFormsService
	{
		WinVersionApiResult WinVersionApiResults { get; }
		Task GetWinVersionApiResultsAsync(string select);

		WinEditionApiResult WinEditionApiResults { get; }
		Task GetWinEditionApiResultsAsync(string select);

		WinReleaseApiResult WinReleaseApiResults { get; }
		Task GetWinReleaseApiResultsAsync(string select);

		WinArchApiResult WinArchApiResults { get; }
		Task GetWinArchApiResultsAsync(string select);
	}
}
