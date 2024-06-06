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

        public List<Radar> GetTodos()
        {
            return _radarRepository.GetTodos();
        }
        public void InserirTodos(List<Radar> radares)
        {
            _radarRepository.InserirTodos(radares);
        }
    }
}
