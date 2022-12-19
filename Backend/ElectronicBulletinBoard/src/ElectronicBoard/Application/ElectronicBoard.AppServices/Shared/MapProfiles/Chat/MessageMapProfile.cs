using AutoMapper;
using ElectronicBoard.Contracts.Chat.Message;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Chat;

public class MessageMapProfile: Profile
{
    public MessageMapProfile()
    {
        CreateMap<MessageEntity, MessageDto>()
            .ForMember(m=>m.CreateDate, o=>
                o.MapFrom(src => src.CreateDate.ToString("u").Replace(" ", "T")));

        CreateMap<MessageDto, MessageEntity>()
            .ForMember(m=>m.User, o=>o.Ignore())
            .ForMember(m=>m.Conversation, o=>o.Ignore())
            .ForMember(m=>m.ModifyDate, o=>o.Ignore())
            .ForMember(m=>m.CreateDate, o=>o.Ignore());
        
    }
}