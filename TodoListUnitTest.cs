using System;
using NUnit.Framework;

namespace PR3_TODOList
{
    /// <summary>
    /// clase donde se hacen las pruebas
    /// </summary>
    [TestFixture]
    class TodoListUnitTest
    {
        /// <summary>
        /// test que se usa para agregar una tarea
        /// </summary>
        [Test]
        [TestCase(TestName = "Agregar una tarea")]
        public void Agregar(){
            // agregar una tarea
            TodoList todoList = new TodoList();
            Todo tarea0 =  new Todo ("ir a comprar comida", false);
            todoList.AñadirPendiente(tarea0);
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("Se agrego la tarea"));

            //segunda tarea
            Todo tarea2 = new Todo ("recoger la cocina", false);
            todoList.AñadirPendiente(tarea2);
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("Se agrego la tarea"));

            // agregar una tarea terminada
            Todo tarea1 = new Todo("cocinar la comida", true);
            todoList.AñadirPendiente(tarea1);
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("Error al agregar la tarea"));
        }

        /// <summary>
        /// borrar solo las tareas pendientes
        /// </summary>
        [Test]
        [TestCase(TestName = "Borrar tarea pendiente")]
        public void BorrarPendiente(){
            TodoList todoList = new TodoList();
            Todo tarea0 = new Todo("ir a comprar comida", false);
            todoList.AñadirPendiente(tarea0);

            // borrar las tareas
            todoList.BorrarPendiente();
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("se borraron las tareas pendientes"));
        }

        /// <summary>
        /// borrar las tareas termiandas
        /// </summary>
        [Test]
        [TestCase(TestName = "Borrar tarea terminada")]
        public void BorrarTerminada(){
            TodoList todoList = new TodoList();
            Todo tarea1 = new Todo("Cocinar la comida", true);
            todoList.AñadirTerminada(tarea1);

            todoList.BorrarTerminado();
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("Se borraron las tareas terminadas"));
        }

        /// <summary>
        /// cambiar la tarea pendiente a tarea terminada
        /// </summary>
        [Test]
        [TestCase (TestName = "Tarea terminada")]
        public void TareaTerminada(){
            TodoList todoList = new TodoList();
            Todo tarea0 = new Todo("ir a comprar comida", true);
            Todo tarea2 = new Todo("recoger la cocina", false);
            
            //terminar un todo que no esta registrada
            todoList.AñadirPendiente(tarea0);
            todoList.TareaTerminada(tarea0);
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("error, no encuentro esta tarea existente"));

            //marcar una tarea como terminada
            todoList.AñadirPendiente(tarea2);
            todoList.TareaTerminada(tarea2);
            Assert.That(todoList.NotificacionPantalla(),Is.EqualTo("Terminaste la tarea"));


        }

        /// <summary>
        /// consultar solo las tareas pendientes
        /// </summary>
        [Test]
        [TestCase (TestName = "consultar tareas pendientes")]
        public void ConsultarPendientes(){
            TodoList todoList = new TodoList();

            //consultar una tarea pendiente
            Todo tarea0 = new Todo ("ir a comprar comida", false);
            todoList.AñadirPendiente(tarea0);
            todoList.ConsultarPendientes();
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("Se agrego la tarea ir a comprar comida tareas sin terminar"));
        }
        
        /// <summary>
        /// consultar solo tareas terminadas 
        /// </summary>
        [Test]
        [TestCase (TestName = "Consultar tareas terminadas")]
        public void ConsultarTerminadas(){
            TodoList todoList = new TodoList();

            //consultar tareas terminadas
            Todo tarea0 = new Todo ("ir a comprar comida", true);
            todoList.AñadirTerminada(tarea0);
            todoList.ConsultarTerminada();
            Assert.That(todoList.NotificacionPantalla(), Is.EqualTo("termino la tarea ir a comprar comida tareas terminadas"));
        }
    }
}