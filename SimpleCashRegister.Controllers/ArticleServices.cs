using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL;
using SimpleCashRegister.DAL.Repositories;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.Services
{
    public class ArticleServices
    {
        public ArticleServices(ArticleRepository articleRepository, AccountServices accountServices)
        {
            _articleRepository = articleRepository;
            _accountServices = accountServices;
        }

        private readonly ArticleRepository _articleRepository;
        private readonly AccountServices _accountServices;

        public List<Article> GetAllArticles()
        {
            var rv = _articleRepository.GetAll();
            return rv;
        }

        public void AddNewArticle(Article article)
        {
            if (_accountServices.AsAdmin)
            {
                try
                {
                    _articleRepository.Add(article);
                    Console.WriteLine("Ok");
                }
                catch (EntityAlreadyExistsException)
                {
                    Console.Error.WriteLine("Article with specified id already exists.");
                }
            }
            else
            {
                Console.Error.WriteLine("No permission.");
            }
        }

        public void EditArticle(Article article)
        {
            if (_accountServices.AsAdmin)
            {
                try
                {
                    _articleRepository.Edit(article);
                    Console.WriteLine("Ok");
                }
                catch (EntityNotFoundException)
                {
                    Console.Error.WriteLine("Article with specified id not found.");
                }
            }
            else
            {
                Console.Error.WriteLine("No permission.");
            }
        }

        public void DeleteArticle(int articleId)
        {
            if(_accountServices.AsAdmin)
            {
                try
                {
                    _articleRepository.Delete(articleId);
                    Console.WriteLine("Ok");
                }
                catch (EntityNotFoundException)
                {
                    Console.Error.WriteLine("Article with specified id doesn't exist.");
                }
            }
        }
    }
}
