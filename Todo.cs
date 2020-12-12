using System;

namespace PR3_TODOList
{
    /// <summary>
    /// un objeto que incluye las tareas y la descripcion de las tareas
    /// </summary>
    class Todo
    {
        string descripcion{get; set;}
        bool tarea{get; set;}

        public Todo(string descripcion, bool tarea){
            this.descripcion = descripcion;
            this.tarea = tarea ;
        }

        /// <summary>
        /// regresar la descripcion de la tarea
        /// </summary>
        public string TomarDescripcion()
        {
            return descripcion;
        }

        /// <summary>
        /// tomar la tarea y regresarla como booleano
        /// </summary>
        public bool TomarTarea()
        {
            return tarea;
        }
    }
}