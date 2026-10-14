namespace AlshrouqSchool.Shared.DTOs.Gallery.Common;

public sealed record PagedResult<T>(IReadOnlyList<T> Items, int PageNumber, int PageSize, int TotalCount)
{
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}
public sealed record ApiResponse<T>(bool Succeeded, T? Data = default, string? Message = null);
public sealed record Result<T>(bool Succeeded, T? Value = default, string? Error = null)
{
    public static Result<T> Success(T value) => new(true, value);
    public static Result<T> Failure(string error) => new(false, default, error);
}