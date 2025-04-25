using meli_clone_ms_products.Application.DTOs;
using meli_clone_ms_products.Domain.Entities;

namespace meli_clone_ms_products.Application.Mappers;

public static class QuestionMapper
{
    public static QuestionDto ToDTO(Question question)
    {
        if (question == null) return null;

        return new QuestionDto
        (
            question.UserId,
            question.QuestionText,
            question.responseText,
            question.CreatedAt,
            question.AnsweredAt
        );
    }
}

// Extension methods for easier mapping
public static class QuestionMapperExtensions
{
    public static QuestionDto ToDTO(this Question question)
    {
        return QuestionMapper.ToDTO(question);
    }
}
