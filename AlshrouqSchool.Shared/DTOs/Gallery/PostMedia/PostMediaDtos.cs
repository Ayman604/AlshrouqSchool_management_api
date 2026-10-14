using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Shared.DTOs.Gallery.Media;
namespace AlshrouqSchool.Shared.DTOs.Gallery.PostMedia;
public sealed record PostMediaDto(int Id, int PostId, int MediaId, MediaRole MediaRole, int DisplayOrder, MediaSummaryDto? Media);
public sealed class AttachMediaToPostDto { public int PostId { get; init; } public int MediaId { get; init; } public MediaRole MediaRole { get; init; } public int DisplayOrder { get; init; } }
public sealed class ReorderPostMediaDto { public int PostId { get; init; } public IReadOnlyList<PostMediaOrderItemDto> Items { get; init; } = []; }
public sealed record PostMediaOrderItemDto(int PostMediaId, int DisplayOrder);
public sealed class DetachMediaFromPostDto { public int PostId { get; init; } public int MediaId { get; init; } }