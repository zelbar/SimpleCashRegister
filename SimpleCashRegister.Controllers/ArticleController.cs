using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL;
using SimpleCashRegister.DAL.Repositories;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.Controllers
{
    public class ArticleController
    {
        public ArticleController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private readonly ArticleRepository _articleRepository;

        public void AddNewArticle(Article article)
        {
            try
            {
                _articleRepository.Add(article);
            }
            catch(EntityAlreadyExistsException)
            {

            }
        }

        public void DeleteArticle(int articleId)
        {
            try
            {
                _articleRepository.Delete(articleId);
            }
            catch (EntityNotFoundException)
            {
                //
            }
        }
    }
}
