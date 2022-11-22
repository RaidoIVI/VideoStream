using Microsoft.Extensions.FileProviders;
using VideoStream.Data;
using VideoStream.Model;

namespace VideoStream.Domain
{
    public interface IVideoManager
    {
        Task<ICollection<VideoDescription>> GetList();
        Task<IFileInfo> GetFile(Guid id);
        Task Add(VideoDescription description);
    }

    public class VideoManager : IVideoManager
    {
        private readonly IVideoFileRepo _videoFileRepo;

        public VideoManager(IVideoFileRepo videoFileRepo)
        {
            _videoFileRepo = videoFileRepo;
        }

        public async Task<ICollection<VideoDescription>> GetList()
        {
            var result = await _videoFileRepo.GetList();
            return result;
        }

        public async Task<IFileInfo> GetFile(Guid id)
        {
            var result = await _videoFileRepo.GetFile(id);
            return result;
        }

        public async Task Add(VideoDescription description)
        {
            await _videoFileRepo.Add(description);
        }
    }
}
