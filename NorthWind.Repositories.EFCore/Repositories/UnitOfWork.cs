using NorthWind.Entities.Interfaces;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories
{
    //Implementacion del patron UNIDAD DE TRABAJO   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthWindContext _context;
        public UnitOfWork(NorthWindContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangeAsync()
        {

            //No se usa await porque no es necesario esperar la respuesta aca, si no que al ser solo una sentencia y asi 
            //...mismo el metodo retorna una Tarea Task<int>, se retorna la tarea en si, sin hacer await.
            return _context.SaveChangesAsync();
        }
    }
}
