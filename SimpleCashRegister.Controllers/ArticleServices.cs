using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer;
using SimpleCashRegister.DataAccessLayer.Repositories;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.Services
{
    public class ArticleServices
    {
        private static readonly string ArticleAlreadyExistsMessage = "Article with specified id already exists";
        private static readonly string ArticleNotFoundMessage = "Article with specified id not found.";

        public ArticleServices(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private readonly ArticleRepository _articleRepository;

        public List<Article> GetAllArticles()
        {
            var rv = _articleRepository.GetAll();
            return rv;
        }

        public Article GetById(long id)
        {
            Article rv;
            try
            {
                rv = _articleRepository.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine(ArticleNotFoundMessage);
                return null;
            }
            return rv;
        }

        public bool AddNewArticle(Article article)
        {
            try
            {
                _articleRepository.Add(article);
                Console.WriteLine("Ok");
                return true;
            }
            catch (EntityAlreadyExistsException)
            {
                Console.Error.WriteLine(ArticleAlreadyExistsMessage);
                return false;
            }
        }

        public void EditArticle(Article article)
        {
            try
            {
                _articleRepository.Edit(article);
                Console.WriteLine("Ok");
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine(ArticleNotFoundMessage);
            }
        }

        public void DeleteArticle(int articleId)
        {
            try
            {
                _articleRepository.Delete(articleId);
                Console.WriteLine("Ok");
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine(ArticleNotFoundMessage);
            }
        }
    }
}
