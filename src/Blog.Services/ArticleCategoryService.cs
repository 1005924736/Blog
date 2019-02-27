using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class ArticleCategoryLogic : BaseService<ArticleCategory>, IArticleCategoryService
    {
        IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryLogic(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
    }
}
