using Blog.Core;
using Blog.Entities;
using Blog.IRepository;

namespace Blog.Repository
{
    public class ArticleCategoryRepository : BaseRepository<ArticleCategory>, IArticleCategoryRepository
    {
    }
}
