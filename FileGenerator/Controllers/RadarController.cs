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

        public List<Radar> GetTodosSql()
        {
            return _radarService.GetTodosSql();
        }
        public List<Radar> GetTodosMongo()
        {
            return _radarService.GetTodosMongo();
        }
        public void InserirTodos(List<Radar> radares)
        {
            _radarService.InserirTodos(radares);
        }
    }
}
