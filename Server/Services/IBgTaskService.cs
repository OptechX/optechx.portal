using OptechX.Portal.Shared.Models.Generic;

namespace OptechX.Portal.Server.Services;

public interface IBGTaskService
{
    Task<ServiceResponse<bool>> ExecuteBgTaskServiceAsync(string verificationToken);
}