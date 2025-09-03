using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Example.Api.Domain.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers.Transactions;

[Route("api/transactions")]
public class TransactionExampleController : ControllerBase
{
    private readonly IWriteService<CustomerInDto> writeService;
    private readonly IDbSaveChanges dbSaveChanges;

    public TransactionExampleController(
        IWriteService<CustomerInDto> writeService,
        IDbSaveChanges dbSaveChanges)
    {
        this.writeService = writeService;
        this.dbSaveChanges = dbSaveChanges;
    }

    /// <summary>
    /// Example of manual transaction management for complex operations.
    /// </summary>
    [HttpPost("complex-operation")]
    public async Task<IActionResult> ComplexOperation([FromBody] CustomerInDto customer)
    {
        await using var transaction = await dbSaveChanges.BeginTransactionAsync();

        try
        {
            // Step 1: Create customer
            var customerId = await writeService.CreateAsync(customer, saveChanges: false);

            // Step 2: Perform some validation or additional logic
            if (string.IsNullOrEmpty(customer.Email))
            {
                throw new ArgumentException("Email is required");
            }

            // Step 3: Save changes
            await dbSaveChanges.SaveChangesAsync();

            // Step 4: Commit transaction
            await transaction.CommitAsync();

            return Ok(new { Message = "Complex operation completed successfully", CustomerId = customerId });
        }
        catch (Exception ex)
        {
            // Transaction will be automatically rolled back when disposed
            return BadRequest(new { Message = "Complex operation failed", Error = ex.Message });
        }
    }
}
