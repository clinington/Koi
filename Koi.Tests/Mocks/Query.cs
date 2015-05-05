namespace Koi.Tests.Mocks
{
    public interface IQuery
    {
        void Do();
    }

    public class Query : IQuery
    {
        private readonly IRepo repo;

        private readonly IEmailService emailService;

        public Query(IRepo repo, IEmailService emailService)
        {
            this.repo = repo;
            this.emailService = emailService;
        }

        public void Do()
        {
            this.emailService.Email();

            this.repo.Save();
        }
    }
}
