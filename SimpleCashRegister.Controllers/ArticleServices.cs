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
        public ArticleServices(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private readonly ArticleRepository _articleRepository;

        public List<Article> GetAllArticles()
        {
            return _articleRepository.GetAll();
        }

        public Article GetById(long id)
        {
            return _articleRepository.GetById(id);;
        }

        public void AddNewArticle(Article article)
        {
            _articleRepository.Add(article);
        }

        public void EditArticle(Article article)
        {
            _articleRepository.Edit(article);
        }

        public void DeleteArticle(int articleId)
        {
            _articleRepository.Delete(articleId);
        }
    }
}
