using System;
namespace Tindyr.Extensions
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ProfilesPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeader(int currentPage, int profilesPerPage, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ProfilesPerPage = profilesPerPage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}
