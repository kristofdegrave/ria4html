using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using Ria4HTMLWithoutSPA.Models;

namespace Ria4HTMLWithoutSPA.Services
{
    /// <summary>
    /// Domain Service responsible for todo items.
    /// </summary>
    [EnableClientAccess]
    public class TodoItemDomainService : DomainService
    {
        private static IList<TodoItem> todoItems;

        public TodoItemDomainService()
        {
            if (todoItems == null)
            {
                todoItems = new List<TodoItem>();
                todoItems.Add(new TodoItem() { TodoItemId = 1, Title = "Todo item 1", IsDone = false });
                todoItems.Add(new TodoItem() { TodoItemId = 2, Title = "Todo item 2", IsDone = false });
                todoItems.Add(new TodoItem() { TodoItemId = 3, Title = "Todo item 3", IsDone = false });
                todoItems.Add(new TodoItem() { TodoItemId = 4, Title = "Todo item 4", IsDone = false });
            }
        }

        [Query(IsDefault = true)]
        public IQueryable<TodoItem> GetTodoItems()
        {
            return todoItems.AsQueryable<TodoItem>();
        }

        [Insert]
        public void InsertTodoItem(TodoItem todoItem)
        {
            todoItem.TodoItemId = todoItems.Max(ti => ti.TodoItemId) + 1;
            todoItems.Add(todoItem);
        }

        [Update]
        public void UpdateTodoItem(TodoItem todoItem)
        {
            var item = todoItems.First(ti => ti.TodoItemId == todoItem.TodoItemId);
            item.Title = todoItem.Title;
            item.IsDone = todoItem.IsDone;
        }

        [Delete]
        public void DeleteTodoItem(TodoItem todoItem)
        {
            todoItems.Remove(todoItem);
        }
    }
}