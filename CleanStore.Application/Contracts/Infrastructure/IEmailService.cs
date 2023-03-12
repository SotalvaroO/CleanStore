
using CleanStore.Application.Models;

namespace CleanStore.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
