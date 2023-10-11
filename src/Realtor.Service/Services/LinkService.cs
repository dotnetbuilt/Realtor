using AutoMapper;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Links;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class LinkService:ILinkService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LinkService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<LinkResultDto> AddAsync(LinkCreationDto dto)
    {
        var mappedLink = _mapper.Map<Link>(source: dto);

        await _unitOfWork.LinkRepository.CreateAsync(entity: mappedLink);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<LinkResultDto>(source: mappedLink);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existLink = await _unitOfWork.LinkRepository.SelectAsync(expression:link => link.Id == id);

        if (existLink == null)
            throw new NotFoundException(message: "Link is not found");
        
        _unitOfWork.LinkRepository.Delete(entity:existLink);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<LinkResultDto> RetrieveByIdAsync(long id)
    {
        var existLink = await _unitOfWork.LinkRepository.SelectAsync(expression:link => link.Id == id);

        if (existLink == null)
            throw new NotFoundException(message: "Link is not found");

        return _mapper.Map<LinkResultDto>(source: existLink);
    }
}