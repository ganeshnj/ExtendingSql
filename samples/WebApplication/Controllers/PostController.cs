using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.PostViewModels;

namespace WebApplication.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMapper _mapper { get; }

        public PostController(ApplicationDbContext context,
            IMapper _mapper)
        {
            _context = context;
            this._mapper = _mapper;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts.Include(p => p.Metas).ToListAsync();
            var postsViewModel = _mapper.Map<IEnumerable<PostViewModel>>(posts);
            return View(postsViewModel);
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.Metas)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            var postViewModel = _mapper.Map<PostViewModel>(post);

            return View(postViewModel);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,CreatedOn,Subtitle")] CreatePostViewModel createPostViewModel)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<Post>(createPostViewModel);

                // Create meta if only required
                if (createPostViewModel.CreatedOn != null)
                {
                    var createdOnMeta = new PostMeta()
                    {
                        Key = nameof(CreatePostViewModel.CreatedOn),
                        Value = createPostViewModel.CreatedOn.ToString()
                    };
                    post.Metas.Add(createdOnMeta);
                }

                if (createPostViewModel.Subtitle != null)
                {
                    var subtitleMeta = new PostMeta()
                    {
                        Key = nameof(CreatePostViewModel.Subtitle),
                        Value = createPostViewModel.Subtitle
                    };
                    post.Metas.Add(subtitleMeta);
                }

                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createPostViewModel);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.Metas).SingleOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<EditPostViewModel>(post);

            return View(viewModel);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,CreatedOn,CreatedOnMeta,Subtitle,SubtitleMeta")] EditPostViewModel editPostViewModel)
        {
            if (id != editPostViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var post = _mapper.Map<Post>(editPostViewModel);
 
                var createdOnMeta = _mapper.Map<PostMeta>(editPostViewModel.CreatedOnMeta);
                post.Metas.Add(createdOnMeta);

                var subtitleMeta = _mapper.Map<PostMeta>(editPostViewModel.SubtitleMeta);
                post.Metas.Add(subtitleMeta);

                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editPostViewModel);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.Metas)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            var postViewModel = _mapper.Map<PostViewModel>(post);

            return View(postViewModel);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
