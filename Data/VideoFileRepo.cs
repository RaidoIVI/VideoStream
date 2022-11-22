using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VideoStream.Model;

namespace VideoStream.Data
{
    public interface IVideoFileRepo
    {
        Task<ICollection<VideoDescription>> GetList();
        Task<IFileInfo> GetFile(Guid id);

        Task Add(VideoDescription videoDescription);
    }

    public class VideoFileRepo : IVideoFileRepo
    {
        private readonly StorageDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VideoFileRepo(StorageDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ICollection<VideoDescription>> GetList()
        {
            var result = await _dbContext.VideoDescriptions.ToArrayAsync();
            return result;
        }

        public async Task<IFileInfo> GetFile(Guid id)
        {
            IFileInfo result = null;
            string contentRootPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Media");
            var provider = new PhysicalFileProvider(contentRootPath);
            var file = _dbContext.VideoDescriptions.Find(id);
            string path = Path.Combine(file.Id + "." + file.Extension);
            if (provider.GetFileInfo(path).Exists)
            {
                result = await Task.Run(() => provider.GetFileInfo(path));
            }
            return result;
        }

        public Task Add(VideoDescription videoDescription)
        {
            _dbContext.AddAsync(videoDescription);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
