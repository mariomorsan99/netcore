using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;
using static Aplicacion.Cursos.Editar;

namespace Aplicacion.Cursos
{
    public class Editar
    {
        
        public class Ejecuta:IRequest {
        public int CursoId{get; set;}

        public string Titulo{get; set;}

        public string Descripcion{get; set;}

        public DateTime? FechaPublicacion{get; set;}
        }
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {

        public readonly CursosOnlineContext _context;
        public Manejador(CursosOnlineContext context)
        {
            _context=context;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var curso= await _context.Curso.FindAsync(request.CursoId);
            if(curso==null) {
                throw new Exception("El curso no existe");
            }

            curso.Titulo= request.Titulo ?? curso.Titulo;
            curso.Descripcion=request.Descripcion ?? curso.Descripcion;
            curso.FechaPublicacion=request.FechaPublicacion ?? curso.FechaPublicacion;

            var result = await _context.SaveChangesAsync();
            
            if(result>0) {
                return Unit.Value;
            }
            
            throw new Exception("no se guardaron los cambios en el curso");
        }
    }
}