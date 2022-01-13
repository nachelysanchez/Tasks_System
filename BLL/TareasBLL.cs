using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL;
using Tasks_System.Entidades;

namespace Tasks_System.BLL
{
    public class TareasBLL
    {
        /// <summary>
        /// Permite buscar una tarea mediante id
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static bool Existe(int id)
        {

            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Tareas.Any(t => t.TareaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        /// <summary>
        /// Permite guardar una tarea
        /// </summary>
        /// <param name="tarea">La entidad que se desea guardar</param>
        public static bool Guardar(Tareas tarea)
        {
            if (!Existe(tarea.TareaId))
            {
                return Insertar(tarea);
            }
            else
            {
                return Modificar(tarea);
            }
        }
        /// <summary>
        /// Permite insertar una tarea en la base de datos
        /// </summary>
        /// <param name="tarea">La entidad que se desea guardar</param>
        private static bool Insertar(Tareas tarea)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Tareas.Add(tarea);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        /// <summary>
        /// Permite modificar una tarea en la base de datos
        /// </summary>
        /// <param name="tarea">La entidad que se desea modificar</param>
        private static bool Modificar(Tareas tarea)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(tarea).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    }
}
