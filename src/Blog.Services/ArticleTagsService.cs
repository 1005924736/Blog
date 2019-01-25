using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class ArticleTagsService : BaseService<ArticleTags>, IArticleTagsService
    {
        IArticleTagsRepository _articleTagsRepository;
        public ArticleTagsService(IArticleTagsRepository articleTagsRepository) : base(articleTagsRepository)
        {
            _articleTagsRepository = articleTagsRepository;
        }
    }
}
