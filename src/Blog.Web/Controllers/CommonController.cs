using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Web.Controllers
{
    public class CommonController : BaseWebController
    {
        private readonly INoticeinfoService _noticeinfoService;
        private readonly IFriendLinkService _friendLinkService;
        private readonly ITimeLineService _timeLineService;
        public CommonController(INoticeinfoService noticeinfoService, IFriendLinkService friendLinkService, ITimeLineService timeLineService)
        {
            _noticeinfoService = noticeinfoService;
            _friendLinkService = friendLinkService;
            _timeLineService = timeLineService;
        }

        /// <summary>
        /// 首页通知
        /// </summary>
        /// <returns></returns>
        public IActionResult Notice()
        {
            return Json(_noticeinfoService.Queryable(null, o => o.SortCode, false));
        }

        /// <summary>
        /// 友情链接
        /// </summary>
        /// <returns></returns>
        public IActionResult Link()
        {
            return Json(_friendLinkService.Queryable(null, o => o.SortCode, false));
        }

        /// <summary>
        /// 时光轴
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IActionResult Line(int page, int limit = 10)
        {
            var result = _timeLineService.QueryableByPage(null, "PublishDate desc", page, limit);
            var data = result.Item1;
            IEnumerable<int> years = data.Select(s => s.PublishDate.Value.Year).Distinct().OrderByDescending(o => o);
            List<TimeLineDto> times = new List<TimeLineDto>();
            foreach (int item in years)
            {
                TimeLineDto dto = new TimeLineDto();
                dto.Year = item;
                var list = data.Where(c => c.PublishDate.Value.Year == item);
                IEnumerable<int> months = list.Select(s => s.PublishDate.Value.Month).Distinct().OrderBy(o => o);
                Dictionary<string, IEnumerable<LineItem>> pairs = new Dictionary<string, IEnumerable<LineItem>>();
                foreach (int m in months)
                {
                    pairs[m.ToString("D2")] = list.Where(c => c.PublishDate.Value.Month == m).Select(s => new LineItem { Content = s.Content, Time = s.PublishDate.Value.ToString("MM月dd日 HH:mm") }).OrderBy(o => o.Time);
                }
                dto.Items = pairs;
                times.Add(dto);
            }
            var no = result.Item2 * 1d / limit;
            PageResult<List<TimeLineDto>> d = new PageResult<List<TimeLineDto>>();
            d.code = 0;
            d.count = (int)Math.Ceiling(no);
            d.data = times;
            return Json(d);
        }
    }
}