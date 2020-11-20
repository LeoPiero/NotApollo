using NotApolloCore.Models;
using System;
using System.Linq;

namespace NotApolloCore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NotApolloContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}