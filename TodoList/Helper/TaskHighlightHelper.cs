using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Helper
{
    public class TaskHighlightHelper
    {
        public static void HighlightTask(ToDoTask toDoTask)
        {
            if (!toDoTask.Title.Contains("\u2605"))
            {
                toDoTask.Title += "\u2605";
            }
        }
        public static void StopHighlightTask(ToDoTask toDoTask)
        {
            toDoTask.Title = toDoTask.Title.Replace("\u2605", string.Empty);
        }
    }
}
