using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Shared.DTOs.GalleryGTOs
{
    public class GalleryQueryDTO
    {
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string? AltText { get; set; }

    }
}
