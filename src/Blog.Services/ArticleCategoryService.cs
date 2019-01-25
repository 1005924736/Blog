using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class ArticleCategoryService : BaseService<ArticleCategory>, IArticleCategoryService
    {
        IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
    }
}
