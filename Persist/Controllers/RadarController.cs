using Models;
using Services;
namespace Controllers
{
    public class RadarController
    {
        private RadarService _radarService;

        public RadarController()
        {
            _radarService = new();
        }

        public void InserirTodos(List<Radar> radares)
        {
            _radarService.InserirTodos(radares);
        }
    }
}
