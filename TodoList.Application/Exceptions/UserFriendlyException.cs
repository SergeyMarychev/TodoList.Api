﻿namespace TodoList.Application.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string? message) : base(message)
        {
        }
    }
}
