﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Article
{
    public class DeleteArticleCommand : ArticleCommand, ICommand
    {
        public DeleteArticleCommand(ArticleServices articleServices) : base(articleServices)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Deletes an existing article."; } }

        public string Name { get { return "delete-article"; } }

        public void Execute(string[] args)
        {
            Console.WriteLine("\nDELETE ARTICLE");
            Console.WriteLine("Enter article id: ");

            var line = Console.ReadLine();
            int id = default(int);
            try
            {
                id = Convert.ToInt32(line);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
                return;
            }
            _articleServices.DeleteArticle(id);
            Console.WriteLine();
        }
    }
}
