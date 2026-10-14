using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Shared.DTOs.Gallery.PostMedia;
namespace AlshrouqSchool.Shared.DTOs.Gallery.Posts;
public sealed record PostDto(int Id, string Title, string Slug, string Content, string? Excerpt, PostType Type, int DisplayOrder, bool IsPublished, DateTime? PublishedAtUtc);
public sealed record PostSummaryDto(int Id, string Title, string Slug, string? Excerpt, PostType Type, int DisplayOrder, bool IsPublished, DateTime? PublishedAtUtc);
public sealed record PostDetailsDto(int Id, string Title, string Slug, string Content, string? Excerpt, PostType Type, int DisplayOrder, bool IsPublished, DateTime? PublishedAtUtc, IReadOnlyList<PostMediaDto> Media);
public sealed class CreatePostDto { public string Title { get; init; } = string.Empty; public string Slug { get; init; } = string.Empty; public string Content { get; init; } = string.Empty; public string? Excerpt { get; init; } public PostType Type { get; init; } public int DisplayOrder { get; init; } }
public sealed class UpdatePostDto { public string Title { get; init; } = string.Empty; public string Slug { get; init; } = string.Empty; public string Content { get; init; } = string.Empty; public string? Excerpt { get; init; } public PostType Type { get; init; } public int DisplayOrder { get; init; } }
public sealed class PublishPostDto { public DateTime? PublishedAtUtc { get; init; } }
public sealed class PostQueryParameters { public int PageNumber { get; init; } = 1; public int PageSize { get; init; } = 20; public PostType? Type { get; init; } public string? Search { get; init; } }