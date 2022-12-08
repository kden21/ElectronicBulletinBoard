using AutoMapper;
using ElectronicBoard.Contracts.Chat.Conversation;
using ElectronicBoard.Domain.Chat;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Chat;

public class ConversationMapProfile:Profile
{
    public ConversationMapProfile()
    {
        CreateMap<ConversationEntity, ConversationDto>();
            
        
        CreateMap<ConversationDto, ConversationEntity>()
            .ForMember(c=>c.CreateDate, o=>o.Ignore())
            .ForMember(c=>c.Messages, o=>o.Ignore())
            .ForMember(c=>c.ConversationMembers, o=>o.Ignore())
            .ForMember(c=>c.ModifyDate, o=>o.Ignore());
    }
}