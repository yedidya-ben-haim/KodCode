using SmartLockerApi.Model;

namespace SmartLockerApi.Repositories
{
    public interface ILockerRepository
    {
        IEnumerator<Locker> GetAill();
        Locker? GetById(int id);

        Locker? GetByLockermuber(int lockerNumber);
        IEnumerable<Locker> GetByStatus(string status);
        Locker Create(Locker locker);
        Locker? Update(int id, Locker locker);
        bool Delete(int id);

    }
}
