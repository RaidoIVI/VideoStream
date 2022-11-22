using VideoStream.Data;
using VideoStream.Model;

namespace VideoStream.Domain
{
    public interface IVideoController
    {
        Task<ICollection<VideoDescription>> GetList();
        Task<VideoFile> GetFile(Guid id);
        Task Add(VideoDescription description, VideoFile file);
    }

    public class VideoController : IVideoController
    {
        private readonly IVideoFileRepo _videoFileRepo;

        public VideoController(IVideoFileRepo videoFileRepo)
        {
            _videoFileRepo = videoFileRepo;
        }

        public async Task<ICollection<VideoDescription>> GetList()
        {
            var result = await _videoFileRepo.GetList();
            return result;
        }

        public async Task<VideoFile> GetFile(Guid id)
        {
            var result = await _videoFileRepo.GetFile(id);
            return result;
        }

        public async Task Add(VideoDescription description, VideoFile file)
        {
            await _videoFileRepo.Add(description, file);
        }
    }
}
