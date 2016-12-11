using SimpleCashRegister;

namespace SimpleCashRegister.ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {

            var app = new Application();
            app.Run();

            //// Adding articles
            //var articlesToAdd = new List<Article>
            //{
            //    new ArticleSoldByQuantity(10)
            //    {
            //        Name = "Programming in C#",
            //        Price = (decimal)23.44,
            //        VatRate = (decimal)0.15
            //    },
            //    new ArticleSoldByMass(15)
            //    {
            //        Name = "Almonds",
            //        Price = (decimal)15.21,
            //        VatRate = (decimal)0.20
            //    }
            //};

            //// Articles from CLI to add!
            //cmd = new AddNewArticleCommand(articleServices);
            //cmd.Execute();
            
            //foreach (var article in articlesToAdd)
            //{
            //    articleServices.AddNewArticle(article);
            //}

            //cmd = new EditArticleCommand(articleServices);
            //cmd.Execute();

            //// Printing articles
            //var articleView = new PresentationLayer.Views.ArticleView();
            //foreach (var article in articleServices.GetAllArticles())
            //{
            //    Console.WriteLine(articleView.Display(article));
            //}

            //var receiptFacotry = new Model.Factories.ReceiptFactory();
            ////var rnd = new Random();
            //var items = new List<Item>()
            //{
            //    new ItemSoldByQuantity()
            //    {
            //        Article = articlesToAdd[0]
            //    },
            //    new ItemSoldByMass()
            //    {
            //        Article = articlesToAdd[1]
            //    }
            //};
            //var receiptToAdd = receiptFacotry.Create(items);

            //receiptRepository.Add(receiptToAdd);
            
        }
    }
}
