using CursoApiRest.Models;

namespace CursoApiRest.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly TareasContext _context;

        public CategoriaService(TareasContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Categoria ObtenerCategoriaPorId(Guid categoriaId)
        {
            return _context.Categorias.FirstOrDefault(p => p.CategoriaId == categoriaId);
        }

        public Categoria CrearCategoria(Categoria categoria)
        {
            categoria.CategoriaId = Guid.NewGuid();
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria ActualizarCategoria(Categoria categoria)
        {
            var categoriaExiste = _context.Categorias.FirstOrDefault(p => p.CategoriaId == categoria.CategoriaId);
            if (categoriaExiste != null)
            {
                categoriaExiste.Nombre = categoria.Nombre;
                categoriaExiste.Descripcion = categoria.Descripcion;
                categoriaExiste.Peso = categoria.Peso;
                _context.Categorias.Update(categoriaExiste);
                _context.SaveChanges();
            }
            return categoriaExiste;
        }

        public bool EliminarCategoria(Guid categoriaId)
        {
            var categoriaExiste = _context.Categorias.FirstOrDefault(p => p.CategoriaId == categoriaId);
            if (categoriaExiste != null)
            {
                _context.Categorias.Remove(categoriaExiste);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
    public interface ICategoriaService
    {
        List<Categoria> ObtenerCategorias();
        Categoria ObtenerCategoriaPorId(Guid categoriaId);
        Categoria CrearCategoria(Categoria categoria);
        Categoria ActualizarCategoria(Categoria categoria);
        bool EliminarCategoria(Guid categoriaId);
    }
}
