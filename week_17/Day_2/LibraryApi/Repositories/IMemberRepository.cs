namespace LibraryApi.Repositories;

public interface IMemberRepository
{
    Task<List<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(int id);
    Task<Member> CreateAsync(Member entity);
    Task<bool> UpdateAsync(int id, Member entity);
    Task<bool> DeleteAsync(int id);
}