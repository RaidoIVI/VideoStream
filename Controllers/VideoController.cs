using Microsoft.AspNetCore.Mvc;
using VideoStream.Domain;
using VideoStream.Model;

namespace VideoStream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoManager _videoManager;

        public VideoController(IVideoManager videoManager)
        {
            _videoManager = videoManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _videoManager.GetList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(Guid id)
        {
            var result = await _videoManager.GetFile(id);
            return PhysicalFile(result.PhysicalPath, contentType: "application/octet-stream", fileDownloadName: new Guid() + result.PhysicalPath,
                enableRangeProcessing: true);
        }

        [HttpPost]
        public async Task Add(VideoDto videoDto)
        {
            var description = new VideoDescription
            {
                Id = new Guid(),
                Description = videoDto.Description,
                Name = videoDto.Name
            };
 
            await _videoManager.Add(description);
        }
    }
}
