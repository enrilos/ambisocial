namespace AmbiSocial.Application.Posts.Commands.Create;

using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Domain.Common.Models.ModelConstants.Common;

public class PostCreateCommandValidatorSpecs
{
    private readonly PostCreateCommandValidator validator = new();

    private const string InvalidImageUrl = "abc";
    private const string ValidImageUrl = "https://abc.com";

    private static readonly string InvalidMaxDescriptionLength = new('a', MaxDescriptionLength + 1);

    private static readonly string InvalidMinAuthorUserNameLength = new('a', MinNameLength - 1);
    private static readonly string InvalidMaxAuthorUserNameLength = new('a', MaxNameLength + 1);

    private static readonly string ValidMaxDescriptionLength = new('a', MaxDescriptionLength);
    private static readonly string ValidMinAuthorUserNameLength = new('a', MinNameLength);
    private static readonly string ValidMaxAuthorUserNameLength = new('a', MaxNameLength);

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorsIfAnyPropertiesAreInvalid(string imageUrl, string description, string author)
    {
        var createCommand = new PostCreateCommand()
        {
            ImageUrl = imageUrl,
            Description = description,
            AuthorUserName = author
        };

        var result = validator.TestValidate(createCommand);

        result.IsValid.Should().BeFalse();
        result.ShouldHaveValidationErrorFor(x => x.ImageUrl);
        result.ShouldHaveValidationErrorFor(x => x.Description);
        result.ShouldHaveValidationErrorFor(x => x.AuthorUserName);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorsIfAnyPropertiesAreInvalid(string imageUrl, string description, string author)
    {
        var createCommand = new PostCreateCommand()
        {
            ImageUrl = imageUrl,
            Description = description,
            AuthorUserName = author
        };

        var result = validator.TestValidate(createCommand);

        result.IsValid.Should().BeTrue();
        result.ShouldNotHaveValidationErrorFor(x => x.ImageUrl);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
        result.ShouldNotHaveValidationErrorFor(x => x.AuthorUserName);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[]
        {
            InvalidImageUrl,
            InvalidMaxDescriptionLength,
            InvalidMaxAuthorUserNameLength
        };

        yield return new object[]
        {
            InvalidImageUrl,
            InvalidMaxDescriptionLength,
            InvalidMinAuthorUserNameLength
        };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[]
        {
            ValidImageUrl,
            ValidMaxDescriptionLength,
            ValidMaxAuthorUserNameLength
        };
    }
}