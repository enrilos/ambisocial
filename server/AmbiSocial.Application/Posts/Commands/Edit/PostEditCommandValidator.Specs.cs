namespace AmbiSocial.Application.Posts.Commands.Edit;

using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Domain.Common.Models.ModelConstants.Common;

public class PostEditCommandValidatorSpecs
{
    private readonly PostEditCommandValidator validator = new();

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
        var editCommand = new PostEditCommand()
        {
            ImageUrl = imageUrl,
            Description = description,
            ProfileUserName = author
        };

        var result = validator.TestValidate(editCommand);

        result.IsValid.Should().BeFalse();
        result.ShouldHaveValidationErrorFor(x => x.ImageUrl);
        result.ShouldHaveValidationErrorFor(x => x.Description);
        result.ShouldHaveValidationErrorFor(x => x.ProfileUserName);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorsIfAnyPropertiesAreInvalid(string imageUrl, string description, string author)
    {
        var editCommand = new PostEditCommand()
        {
            ImageUrl = imageUrl,
            Description = description,
            ProfileUserName = author
        };

        var result = validator.TestValidate(editCommand);

        result.IsValid.Should().BeTrue();
        result.ShouldNotHaveValidationErrorFor(x => x.ImageUrl);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
        result.ShouldNotHaveValidationErrorFor(x => x.ProfileUserName);
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