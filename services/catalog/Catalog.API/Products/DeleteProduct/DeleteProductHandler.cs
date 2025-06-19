using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidators : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidators()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id should not be empty");
        }
    }

    internal class DeleteProductCommandHandler
        (IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand,DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command,CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler. Handle called with {@command}", command);
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
