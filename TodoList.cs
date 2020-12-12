using System;
using System.Collections.Generic;

namespace PR3_TODOList
{
    /// <summary>
    /// Contiene la funcion de las listas
    /// </summary>
    class TodoList
    {
        /// <summary>
        /// te notifica si la prueba esta correcta
        /// </summary>
        string notificacion = "";

        /// <summary>
        /// lista de tareas terminadas
        /// </summary>
        /// <typeparam name="Todo"></typeparam>
        /// <returns></returns>
        List<Todo> listasTerminadas = new List<Todo>();

        /// <summary>
        /// lista de tareas pendientes
        /// </summary>
        /// <typeparam name="Todo"></typeparam>
        /// <returns></returns>
        List<Todo> listasPendientes = new List<Todo>();

        public string NotificacionPantalla(){
            return this.notificacion;
        }
        //List<Todo> ...
        /// <summary>
        /// añadir una tarea como tarea pendiente
        /// </summary>
        public void AñadirPendiente(Todo tarea){
            if (tarea.TomarTarea() == false)
            {
                this.listasPendientes.Add(tarea);
                this.notificacion = "Se agrego la tarea";
            }
            else{
                this.notificacion = "Error al agregar la tarea";
            }
        }

        /// <summary>
        /// añadir una tarea pendiente como una tarea terminada
        /// </summary>
        /// <param name="tarea"></param>
        public void AñadirTerminada(Todo tarea){
            if (tarea.TomarTarea() == true){
                this.listasTerminadas.Add(tarea);
                this.notificacion = "termino la tarea";
            }
            else{
                this.notificacion = "no hay tarea pendiente";
            }
        }


        /// <summary>
        /// borrar un a tarea pendeiente
        /// </summary>
        public void BorrarPendiente(){
            this.listasPendientes.Clear();
            this.notificacion = "se borraron las tareas pendientes";
        }

        /// <summary>
        /// borrar una tarea terminada
        /// </summary>
        public void BorrarTerminado(){
           this.listasTerminadas.Clear();
           this.notificacion = "Se borraron las tareas terminadas";
            
        }
        /// <summary>
        /// marcar una tarea como terminada
        /// </summary>
        public void TareaTerminada(Todo tarea){
            if(this.listasPendientes.Contains(tarea)){
                this.listasPendientes.Remove(tarea);
                Todo tareaTerminada = new Todo(tarea.TomarDescripcion(), true);
                this.listasPendientes.Add(tareaTerminada);

                this.notificacion = "Terminaste la tarea";
            }
            else{
                this.notificacion = "error, no encuentro esta tarea existente";
            }

        }
        /// <summary>
        /// consultar la lista de pendientes
        /// </summary>
        public void ConsultarPendientes(){
            ImprimirTareas(this.listasPendientes);
        }
        /// <summary>
        /// consultar la lista de terminadas
        /// </summary>
        public void ConsultarTerminada(){
            ImprimirTareas(this.listasTerminadas);
        }

        /// <summary>
        /// imprimir las tareas pendientes o terminadas
        /// </summary>
        /// <param name="lista"></param>
        public void ImprimirTareas(List<Todo> lista){
            foreach(var item in lista){
                this.notificacion = this.notificacion + " " + item.TomarDescripcion();
                if (item.TomarTarea() == false){
                    this.notificacion = this.notificacion + " tareas sin terminar";
                }
                else{
                    this.notificacion = this.notificacion + " tareas terminadas";
                }
            }
        }
    }
}