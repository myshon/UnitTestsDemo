namespace MoqDemo
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;
        private readonly IEmailSender _emailSender;

        public WorkService(IWorkRepository workRepository, IEmailSender emailSender)
        {
            _workRepository = workRepository;
            _emailSender = emailSender;
        }

        public void SaveWork(Work obj)
        {
            _workRepository.Save(obj);
            _emailSender.Send("biuro@rector.com.pl", obj.Description);

        }
    }
}