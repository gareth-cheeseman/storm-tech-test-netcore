﻿using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public abstract class TodoBase
    {

        public int TodoListId { get; set; }
        public string Title { get; set; }
        public string TodoListTitle { get; set; }
        public string ResponsiblePartyId { get; set; }
        public Importance Importance { get; set; }
    }
}