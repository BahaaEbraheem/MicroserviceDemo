using Microsoft.EntityFrameworkCore;
using RemittanceManagement.Remittances;
using RemittanceManagement.Status;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RemittanceManagement.EntityFrameworkCore;

[ConnectionStringName(RemittanceManagementDbProperties.ConnectionStringName)]
public interface IRemittanceManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    public DbSet<Remittance> Remittances { get; set; }
    public DbSet<RemittanceStatus> RemittanceStatus { get; set; }
}
