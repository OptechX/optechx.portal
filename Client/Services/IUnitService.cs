using OptechX.Portal.Shared;

namespace OptechX.Portal.Client.Services
{
	public interface IUnitService
	{
        IList<Unit> Units { get; }
		IList<UserUnit> MyUnits { get; set; }
		void AddUnit(int unitId);
	}
}

