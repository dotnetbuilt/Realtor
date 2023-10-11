using Realtor.Service.DTOs.Links;

namespace Realtor.Service.Interfaces;

public interface ILinkService
{
    ValueTask<LinkResultDto> AddAsync(LinkCreationDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<LinkResultDto> RetrieveByIdAsync(long id);
}