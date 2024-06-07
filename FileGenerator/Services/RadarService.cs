using Models;
using Repositories;

namespace Services
{
    public class RadarService
    {
        private RadarRepository _radarRepository;

        public RadarService()
        {
            _radarRepository = new();
        }

        public List<Radar> GetTodosSql()
        {
            return _radarRepository.GetTodosSql();
        }
        public List<Radar> GetTodosMongo()
        {
            return _radarRepository.GetTodosMongo();
        }
        public void InserirTodos(List<Radar> radares)
        {
            _radarRepository.InserirTodos(radares);
        }
    }
}
