namespace TodoList
{
    public static class ExceptionMessages
    {
        public static string ToDoTaskIdEmpty => "Todo task ID is empty.";
        public static string ToDoTaskIsNotExisted => "Todo task is not exist.";
        public static string ToDoTaskAlreadyExisted => "Todo task already exist in database.";
        public static string ToDoTaskTitleAlreadyExisted => "Todo task title already exist in database.";
        public static string NoToDoTasksInDatabase => "There is no todo tasks in database.";
    }
}
