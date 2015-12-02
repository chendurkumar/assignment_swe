using Betsson.Data;

namespace Betsson.WebApi.Models
{
    public class ServiceFactory
    {
        private ServiceFactory()
        {
            DataContext = new BetssonEntities();
        }

        public BetssonEntities DataContext
        {
            get;
            private set;
        }

        public static ServiceFactory Instance { get; } = new ServiceFactory();
    }
}