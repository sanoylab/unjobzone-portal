using unjobzone_portal;
using unjobzone_portal.Model;
using unjobzone_portal.Data;
using Microsoft.EntityFrameworkCore; // Add this line

namespace unjobzone_portal.Services
{
  public class OrganizationService
  {
    private readonly ApplicationDbContext _context;


    public OrganizationService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Organization> CreateCountry(Organization org)
    {
      _context.organization.Add(org);
      await _context.SaveChangesAsync();
      return org;
    }
    public async Task<Organization> GetOrganization(int id)
    {
      return await _context.organization.FindAsync(id);
    }
    public async Task<List<Organization>> GetOrganizations()
    {
      return await _context.organization.ToListAsync();
    }
    public async Task<Organization> UpdateOrganization(int id, Organization org)
    {
      _context.Entry(org).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return org;
    }
    public async Task<Organization> DeleteOrganization(int id)
    {
      var org = await _context.organization.FindAsync(id);
      if (org == null)
      {
        return null;
      }

      _context.organization.Remove(org);
      await _context.SaveChangesAsync();
      return org;
    }

  }
}