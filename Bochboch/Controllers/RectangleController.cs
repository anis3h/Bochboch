using Bochboch.Database;
using Bochboch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bochboch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : Controller
    {
        private BochbochContext _bochbochDbContext { get; }
        public RectangleController(BochbochContext bochbochDbContext)
        {
            _bochbochDbContext = bochbochDbContext;
        }

        [Route("rectangles")]
        [HttpGet]
        public async Task<ActionResult<List<Rectangle>>> GetRectangles()
        {
            if (!await _bochbochDbContext.Rectangles.AnyAsync())
            {
                IEnumerable<Rectangle> rectangles = new List<Rectangle>()
                {
                    new Rectangle { Color = "red", y = 0, x = 0 },
                    new Rectangle { Color = "blue", y = 20, x = 0 },
                    new Rectangle { Color = "green", y = 40, x = 0 },
                    new Rectangle { Color = "yellow", y = 60, x = 0 },
                    new Rectangle { Color = "magenta", y = 80, x = 0 },
                    new Rectangle { Color = "black", y = 100, x = 0 },
                    new Rectangle { Color = "grey", y = 120, x = 0 },
                    new Rectangle { Color = "orange", y = 140, x = 0 },
                };
                await SaveRectangle(rectangles.ToArray());
            }
            var result = await _bochbochDbContext.Rectangles.ToListAsync();
            return result;
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> SaveRectangle(Rectangle[] rectangles)
        {
            _bochbochDbContext.Rectangles.UpdateRange(rectangles);
            await _bochbochDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}