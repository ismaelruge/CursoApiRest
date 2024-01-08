using CursoApiRest.Models;

namespace CursoApiRest.Services
{
    public class TareasService : ITareasService
    {
        private readonly TareasContext _context;

        public TareasService(TareasContext context)
        {
            _context = context;
        }

        public List<Tarea> ObtenerTareas()
        {
            return _context.Tareas.ToList();
        }

        public Tarea ObtenerTareaPorId(Guid tareaId)
        {
            return _context.Tareas.FirstOrDefault(p => p.TareaId == tareaId);
        }

        public Tarea CrearTarea(Tarea tarea)
        {
            tarea.TareaId = Guid.NewGuid();
            _context.Tareas.Add(tarea);
            _context.SaveChanges();
            return tarea;
        }

        public Tarea ActualizarTarea(Tarea tarea)
        {
            var tareaExiste = _context.Tareas.FirstOrDefault(p => p.TareaId == tarea.TareaId);
            if (tareaExiste != null)
            {
                tareaExiste.CategoriaId = tarea.CategoriaId;
                tareaExiste.Titulo = tarea.Titulo;
                tareaExiste.Descripcion = tarea.Descripcion;
                tareaExiste.PrioridadTarea = tarea.PrioridadTarea;
                tareaExiste.FechaCreacion = tarea.FechaCreacion;
                tareaExiste.Resumen = tarea.Resumen;
                _context.Tareas.Update(tareaExiste);
                _context.SaveChanges();
            }
            return tareaExiste;
        }

        public bool EliminarTarea(Guid tareaId)
        {
            var tareaExiste = _context.Tareas.FirstOrDefault(p => p.TareaId == tareaId);
            if (tareaExiste != null)
            {
                _context.Tareas.Remove(tareaExiste);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
    public interface ITareasService
    {
        List<Tarea> ObtenerTareas();
        Tarea ObtenerTareaPorId(Guid tareaId);
        Tarea CrearTarea(Tarea tarea);
        Tarea ActualizarTarea(Tarea tarea);
        bool EliminarTarea(Guid tareaId);
    }
}
